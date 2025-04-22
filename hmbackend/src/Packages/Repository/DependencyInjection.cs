using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Packages.Repository;

public static class DependencyInjection
{
    public static void AddRepository(
        this IServiceCollection services, 
        Func<IServiceProvider, IDbAdapter> dbAdapterFactory,
        Assembly assemblyToScan)
    {
        services.AddSingleton<IEntityStrategyRepository>(sp =>
        {
            var repo = new IEntityStrategyRepository.Imp(sp);
            repo.ScanAssemblyForEntityStrategies(assemblyToScan);
            return repo;
        });

        services.AddScoped(dbAdapterFactory);

        services.AddScoped<IRepository, IRepository.Imp>();
    }
}