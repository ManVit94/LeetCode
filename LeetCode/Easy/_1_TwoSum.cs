namespace LeetCode.Easy;

public class TwoSum
{
    [Fact]
    public void TwoSumTest()
    {
        var testDataSeq = GetTestData();

        foreach (var testData in testDataSeq)
        {
            var calculated = CalculateTwoSumEnhanced(testData.Nums, testData.Target);

            Assert.Equal(testData.Output, calculated);
        }
    }

    /// <summary>
    /// My own solution from scratch with no tips.
    /// </summary>
    private static int[] CalculateTwoSum(int[] nums, int target)
    {
        int indx1 = 0, indx2 = 0;
        bool found = false;

        for (int i = 0; (i < nums.Length && !found); i++)
        {
            indx1 = i;

            for (int j = 0; j < nums.Length; j++)
            {
                indx2 = j;
                if (indx1 == indx2) continue;
                if (nums[indx1] + nums[indx2] != target) continue;
                found = true;
                break;
            }
        }
        
        return new[] { indx1, indx2 };
    }
    
    /// <summary>
    /// With small tip
    /// </summary>
    private static int[] CalculateTwoSumEnhanced(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (int i = 0; (i < nums.Length); i++)
        {
            var diff = target - nums[i];

            if (dictionary.TryGetValue(diff, out var value))
                return new[] { value, i };

            if (!dictionary.ContainsKey(nums[i]))
                dictionary.Add(nums[i], i);
        }

        return Array.Empty<int>();
    }

    private static IEnumerable<(int[] Nums, int Target, int[] Output)> GetTestData()
    {
        yield return (new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 });
        yield return (new[] { 3, 2, 4 }, 6, new[] { 1, 2 });
        yield return (new[] { 3, 3 }, 6, new[] { 0, 1 });
    }
}