namespace LeetCode.Easy;

public class RomanToInteger
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToIntegerTest(string s, int number)
    {
        var result = ConvertToInt(s);

        Assert.Equal(number, result);
    }

    private static int ConvertToInt(string s)
    {
        return 1;
    }
}