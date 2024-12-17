using LeetCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _2_AddTwoNumbers
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //CONTRAINTS
            // The number of nodes in each linked list is in the range[1, 100].
            // 0 <= Node.val <= 9
            // It is guaranteed that the list represents a number that does not have leading zeros.

            //Test Data
            //ListNode l1 = new ListNode(2, new ListNode(4, new Models.ListNode(3)));
            //ListNode l2 = new ListNode(5, new ListNode(6, new Models.ListNode(4)));

            ListNode head = new ListNode();
            var pointer = head;
            int curval = 0;
            while (l1 != null || l2 != null)
            {
                curval = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + curval;
                pointer.next = new ListNode(curval % 10);
                pointer = pointer.next;
                curval = curval / 10;
                Console.WriteLine("L1: " + l1.val);
                Console.WriteLine("L2: " + l2.val);
                l1 = l1?.next;
                l2 = l2?.next;
            }
            if (curval != 0)
            {
                pointer.next = new ListNode(curval);
            }
            return head.next;
        }

    }
}
