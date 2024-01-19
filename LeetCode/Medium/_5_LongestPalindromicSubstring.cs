namespace LeetCode.Medium;

public class LongestPalindromicSubstring
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("a", "a")]
    [InlineData("ab", "a")]
    [InlineData("abb", "bb")]
    [InlineData("cccdd", "ccc")]
    [InlineData("abbajj", "abba")]
    [InlineData("racecar", "racecar")]
    [InlineData("aa", "aa")]
    [InlineData("aacabdkacaa", "aca")]
    [InlineData("aaad", "aaa")]
    [InlineData("abcda", "a")]
    public void LongestPalindromicSubstringTest(string s, string expected)
    {
        var actual = LongestPalindrome(s);
        Assert.Equal(expected, actual);
    }

    private string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;
        if (s.Length == 2 && s[0] != s[1]) return s[0].ToString();

        int currentLength = 0;
        int longestStart = 0;
        int absLongestLenght = 1;

        for (int center = 0; center < s.Length; center++)
        {
            bool shiftCurrentRight = false;
            for (int radius = 1;; radius++)
            {
                bool isFirstElement = center == 0;
                bool isLastElement = center == s.Length - 1;

                int currentLeft = isFirstElement ? 0 : center - radius;
                int currentRight = isLastElement ? s.Length - 1 : center + radius;

                if (shiftCurrentRight)
                {
                    currentRight++;
                }

                currentLength = currentRight - currentLeft + 1;

                if (currentLeft < 0 || currentRight >= s.Length)
                    break;

                if (s[currentLeft] != s[currentRight])
                {
                    if (!isLastElement && s[center] == s[center + 1] && !shiftCurrentRight)
                    {
                        shiftCurrentRight = true;
                        radius = 0;
                        currentLength = 2;
                        currentLeft = center;
                    }
                    else
                        break;
                }

                if (currentLength > absLongestLenght)
                {
                    longestStart = currentLeft;
                    absLongestLenght = currentLength;
                }
            }
        }

        return s.Substring(longestStart, absLongestLenght);
    }
}