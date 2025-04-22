namespace Packages.Repository;

public interface IEntityStrategy
{
    Type EntityType { get; }

    Task<TAggregate?> LoadAsync<TAggregate, TState>(Guid id)
        where TAggregate : IAggregateRoot<TState>
        where TState : class;
    
    
}