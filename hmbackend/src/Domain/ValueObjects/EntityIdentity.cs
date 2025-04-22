using Domain.Exceptions;

namespace Domain.ValueObjects;

public record EntityIdentity
{
    public Guid Value { get;}
    
    public EntityIdentity(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityStateException("Value is required");
        }

        Value = value;
    }

    public static EntityIdentity Random => new(Guid.NewGuid());

}