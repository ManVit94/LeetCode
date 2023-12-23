namespace LeetCode.Common;

public class ListNode
{
    public int val;
    public ListNode next;

    private ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override bool Equals(object obj)
    {
        try
        {
            // Check for null and compare run-time types.
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            ListNode node = (ListNode)obj;
            return (val == node.val) && (next == null && node.next == null || next.Equals(node.next));
        }
        catch (Exception)
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        // Hash code should include all the fields used in the Equals method
        int hash = 17;
        hash = hash * 31 + val.GetHashCode();
        hash = hash * 31 + (next?.GetHashCode() ?? 0);
        return hash;
    }

    public static ListNode GenerateNode(int[] values)
    {
        var head = new ListNode(values[0]);

        for (int i = 1; i < values.Length; i++)
        {
            var lastNode = FindLast(head);
            lastNode.next = new ListNode(values[i]);
        }

        return head;
    }

    private static ListNode FindLast(ListNode node)
        => node.next == null ? node : FindLast(node.next);
}