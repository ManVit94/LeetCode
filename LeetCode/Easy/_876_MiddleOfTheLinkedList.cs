using LeetCode.Common;

namespace LeetCode.Easy;

public class MiddleOfTheLinkedList
{
    [Fact]
    public void MiddleOfTheLinkedListTest()
    {
        foreach (var testData in GetTestData())
        {
            var result = MiddleNodeEnhanced(testData.Head);
            Assert.Equal(testData.Middle, result);
        }
    }

    private ListNode MiddleNode(ListNode head)
    {
        var nodeLenght = 1;
        var pntrNode = head;

        while (pntrNode.next != null)
        {
            pntrNode = pntrNode.next;
            nodeLenght++;
        }

        pntrNode = head;
        int i = 1;

        if (nodeLenght % 2 == 0)
        {
            while (i != (nodeLenght / 2) + 1)
            {
                pntrNode = pntrNode.next;
                i++;
            }
        }
        else
        {
            while (i != (nodeLenght + 1) / 2)
            {
                pntrNode = pntrNode.next;
                i++;
            }
        }

        return pntrNode;
    }

    private ListNode MiddleNodeEnhanced(ListNode head)
    {
        ListNode middle = head;
        ListNode end = head;

        while (end != null && end.next != null)
        {
            middle = middle.next;
            end = end.next.next;
        }

        return middle;
    }

    private static IEnumerable<(ListNode Head, ListNode Middle)> GetTestData()
    {
        yield return (ListNode.GenerateNode(new[] { 1, 2, 3, 4, 5 }), ListNode.GenerateNode(new[] { 3, 4, 5 }));
        yield return (ListNode.GenerateNode(new[] { 1, 2, 3, 4, 5, 6 }), ListNode.GenerateNode(new[] { 4, 5, 6 }));
    }
}