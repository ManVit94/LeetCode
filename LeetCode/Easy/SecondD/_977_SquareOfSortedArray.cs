namespace LeetCode.Easy.SecondD;

public class SquareOfSortedArray
{
    [Fact]
    public void SquareOfSortedArrayTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = SortedSquares(testData.Nums);

            Assert.Equal(testData.Sorted, result);
        }
    }

    private int[] SortedSquares(int[] nums)
    {
        return nums.Select(n => n * n).OrderBy(n => n).ToArray();
    }

    private IEnumerable<(int[] Nums, int[] Sorted)> GetTestData()
    {
        yield return ([-4, -1, 0, 3, 10], [0, 1, 9, 16, 100]);
        yield return ([-7, -3, 2, 3, 11], [4, 9, 9, 49, 121]);
    }
}