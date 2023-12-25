namespace LeetCode.Easy.ThirdD;

public class FindNumbersWithEvenNumberOfDigits
{
    [Fact]
    public void FindNumbersWithEvenNumberOfDigitsTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = FindNumbers(testData.Nums);
            
            Assert.Equal(result, testData.EvenCnount);
        }
    }

    private int FindNumbers(int[] nums)
    {
        return nums.Count(n => n.ToString().Length % 2 == 0);
    }

    private IEnumerable<(int[] Nums, int EvenCnount)> GetTestData()
    {
        yield return ([12, 345, 2, 6, 7896], 2);
        yield return ([555, 901, 482, 1771], 1);
    }
}