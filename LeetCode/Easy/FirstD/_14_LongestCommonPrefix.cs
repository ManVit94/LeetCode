using System.Text;

namespace LeetCode.Easy.FirstD;

public class LongestCommonPrefix
{
    [Fact]
    public void LongestCommonPrefixTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = FindLongestCommonPrefix(testData.Strs);
            Assert.Equal(testData.LongestPrefix, result);
        }
    }

    private static string FindLongestCommonPrefix(string[] strs)
    {
        var result = new StringBuilder(strs[0]);

        for (int i = 1; i < strs.Length; i++)
        {
            while (!strs[i].StartsWith(result.ToString()))
            {
                result.Remove(result.Length - 1, 1);
                if (result.Length == 0) break;
            }
        }

        return result.ToString();
    }

    private static IEnumerable<(string[] Strs, string LongestPrefix)> GetTestData()
    {
        yield return (new[] { "abab", "aba", "" }, string.Empty);
        yield return (new[] { "aaa", "aa", "aaa" }, "aa");
        yield return (new[] { "flower", "flow", "flight" }, "fl");
        yield return (new[] { "dog", "racecar", "car" }, string.Empty);
        yield return (new[] { "reflower", "flow", "flight" }, string.Empty);
        yield return (new[] { "a" }, "a");
        yield return (new[] { "flower", "flower", "flower", "flower" }, "flower");
    }
}