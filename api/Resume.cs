using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using ResumeAPI.Entities;
using ResumeAPI.Models;
using ResumeAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI
{
    public class Resume
    {
        private readonly UserService _userService;
        private readonly AddressService _addressService;
        private readonly EducationService _educationService;
        private readonly WorkExperienceService _workExperienceService;
        private readonly SkillService _skillService;
        private readonly CertificateService _certificateService;
        private readonly LinkService _linkService;
        private readonly FileService _fileService;

        public Resume
        (
            UserService userService,
            AddressService addressService,
            EducationService educationService,
            WorkExperienceService workExperienceService,
            SkillService skillService,
            CertificateService certificateService,
            LinkService linkService,
            FileService fileService
        )
        {
            _userService = userService;
            _addressService = addressService;
            _educationService = educationService;
            _workExperienceService = workExperienceService;
            _skillService = skillService;
            _certificateService = certificateService;
            _linkService = linkService;
            _fileService = fileService;
        }

        [FunctionName("GetUserResume")]
        public async Task<IActionResult> GetUserResume
        (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User/{parameter}")] HttpRequest req,
            string parameter,
            ExecutionContext executionContext,
            ILogger log
        )
        {
            log.LogInformation($"Executing API {executionContext.FunctionName}");

            ResumeModel? model = null;

            if (string.IsNullOrWhiteSpace(parameter))
                return new NotFoundResult();

            model = await GetResumeModelAsync(parameter);

            return new OkObjectResult(model);
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
            Task<IEnumerable<File>> filesTask = _fileService.RetrieveFiles(model.User.Id);

            Task.WaitAll(addressTask, educationsTask, workExperiencesTask, skillsTask, certificatesTask, linksTask, filesTask);

            model.Address = addressTask.Result;
            model.Educations = educationsTask.Result;
            model.WorkExperiences = workExperiencesTask.Result;
            model.Skills = skillsTask.Result;
            model.Certificates = certificatesTask.Result;
            model.Links = linksTask.Result;
            model.Files = filesTask.Result;

            return model;
        }
    }
}
