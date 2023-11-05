using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api
{
    public class ResumeBuilder
    {
        private readonly DatawarehouseContext _dbContext;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly List<Country> _countries;


        public ResumeBuilder()
        {
            _dbContext = new DatawarehouseContext();
            if (_dbContext.Database.CanConnect())
            {
                _countries = _dbContext.Countries.Include(x => x.States).Include(x => x.SubRegion).Include(x => x.Region).ToList();
            }
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

            return new OkObjectResult($"Can connect to Azure SQL Server? {_dbContext.Database.CanConnect()}");
        }

        [FunctionName("Countries")]
        public async Task<IEnumerable<Country>> GetCountries([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return _countries;
        }

        [FunctionName("States")]
        public async Task<IEnumerable<State>> GetStatesByCountry([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "states/{countryCode}")] HttpRequest req, string countryCode, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            ICollection<State> states = new List<State>();

            if (!string.IsNullOrEmpty(countryCode) && _countries.Any(x => x.ISO2 == countryCode))
            {
                states = _countries.SingleOrDefault(x => x.ISO2 == countryCode).States;
                return states;
            }

            return states;
        }
    }
}
