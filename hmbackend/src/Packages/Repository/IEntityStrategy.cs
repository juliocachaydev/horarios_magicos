namespace Packages.Repository;

public interface IEntityStrategy
{
    Type EntityType { get; }
    
    Task<T?> LoadAsync<T>(Guid id) where T : class;
    
    Task AddAsync<T>(T entity) where T : class;
    
    Task RemoveAsync<T>(T entity) where T : class;

    Task CommitChangesAsync();
    
}