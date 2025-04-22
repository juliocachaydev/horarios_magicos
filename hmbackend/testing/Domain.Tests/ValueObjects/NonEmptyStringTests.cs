using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects;

public class NonEmptyStringTests
{
    [Theory]
    [InlineData("Test 123", false)]
    [InlineData(" ", true)]
    [InlineData(null, true)]
    public void AssertsValueNonNullNonEmpty(
        string value, bool shouldThrow)
    {
        // ************ ARRANGE ************

        // ************ ACT ************

        var result = Record.Exception(
            () => new NonEmptyString(value));

        // ************ ASSERT ************

        if (shouldThrow)
        {
            Assert.NotNull(result);
            Assert.IsType<InvalidEntityStateException>(result);
        }
        else
        {
            Assert.Null(result);
        }

    }


    [Theory]
    [InlineData("test 1", "test 1", true)]
    [InlineData("teST 1", "test 1", true)]
    [InlineData("test 1  ", "test 1", true)]
    [InlineData("   test 1", "test 1", true)]
    [InlineData("test 1", "test 2", false)]
    public void EqualityIsCaseInsensitive_IgnoresWhitespace(
        string value1, string value2, bool shouldMatch)
    {
        // ************ ARRANGE ************

        var sut1 = new NonEmptyString(value1);
        var sut2 = new NonEmptyString(value2);

        // ************ ACT ************

        var result = sut1 == sut2;
        
        // ************ ASSERT ************

        Assert.Equal(shouldMatch, result);
    }

    [Fact]
    public void ToString_ReturnsValue()
    {
        // ************ ARRANGE ************

        // ************ ACT ************

        var sut = new NonEmptyString("test 1");
        
        // ************ ASSERT ************

        Assert.Equal("test 1", sut.ToString());
    }

    
}