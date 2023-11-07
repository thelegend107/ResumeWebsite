using ResumeBuilderAPI.Services;
using ResumeBuilderAPI.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(ResumeBuilderAPI.Startup))]

namespace ResumeBuilderAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContextPool<DatawarehouseContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("datawarehouseDb"))
            );
            builder.Services.AddScoped<CountryService>();
        }
    }
}
