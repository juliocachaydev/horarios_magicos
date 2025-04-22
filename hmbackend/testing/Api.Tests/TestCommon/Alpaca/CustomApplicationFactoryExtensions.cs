
using Api;
using Application;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Alpaca;

public static class CustomApplicationFactoryExtensions
{
    /// <summary>
    /// Gets a service from the underlying Dependency Injection container.
    /// </summary>
    public static IServiceScope GetService<TServiceDefinition>(
        this CustomApplicationFactory customApplicationFactory,
        out TServiceDefinition service)
    {
        IServiceScope scope = customApplicationFactory.Services.CreateScope();
        service = scope.ServiceProvider.GetService<TServiceDefinition>()!;

        return scope;
    }

    /// <summary>
    /// Gets entities from the underlying db context
    /// </summary>
    /// <param name="customApplicationFactory">The ApplicationFactory that has the DI Container</param>
    /// <param name="query">A way to enrich the query, or include child entities</param>
    /// <returns></returns>
    public static ICollection<TEntity> GetEntities<TEntity>(this CustomApplicationFactory customApplicationFactory,
        Func<AppDbContext, ICollection<TEntity>> query)
    {
        using IServiceScope scope = customApplicationFactory.GetService(out AppDbContext dbContext);

        return query(dbContext);
    }

    public static TEntity? GetEntity<TEntity>(this CustomApplicationFactory customApplicationFactory,
        Func<AppDbContext, TEntity?> query)
    {
        using IServiceScope scope = customApplicationFactory.GetService(out AppDbContext dbContext);

        return query(dbContext);
    }

    /// <summary>
    /// Adds an entity to the underlying database
    /// </summary>
    public static void AddEntitiesToDatabase<TEntity>(this CustomApplicationFactory customApplicationFactory,
        params TEntity[] entities)
        where TEntity : class
    {
        using IServiceScope scope = customApplicationFactory.GetService(out AppDbContext dbContext);
        
        dbContext.AddRange(entities);
        dbContext.SaveChanges();
    }

    public static void OperateOnDatabase(this CustomApplicationFactory customApplicationFactory,
        Action<AppDbContext> action)
    {
        using IServiceScope scope = customApplicationFactory.GetService(out AppDbContext dbContext);
        action(dbContext);
    }
}