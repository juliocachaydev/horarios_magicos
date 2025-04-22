using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects;

public class PercentageTests
{
    [Theory]
    [InlineData(25,50,50,"50.00%")]
    [InlineData(25,25,100,"100.00%")]
    [InlineData(50,25,200,"200.00%")]
    public void CanCreate(
        decimal numerator, decimal denominator, decimal expectedValue, string expectedStr)
    {
        // ***** ARRANGE *****

        // ***** ACT *****
        
        var sut = new Percentage(numerator, denominator);

        // ***** ASSERT *****

        Assert.Equal(expectedValue, sut.Value);
        Assert.Equal(expectedStr, sut.ToString());
    }

    [Fact]
    public void AssertsDenominatorNotThanZero()
    {
        // ***** ARRANGE *****

        // ***** ACT *****
        
        var result = Record.Exception(() => new Percentage(100, 0));

        // ***** ASSERT *****
        
        Assert.NotNull(result);
    }
}