using System.Reflection;

namespace Api;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(c =>
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}