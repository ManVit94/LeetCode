namespace LeetCode.Easy.FirstD;

public class PalindromeNumber
{
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    public void PalindromeNumberTest(int x, bool isPalindrome)
    {
        var calculated = IsPalindrome(x);
        
        Assert.Equal(calculated, isPalindrome);
    }

    private static bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        var charX = x.ToString().ToCharArray();
        Array.Reverse(charX);
        return x.ToString() == new string(charX);
    }
}