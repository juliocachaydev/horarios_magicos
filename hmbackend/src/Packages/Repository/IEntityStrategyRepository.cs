using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Packages.Repository;

public interface IEntityStrategyRepository
{
    Type GetEntityStrategyType<T>() where T : class;
    
    void ScanAssemblyForEntityStrategies(Assembly assembly);

    class Imp : IEntityStrategyRepository
    {
        private readonly IServiceProvider _sp;
        // <EntityType, StrategyType>
        private Dictionary<Type, Type> _entityStrategies = new ();

        public Imp(IServiceProvider sp)
        {
            _sp = sp;
        }
        
        public Type GetEntityStrategyType<TEntity>() where TEntity : class
        {
            if (_entityStrategies.TryGetValue(typeof(TEntity), out var strategyType))
            {
                return (strategyType) as Type;
            }
            throw new InvalidOperationException($"No entity strategy found for type {typeof(TEntity).Name}");
        }

        public void ScanAssemblyForEntityStrategies(Assembly assembly)
        {
            _entityStrategies.Clear();
            
            var strategyTypes = assembly.GetTypes().Where(x =>
                x.IsAssignableTo(typeof(IEntityStrategy))).ToArray();

            foreach (var s in strategyTypes)
            {
                var instance = (ActivatorUtilities.CreateInstance(_sp, s) as IEntityStrategy)!;
                
                _entityStrategies.Add(instance.EntityType, s);
            }
        }
    }
}