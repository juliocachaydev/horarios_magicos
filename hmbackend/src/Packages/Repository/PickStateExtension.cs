using System.Reflection;

namespace Packages.Repository;

public static class PickStateExtension
{
    public static TState PickState<TAggregate, TState>(this TAggregate aggregate)
        where TAggregate : IAggregateRoot<TState>
        where TState : class
    {
        if (aggregate == null)
        {
            throw new ArgumentNullException(nameof(aggregate));
        }

        // Get the type of the aggregate
        var aggregateType = aggregate.GetType();

        // Find a private field of type TState
        var fieldInfo = aggregateType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.FieldType == typeof(TState));

        if (fieldInfo == null)
        {
            throw new InvalidOperationException($"No private field of type {typeof(TState).Name} found in {aggregateType.Name}");
        }

        // Get the value of the field
        return (TState)fieldInfo.GetValue(aggregate)!;
    }
}