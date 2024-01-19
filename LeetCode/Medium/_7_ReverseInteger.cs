namespace LeetCode.Medium;

public class ReverseInteger
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    public void ReverseIntegerTest(int x, int reversed)
    {
        var actual = Reverse(x);
        
        Assert.Equal(reversed, actual);
    }

    private int Reverse(int x)
    {
        long result = 0;

        while (x != 0)
        {
            result = result * 10 + x % 10;

            x /= 10;

            if (result > int.MaxValue || result < int.MinValue)
                return 0;
        }

        return (int)result;
    }
}