namespace LeetCode.Easy;

public class MaxConsecutiveOnes
{
    [Fact]
    public void MaxConsecutiveOnesTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = FindMaxConsecutiveOnes(testData.Nums);
            Assert.Equal(testData.Max, result);
        }
    }

    private int FindMaxConsecutiveOnes(int[] nums)
    {
        int absMax = 0;
        int currentMax = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                currentMax++;
                absMax = Math.Max(absMax, currentMax);
            }
            else
            {
                currentMax = 0;
            }
        }

        return absMax;
    }

    private IEnumerable<(int[] Nums, int Max)> GetTestData()
    {
        yield return ([1, 1, 0, 1, 1, 1], 3);
        yield return ([1, 0, 1, 1, 0, 1], 2);
    }
}