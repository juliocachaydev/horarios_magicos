
using Api;
using Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Alpaca;

public abstract class TestIntegrationTestBase
{
    
    protected TestIntegrationTestBase()
    {
        DefaultApplicationFactory = CreateApplicationFactory();
    }
    
    public CustomApplicationFactory DefaultApplicationFactory { get; protected set; }

    public CustomApplicationFactory CreateApplicationFactory(
        Action<IServiceCollection>? additionalConfigureServiceAction = null)
    {
        return new CustomApplicationFactory(
            b =>
            {
                
                Environment.SetEnvironmentVariable("Development__UseDockerDevDatabase","false");
                Environment.SetEnvironmentVariable("AlpineICommandOptions__SyncToICommand", "false");
                Environment.SetEnvironmentVariable("DeltekApiOptions__SyncToDeltek","false");
                Environment.SetEnvironmentVariable("SengridOptions__Disabled","true");
                b.ConfigureServices(services =>
                {
                    /*
                     * Instead of the real DbContext, we will use an SqlLite in-memory implementation.
                     */
                    ReplaceAppDbContextWithInMemoryImplementation(services);
                    
                    if (additionalConfigureServiceAction is not null)
                    {
                        additionalConfigureServiceAction(services);
                    }
                });
            });
    }
    
    public CustomApplicationFactory CreateApplicationFactoryWithCustomConfiguration(
        Action<IWebHostBuilder> webHostBuilderAction,
        Action<IServiceCollection>? additionalConfigureServiceAction = null)
    {
        return new CustomApplicationFactory(
            b =>
            {
                webHostBuilderAction(b);
                Environment.SetEnvironmentVariable("Development__UseDockerDevDatabase","false");
                Environment.SetEnvironmentVariable("AlpineICommandOptions__SyncToICommand", "false");
                Environment.SetEnvironmentVariable("DeltekApiOptions__SyncToDeltek","false");
                b.ConfigureServices(services =>
                {
                    /*
                     * Instead of the real DbContext, we will use an SqlLite in-memory implementation.
                     */
                    ReplaceAppDbContextWithInMemoryImplementation(services);
                    
                    if (additionalConfigureServiceAction is not null)
                    {
                        additionalConfigureServiceAction(services);
                    }
                });
            });
    }

    /// <summary>
    /// Replaces the AppDbContext to work with an in-memory SqlLite database, overriding the app configuration.
    /// </summary>
    private static void ReplaceAppDbContextWithInMemoryImplementation(IServiceCollection services)
    {
        // Use an in-memory implementation instead of the real database
        //https://learn.microsoft.com/en-us/ef/core/testing/testing-without-the-database#sqlite-in-memory
        
        SqliteConnection connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        DbContextOptions<AppDbContext> contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;
        
        services.TestReplaceScopedService<AppDbContext>(
            sp =>
            {
                var result = new AppDbContext(contextOptions);
                result.Database.EnsureCreated();

                if (result.Database.GetPendingMigrations().Any())
                {
                    result.Database.Migrate();
                }
                
                return result;
            });
    }
 
}