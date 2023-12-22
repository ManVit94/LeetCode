namespace LeetCode.Common;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
    
    public override bool Equals(object obj)
    {
        // Check for null and compare run-time types.
        if (obj == null || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        
        ListNode node = (ListNode)obj;
        return (val == node.val) && (next == null && node.next == null || next.Equals(node.next));
    }

    public override int GetHashCode()
    {
        // Hash code should include all the fields used in the Equals method
        int hash = 17;
        hash = hash * 31 + val.GetHashCode();
        hash = hash * 31 + (next?.GetHashCode() ?? 0);
        return hash;
    }
}