namespace LeetCode.Easy.FourthD;

public class RichestCustomerWealth
{
    [Fact]
    public void RichestCustomerWealthTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = MaximumWealth(testData.Accounts);
            Assert.Equal(testData.Wealth, result);
        }
    }

    private int MaximumWealth(int[][] accounts)
    {
        return accounts.Select(x => x.Sum()).OrderByDescending(x => x).FirstOrDefault();
    }

    private IEnumerable<(int[][] Accounts, int Wealth)> GetTestData()
    {
        yield return (new int[][] { [1, 2, 3], [3, 2, 1] }, 6);
        yield return (new int[][] { [1, 5], [7, 3], [3, 5] }, 10);
        yield return (new int[][] { [2, 8, 7], [7, 1, 3], [1, 9, 5] }, 17);
    }
}