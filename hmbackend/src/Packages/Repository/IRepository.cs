using Microsoft.Extensions.DependencyInjection;

namespace Packages.Repository;

public interface IRepository
{
    Task<TAggregate?> LoadAsync<TAggregate, TState>(Guid id) 
        where TAggregate : IAggregateRoot<TState>
        where TState : class;
    
   

    class Imp : IRepository
    {
        private readonly IEntityStrategyRepository _strategyRepository;
        private readonly IServiceProvider _sp;
        private readonly IDbAdapter _dbAdapter;

        public Imp(
            IEntityStrategyRepository strategyRepository, 
            IServiceProvider sp,
            IDbAdapter dbAdapter)
        {
            _strategyRepository = strategyRepository;
            _sp = sp;
            _dbAdapter = dbAdapter;
        }

        private IEntityStrategy GetStrategy<T>() where T : class
        {
            var t = _strategyRepository.GetEntityStrategyType<T>();
            var strategy = ActivatorUtilities.CreateInstance(_sp, t) as IEntityStrategy;
            return strategy!;
        }
        
        public async Task<TAggregate?> LoadAsync<TAggregate, TState>(Guid id) 
            where TAggregate : IAggregateRoot<TState>
            where TState : class
        {
           var strategy = GetStrategy<TAggregate>();
           return await strategy.LoadAsync<TAggregate, TState>(id);
           
        }

    }
}