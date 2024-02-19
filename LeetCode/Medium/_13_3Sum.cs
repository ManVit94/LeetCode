namespace LeetCode.Medium;

public class ThreeSum
{
    [Fact]
    public void ThreeSumTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = CalculateThreeSum(testData.Input);

            Assert.Equal(testData.Output, result);
        }
    }

    private IList<IList<int>> CalculateThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);

        int low, high = 0;
        int currentI = Int32.MinValue;
        int zeroCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) break;
            if (nums[i] == 0) zeroCount++;
            if (currentI == nums[i]) continue;
            currentI = nums[i];
            low = i + 1;
            high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[i] + nums[low] + nums[high];
                if (sum == 0)
                {
                    result.Add([nums[i], nums[low], nums[high]]);
                    low++;
                    high--;
                    while (low < high && nums[low] == nums[low - 1])
                        low++;
                    while (low < high && nums[low] == nums[low - 1])
                        high++;
                }

                if (sum < 0)
                    low++;

                if (sum > 0)
                    high--;
            }
        }

        return result;
    }

    private IEnumerable<(int[] Input, IList<IList<int>> Output)> GetTestData()
    {
         yield return ([-1, 0, 1, 2, -1, -4], [[-1, -1, 2], [-1, 0, 1]]);
         yield return ([0, 1, 1], []);
         yield return ([-1,0,1], [[-1,0,1]]);
         yield return ([0, 0, 0], [[0, 0, 0]]);
         yield return ([0, 0, 0, 0, 0, 0], [[0, 0, 0]]);
         yield return ([-2, 0, 0, 2, 2], [[-2, 0, 2]]);
         yield return ([-1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4],
             [[-4, 0, 4], [-4, 1, 3], [-3, -1, 4], [-3, 0, 3], [-3, 1, 2], [-2, -1, 3], [-2, 0, 2], [-1, -1, 2], [-1, 0, 1]]);
    }
}