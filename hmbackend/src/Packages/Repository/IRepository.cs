using Microsoft.Extensions.DependencyInjection;

namespace Packages.Repository;

public interface IRepository
{
    Task<T?> LoadAsync<T>(Guid id) where T : class;
    
    Task<T> LoadOrThrowAsync<T>(Guid id) where T : class;
    
    Task AddAsync<T>(T entity) where T : class;

    Task RemoveAsync<T>(Guid id) where T : class;

    Task CommitChangesAsync();

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
        
        public Task<T?> LoadAsync<T>(Guid id) where T : class
        {
           var s = GetStrategy<T>();
           return s.LoadAsync<T>(id);
        }

        public async Task<T> LoadOrThrowAsync<T>(Guid id) where T : class
        {
            var result = await LoadAsync<T>(id);
            if (result is null)
            {
                throw new InvalidOperationException($"Entity {typeof(T).Name} with id {id} not found");
            }

            return result;
        }

        public Task AddAsync<T>(T entity) where T : class
        {
            var s = GetStrategy<T>();
            return s.AddAsync(entity);
        }

        public async Task RemoveAsync<T>(Guid id) where T : class
        {
            var s = GetStrategy<T>();
            var entity = await LoadOrThrowAsync<T>(id);
            await s.RemoveAsync(entity);
        }

        public Task CommitChangesAsync()
        {
            return _dbAdapter.CommitChangesAsync();
        }
    }
}