using api.Services;
using Api.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContextPool<DatawarehouseContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings:datawarehouseDb"))
            );
            builder.Services.AddScoped<CountryService>();
        }
    }
}
