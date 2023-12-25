namespace LeetCode.Medium;

public class ContainerWithMostWater
{
    [Fact]
    public void ContainerWithMostWaterTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = MaxArea(testData.Height);

            Assert.Equal(testData.Area, result);
        }
    }

    private int MaxArea(int[] height)
    {
        int maxArea = 0;
        int i = 0;
        int j = height.Length - 1;

        while (i < j)
        {
            var minHeight = Math.Min(height[i], height[j]);
            maxArea = Math.Max(maxArea, minHeight * (j-i));
            if (height[i] < height[j])
                i++;
            else j--;
        }

        return maxArea;
    }

    private IEnumerable<(int[] Height, int Area)> GetTestData()
    {
        yield return ([1, 8, 6, 2, 5, 4, 8, 3, 7], 49);
        yield return ([1, 1], 1);
        yield return ([1, 2, 1], 2);
        yield return ([4, 3, 2, 1, 4], 16);
        yield return ([1, 2, 4, 3], 4);
    }
}