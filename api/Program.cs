using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Thelegend107.Data.Lib;
using Thelegend107.Data.Lib.Services;

static DatawarehouseContext DbContextInit()
{
    DatawarehouseContext dbContext = new DatawarehouseContext
    (
        new DbContextOptionsBuilder<DatawarehouseContext>().UseSqlServer(
            Environment.GetEnvironmentVariable("datawarehouseDb")
        ).Options
    );

    return dbContext;
}

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddScoped((s) => new UserService(DbContextInit()));
        services.AddScoped((s) => new AddressService(DbContextInit()));
        services.AddScoped((s) => new EducationService(DbContextInit()));
        services.AddScoped((s) => new WorkExperienceService(DbContextInit()));
        services.AddScoped((s) => new SkillService(DbContextInit()));
        services.AddScoped((s) => new CertificateService(DbContextInit()));
        services.AddScoped((s) => new LinkService(DbContextInit()));
    })
    .Build();

host.Run();
