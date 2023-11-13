using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ResumeAPI.Models;
using ResumeAPI.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace ResumeAPI
{
    public class Resume
    {
        private readonly UserService _userService;

        public Resume(UserService userService)
        {
            _userService = userService;
        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> GetUserById
        (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User/{id:int?}")] HttpRequest req,
            int? id,
            ExecutionContext executionContext, 
            ILogger log
        )
        {
            if (!id.HasValue)
                return new NotFoundResult();

            log.LogInformation($"Executing API {executionContext.FunctionName}");

            User user = await _userService.RetrieveUserById(1);

            return new OkObjectResult(user);
        }

        [FunctionName("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEnail
        (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User/{email}")] HttpRequest req,
            string email,
            ExecutionContext executionContext, 
            ILogger log
        )
        {
            log.LogInformation($"Executing API {executionContext.FunctionName}");

            if (string.IsNullOrWhiteSpace(email))
                return new NotFoundResult();

            User user = await _userService.RetrieveUserById(1);

            return new OkObjectResult(user);
        }
    }
}
