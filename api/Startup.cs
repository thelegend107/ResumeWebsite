using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ResumeAPI.Services;
using System;
using System.Data.SqlClient;

[assembly: FunctionsStartup(typeof(ResumeAPI.Startup))]

namespace ResumeAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton((s) => {
                return new SqlConnection(Environment.GetEnvironmentVariable("datawarehouseDb"));
            });

            builder.Services.AddSingleton<UserService>();
        }
    }
}
