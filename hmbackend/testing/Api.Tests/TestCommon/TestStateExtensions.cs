using System.Reflection;
using Domain.Common;

namespace Application.Tests.TestCommon;

public static class TestStateExtensions
{
    public static T TestPickState<T>(this AggregateBase aggregate) where T : class
    {
        var field = aggregate.GetType()
            .GetField("_state", BindingFlags.NonPublic | BindingFlags.Instance);

        if (field is null)
        {
            throw new InvalidOperationException("State field not found in aggregate. The state field name should be \"_state\"");
        }
        return (T)field.GetValue(aggregate)!;
    }
}