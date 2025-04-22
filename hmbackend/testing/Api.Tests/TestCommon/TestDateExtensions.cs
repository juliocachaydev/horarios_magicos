namespace Application.Tests.TestCommon;

public static class TestDateExtensions
{
    public static bool IsAlmostNow(this DateTime dateTime)
    {
        var diff = (DateTime.UtcNow - dateTime).Milliseconds;

        return Math.Abs(diff) < 1000;
    }
}