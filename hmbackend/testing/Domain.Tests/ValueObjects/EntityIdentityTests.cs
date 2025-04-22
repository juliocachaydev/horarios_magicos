using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects;

public class EntityIdentityTests
{
    [Fact]
    public void AssertsValueNotEmpty()
    {
        // ************ ARRANGE ************

        // ************ ACT ************

        var result = Record.Exception(() => new EntityIdentity(Guid.Empty));
        
        // ************ ASSERT ************

        Assert.NotNull(result);
        Assert.IsType<InvalidEntityStateException>(result);
    }

    [Fact]
    public void SetsValue()
    {
        // ************ ARRANGE ************

        var value = Guid.NewGuid();
        
        // ************ ACT ************

        var sut = new EntityIdentity(value);
        
        // ************ ASSERT ************

        Assert.Equal(value, sut.Value);
    }

    
}