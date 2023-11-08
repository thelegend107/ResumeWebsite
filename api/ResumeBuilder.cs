using ResumeBuilderAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using api.Models;

namespace ResumeBuilderAPI
{
    public class ResumeBuilder
    {
        private readonly CountryService _countryService;

        public ResumeBuilder()
        {
            _countryService = new CountryService();
        }

        [FunctionName("ResumeBuilder")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Countries")]
        public async Task<IEnumerable<Country>> GetCountries([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return await _countryService.RetrieveCountries();
        }

        //[FunctionName("States")]
        //public async Task<IEnumerable<State>> GetStatesByCountry([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "states/{countryCode}")] HttpRequest req, string countryCode, ILogger log)
        //{
        //    log.LogInformation("C# HTTP trigger function processed a request.");
        //    ICollection<State> states = new List<State>();

        //    if (!string.IsNullOrEmpty(countryCode) && _countryService.RetrieveCountries().Any(x => x.ISO2 == countryCode))
        //    {
        //        states = _countryService.RetrieveCountries().SingleOrDefault(x => x.ISO2 == countryCode).States;
        //        return states;
        //    }

        //    return states;
        //}
    }
}
