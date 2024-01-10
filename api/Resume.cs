using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ResumeAPI.Models;
using System.Net;
using Thelegend107.Data.Lib.Entities;
using Thelegend107.Data.Lib.Services;

namespace ResumeAPI
{
    public class Resume
    {
        private readonly ILogger _logger;
        private readonly UserService _userService;
        private readonly AddressService _addressService;
        private readonly EducationService _educationService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly SkillService _skillService;
        private readonly CertificateService _certificateService;
        private readonly LinkService _linkService;

        public Resume
        (
            UserService userService,
            AddressService addressService,
            EducationService educationService,
            WorkExperienceService workExperienceService,
            SkillService skillService,
            CertificateService certificateService,
            LinkService linkService,
            ILoggerFactory loggerFactory
        )
        {
            _userService = userService;
            _addressService = addressService;
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _skillService = skillService;
            _certificateService = certificateService;
            _linkService = linkService;
            _logger = loggerFactory.CreateLogger<Resume>();
        }

        [Function("GetUserResume")]
        public async Task<HttpResponseData> GetUserResume([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "UserResume/{parameter}")] HttpRequestData req, string parameter)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            ResumeModel? model = null;

            if (string.IsNullOrWhiteSpace(parameter))
                return req.CreateResponse(HttpStatusCode.NotFound);

            model = await GetResumeModelAsync(parameter);

            HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(model);

            return response;
        }

        public async Task<ResumeModel?> GetResumeModelAsync(string parameter)
        {
            ResumeModel model = new ResumeModel();

            if (parameter.All(x => char.IsDigit(x)))
                model.User = await _userService.RetrieveUserById(int.Parse(parameter));
            else
                model.User = await _userService.RetrieveUserByEmail(parameter);

            if (model.User == null)
                return null;

            Task<Address?> addressTask = _addressService.RetrieveAddressById(model.User.AddressId);
            Task<IEnumerable<Education>> educationsTask = _educationService.RetrieveEducations(model.User.Id);
            Task<IEnumerable<WorkExperience>> workExperiencesTask = _workExperienceService.RetrieveWorkExperiences(model.User.Id);
            Task<IEnumerable<Skill>> skillsTask = _skillService.RetrieveSkills(model.User.Id);
            Task<IEnumerable<Certificate>> certificatesTask = _certificateService.RetrieveCertifcates(model.User.Id);
            Task<IEnumerable<Link>> linksTask = _linkService.RetrieveLinks(model.User.Id);

            Task.WaitAll(addressTask, educationsTask, workExperiencesTask, skillsTask, certificatesTask, linksTask);

            model.Address = addressTask.Result;
            model.Educations = educationsTask.Result;
            model.WorkExperiences = workExperiencesTask.Result;
            model.Skills = skillsTask.Result;
            model.Certificates = certificatesTask.Result;
            model.Links = linksTask.Result;

            return model;
        }
    }
}
