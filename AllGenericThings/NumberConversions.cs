namespace AllGenericThings;

public class NumberConversions
{
    [Fact]
    public void LongToDecimal()
    {
        var longNumber = long.MaxValue - 1;

        var decimalValue = (decimal)longNumber;
        var longValue = (long)decimalValue;
        // System.Diagnostics.Tracing.Trace.WriteLine("testez");
        Assert.True(longNumber == longValue);
    }
}