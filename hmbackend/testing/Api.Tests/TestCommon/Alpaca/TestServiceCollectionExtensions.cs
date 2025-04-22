// ReSharper disable once CheckNamespace

using Microsoft.Extensions.DependencyInjection;

namespace Alpaca;

public static class TestServiceCollectionExtensions
{
    
    /// <summary>
    /// Replaces a scoped service in the DI Container
    /// </summary>
    /// <param name="services">The DI Container service collection</param>
    /// <param name="currentImplementationType">The current implementation type to be replaced</param>
    /// <param name="factory">A factory so the DI Container can create instances of the new service</param>
    /// <typeparam name="TDefinition">The definition type, a common type to the old and new implementation types</typeparam>
    /// <typeparam name="TNewImplementation">The new implementation type</typeparam>
    public static void TestReplaceScopedService<TDefinition>(
        this IServiceCollection services,
        Func<IServiceProvider, object> factory)
    
    {

        var old = services.First(x =>
            x.ServiceType == typeof(TDefinition));

        services.Remove(old);

        services.AddScoped(typeof(TDefinition), factory);
    }
}