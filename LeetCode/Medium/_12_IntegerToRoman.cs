using System.Text;

namespace LeetCode.Medium;

public class IntegerToRoman
{
    [Theory]
    [InlineData(3, "III")]
    [InlineData(10, "X")]
    [InlineData(20, "XX")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void IntegerToRomanTest(int num, string rom)
    {
        var result = IntToRoman(num);

        Assert.Equal(rom, result);
    }

    private string IntToRoman(int num)
    {
        var result = new StringBuilder();
        var intToRoman = new Dictionary<int, string>()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        // while (num != 0)
        // {
        //     foreach (var number in intToRoman)
        //     {
        //         if (num >= number.Key)
        //         {
        //             result.Append(number.Value);
        //             num -= number.Key;
        //
        //             if (num >= number.Key)
        //             {
        //                 result.Append(number.Value);
        //                 num -= number.Key;
        //
        //                 if (num >= number.Key)
        //                 {
        //                     result.Append(number.Value);
        //                     num -= number.Key;
        //                 }
        //             }
        //         }
        //     }
        // }

        foreach (var numbers in intToRoman)
        {
            //if (num <= 0 )break;
            for (int i = 0; i < 3; i++)
            {
                if (num >= numbers.Key)
                {
                    result.Append(numbers.Value);
                    num -= numbers.Key;
                }
                else
                    break;
            }
            
        }

        return result.ToString();
    }
}