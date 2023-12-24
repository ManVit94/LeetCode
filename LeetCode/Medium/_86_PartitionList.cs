using LeetCode.Common;

namespace LeetCode.Medium;

public class PartitionList
{
    [Fact]
    public void PartitionListTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = Partition(testData.Head, testData.X);

            Assert.Equal(testData.Middle, result);
        }
    }

    public ListNode Partition(ListNode head, int x)
    {
        ListNode current = head;
        ListNode newHead = null;
        ListNode lastSmaller = null;
        ListNode previous = null;

        void MakeCycle()
        {
            previous = current;
            current = current.next;
        }

        while (current != null)
        {
            if (current.val < x)
            {
                if (previous == null)
                {
                    newHead = current;
                    lastSmaller = current;
                    MakeCycle();
                    continue;
                }

                if (lastSmaller == null)
                {
                    lastSmaller = current;
                    newHead = current;
                    previous.next = current.next;
                    current.next = head;
                    MakeCycle();
                    continue;
                }

                previous.next = current.next;
                current.next = lastSmaller.next;
                lastSmaller.next = current;
                lastSmaller = current;
            }

            MakeCycle();
        }

        return newHead ?? head;
    }

    private static IEnumerable<(ListNode Head, ListNode Middle, int X)> GetTestData()
    {
        yield return (ListNode.GenerateNode([1, 4, 3, 2, 5, 2]), ListNode.GenerateNode([1, 2, 2, 4, 3, 5]), 3);
        yield return (ListNode.GenerateNode([2, 1]), ListNode.GenerateNode([1, 2]), 2);
        yield return (ListNode.GenerateNode([6]), ListNode.GenerateNode([6]), 3);
        yield return (ListNode.GenerateNode([6]), ListNode.GenerateNode([6]), 8);
        yield return (ListNode.GenerateNode([6, 5, 4]), ListNode.GenerateNode([6, 5, 4]), 4);
        yield return (ListNode.GenerateNode([12, 8, 6, 10]), ListNode.GenerateNode([6, 12, 8, 10]), 8);
        yield return (ListNode.GenerateNode([6, 12, 24, 4, 5, 1, 4, 8, 5, 5]), ListNode.GenerateNode([6, 4, 5, 1, 4, 8, 5, 5, 12, 24]), 10);
    }
}