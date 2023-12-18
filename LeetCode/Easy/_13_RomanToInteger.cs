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
        var romanToInt = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        int sum = 0;

        var cArr = s.ToCharArray();
        for (int i = 0; i < cArr.Length; i++)
        {
            if (i == cArr.Length - 1)
            {
                sum += romanToInt[cArr[i]];
                break;
            }

            if (cArr[i] == 'I' && cArr[i + 1] == 'V')
            {
                sum += 4;
                i++;
                continue;
            }
            
            if (cArr[i] == 'I' && cArr[i + 1] == 'X')
            {
                sum += 9;
                i++;
                continue;
            }
            
            if (cArr[i] == 'X' && cArr[i + 1] == 'L')
            {
                sum += 40;
                i++;
                continue;
            }
            
            if (cArr[i] == 'X' && cArr[i + 1] == 'C')
            {
                sum += 90;
                i++;
                continue;
            }
            
            if (cArr[i] == 'C' && cArr[i + 1] == 'D')
            {
                sum += 400;
                i++;
                continue;
            }
            
            if (cArr[i] == 'C' && cArr[i + 1] == 'M')
            {
                sum += 900;
                i++;
                continue;
            }
            
            sum += romanToInt[cArr[i]];
        }

        return sum;
    }
}