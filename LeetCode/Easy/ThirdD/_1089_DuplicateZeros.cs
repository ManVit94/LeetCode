namespace LeetCode.Easy.ThirdD;

public class DuplicateZeros
{
    [Fact]
    public void DuplicateZerosTest()
    {
        foreach (var testData in GetTestData())
        {
            DuplicateZerosCalculate(testData.Input);
            Assert.Equal(testData.Output, testData.Input);
        }
    }

    private void DuplicateZerosCalculate(int[] arr)
    {
        List<int> list = new List<int>();
        foreach (var t in arr)
        {
            if (t == 0)
            {
                list.Add(0);
                list.Add(0);
            }
            else
            {
                list.Add(t);
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = list[i];
        }
    }

    private IEnumerable<(int[] Input, int[] Output)> GetTestData()
    {
        yield return ([1, 0, 2, 3, 0, 4, 5, 0], [1, 0, 0, 2, 3, 0, 0, 4]);
        yield return ([1, 2, 3], [1, 2, 3]);
    }
}