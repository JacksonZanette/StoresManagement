using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoresManagement.Domain.Repositories;
using StoresManagement.Infra.Companies;
using StoresManagement.Infra.Stores;
using System.Reflection;

namespace StoresManagement.Infra.Extensions;

public static class InfraServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var commandsHandlersAssembly = Assembly.Load("StoresManagement.Application");

        return services
            .AddDatabase(configuration)
            .AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(commandsHandlersAssembly));
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseDatabase();

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["POSTGRESQLCONNSTR_AZURE_POSTGRESQL_CONNECTIONSTRING"];

        return services
            .AddDbContext<StoresManagementContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<ICompaniesRepository, CompaniesRepository>()
            .AddScoped<IStoresRepository, StoresRepository>();
    }

    private static IApplicationBuilder UseDatabase(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseAutomaticMigrations();
}