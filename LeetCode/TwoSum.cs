namespace LeetCode;

public class TwoSum
{
    [Fact]
    public void Test1()
    {
        var testDataSeq = GetTestData();

        foreach (var testData in testDataSeq)
        {
            var calculated = CalculateTwoSum(testData.Nums, testData.Target);

            Assert.Equal(testData.Output, calculated);
        }
    }

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

    private static IEnumerable<(int[] Nums, int Target, int[] Output)> GetTestData()
    {
        yield return (new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 });
        yield return (new[] { 3, 2, 4 }, 6, new[] { 1, 2 });
        yield return (new[] { 3, 3 }, 6, new[] { 0, 1 });
    }
}