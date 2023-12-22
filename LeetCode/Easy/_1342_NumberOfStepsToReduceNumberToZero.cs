namespace LeetCode.Easy;

public class NumberOfStepsToReduceNumberToZero
{
    [Theory]
    [InlineData(14, 6)]
    [InlineData(8, 4)]
    [InlineData(123, 12)]
    public void NumberOfStepsToReduceNumberToZeroTest(int number, int stepsCount)
    {
        var result = NumberOfSteps(number);
        
        Assert.Equal(stepsCount, result);
    }

    private int NumberOfSteps(int num)
    {
        if (num == 0) return 0;
        int steps = 0;
        while (num != 0)
        {
            if (num % 2 == 0)
                num /= 2;
            else
                num -= 1;
            steps++;
        }

        return steps;
    }
}