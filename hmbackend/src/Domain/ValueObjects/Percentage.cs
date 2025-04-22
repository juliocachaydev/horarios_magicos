using Domain.Exceptions;

namespace Domain.ValueObjects;

public record Percentage
{
    public decimal Numerator { get; }
    public decimal Denominator { get; }
    
    public decimal Value => Math.Round(Numerator / Denominator * 100, 2);

    public override string ToString()
    {
        return $"{Value:F2}%";
    }

    public Percentage(decimal numerator, decimal denominator)
    {
        if (denominator == 0)
        {
            throw new InvalidEntityStateException("Denominator cannot be zero.");
        }
        Numerator = numerator;
        Denominator = denominator;
    }
    
    
}