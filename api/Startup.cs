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
            SqlConnection sqlConnection = new SqlConnection(Environment.GetEnvironmentVariable("datawarehouseDb"));

            builder.Services.AddScoped((s) => new UserService(sqlConnection));
            builder.Services.AddScoped((s) => new AddressService(sqlConnection));
            builder.Services.AddScoped((s) => new EducationService(sqlConnection, new AddressService(sqlConnection)));
            builder.Services.AddScoped((s) => new WorkExperienceService(sqlConnection, new AddressService(sqlConnection)));
            builder.Services.AddScoped((s) => new SkillService(sqlConnection));
            builder.Services.AddScoped((s) => new CertificateService(sqlConnection));
            builder.Services.AddScoped((s) => new LinkService(sqlConnection));
            builder.Services.AddScoped((s) => new FileService(sqlConnection));
        }
    }
}
