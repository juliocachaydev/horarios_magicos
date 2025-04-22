using System.Reflection;
using Packages.Repository;

namespace Api;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(c =>
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<AppDbContext>();
        
        services.AddRepository(sp => new DbAdapter(sp.GetRequiredService<AppDbContext>()), Assembly.GetExecutingAssembly());
    }
}

class DbAdapter(AppDbContext dbContext) : IDbAdapter
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task CommitChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}