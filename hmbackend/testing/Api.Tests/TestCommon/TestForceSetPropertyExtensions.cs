namespace Application.Tests.TestCommon;


public static class TestForceSetPropertyExtensions
{
    /// <summary>
    /// Sets a private property value using reflection
    /// </summary>
    public static void TestForceSetProperty(this object target, string propertyName, object value)
    {
        target.GetType().GetProperties()
            .First(p => p.Name == propertyName)
            .SetValue(target, value);
    }

    public static void TestForceAddToList<T>(
        this object target, string propertyName,
        params T[] value)
    {
        var current = (target.GetType().GetProperty(propertyName)
            .GetValue(target) as IEnumerable<T>)!;

        var newValue = current.Concat(value).ToList();
        
        target.TestForceSetProperty(propertyName, newValue);
    }
    
    public static void TestForceAddToCollection<T>(
        this IEnumerable<T> col, 
        params T[] value)
    {
        if (col is ICollection<T> cast)
        {
            foreach (var t in value)
            {
                cast.Add(t);
            }

            return;
        }

        throw new InvalidOperationException("Can't add to collection because the supplied collection does not have an add method.");
    }
}