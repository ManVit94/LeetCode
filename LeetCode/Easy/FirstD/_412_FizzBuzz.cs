namespace LeetCode.Easy.FirstD;

public class FizzBuzz
{
    [Fact]
    public void FizzBuzzTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = CheckFizzBuzz(testData.N);
            Assert.Equal(testData.FizzBuzz, result);
        }
    }

    private IEnumerable<string> CheckFizzBuzz(int n)
    {
        string[] arr = new string[n];
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0)
                arr[i-1] += "Fizz";
            
            if (i % 5 == 0)
                arr[i-1] += "Buzz";

            if (string.IsNullOrEmpty(arr[i-1])) arr[i-1] = i.ToString();
        }

        return arr;
    }

    private IEnumerable<(int N, string[] FizzBuzz)> GetTestData()
    {
        yield return (3, new[] { "1", "2", "Fizz" });
        yield return (5, new[] { "1", "2", "Fizz", "4", "Buzz" });
        yield return (15, new[] { "1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" });
    }
}