namespace LeetCode.Easy;

public class RunningSumOf1dArray
{
    [Fact]
    public void RunningSumOf1dArrayTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = RunningSum(testData.Nums);
            Assert.Equal(testData.RunningSum, result);
        }
    }

    private int[] RunningSum(int[] nums)
    {
        var sums = new int[nums.Length];
        sums[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i];
        }

        return sums;
    }

    private static IEnumerable<(int[] Nums, int[] RunningSum)> GetTestData()
    {
        yield return (new[] { 1, 2, 3, 4 }, new[] { 1, 3, 6, 10 });
        yield return (new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5 });
        yield return (new[] { 3, 1, 2, 10, 1 }, new[] { 3, 4, 6, 16, 17 });
    }
}