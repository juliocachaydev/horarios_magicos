namespace Domain.Exceptions;

/// <summary>
/// A domain invariant was broken or an invalid value was passed to a domain object
/// </summary>
public class InvalidEntityStateException : DomainException
{
    public InvalidEntityStateException(string message) : base(message)
    {
    }

    public InvalidEntityStateException() : base("")
    {
        
    }
}