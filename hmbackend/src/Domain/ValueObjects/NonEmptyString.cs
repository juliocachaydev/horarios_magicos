using Domain.Exceptions;

namespace Domain.ValueObjects;

public class NonEmptyString
: IEquatable<NonEmptyString>
{
    public string Value { get; }
    
    public NonEmptyString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidEntityStateException("Value is required");
        }

        Value = value.Trim();
    }

    public override string ToString()
    {
        return Value;
    }


    public bool Equals(NonEmptyString? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Value, other.Value, StringComparison.InvariantCultureIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((NonEmptyString)obj);
    }

    public override int GetHashCode()
    {
        return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Value);
    }

    public static bool operator ==(NonEmptyString? left, NonEmptyString? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(NonEmptyString? left, NonEmptyString? right)
    {
        return !Equals(left, right);
    }

    public static NonEmptyString Random => new(Guid.NewGuid().ToString());
}