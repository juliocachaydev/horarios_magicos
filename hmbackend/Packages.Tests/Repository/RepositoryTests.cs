using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Packages.Repository;

namespace Packages.Tests;

public class RepositoryTests
{
    [Fact]
    public async Task CanGetEntity()
    {
        // ***** ARRANGE *****

        var serviceCollection = new ServiceCollection();
        
        var sp = serviceCollection.BuildServiceProvider();

        var entityStrategyRepository = new IEntityStrategyRepository.Imp(sp);
        
        entityStrategyRepository.ScanAssemblyForEntityStrategies(typeof(TestEntityState).Assembly);

        var repository = new IRepository.Imp(
            entityStrategyRepository, sp, Mock.Of<IDbAdapter>());
            
        // ***** ACT *****

        var result = await repository.LoadAsync<TestEntity, TestEntityState>(
            Guid.Empty);

        // ***** ASSERT *****

        Assert.NotNull(result);
        var state = result.PickState<TestEntity, TestEntityState>();
        
        Assert.Same(TestEntityStrategy.StateReturns, state);
    }

    class TestEntityState
    {
        
    }

    class TestEntity : IAggregateRoot<TestEntityState>
    {
        private readonly TestEntityState _state;

        public TestEntity(TestEntityState state)
        {
            _state = state;
        }
    }
    
    class TestEntityStrategy : IEntityStrategy
    {
        public Type EntityType => typeof(TestEntity);

        public static TestEntityState StateReturns { get; } = new();
        
        public async Task<TAggregate?> LoadAsync<TAggregate, TState>(Guid id) where TAggregate : IAggregateRoot<TState> where TState : class
        {
            var result = new TestEntity(StateReturns);
            return (result as TAggregate);
        }
    }
}