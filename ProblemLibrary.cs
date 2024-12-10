using System;
using System.Collections.Generic;
using System.Xml.Linq;
using LeetCode.Models;

namespace LeetCode;

public static class ProblemLibrary
{
    public static int[] TwoSum(int[] nums, int target)
    {
        // CONSTRAINTS
        // 2 <= nums.length <= 104
        // 10^9 <= nums[i] <= 10^99
        // -10^9 <= target <= 10^9

        int x;
        Dictionary<int, int> previous = new Dictionary<int, int>(); //number, index
        previous.Add(nums[0], 0); //Hold previous numbers in a dictionary hashtable for faster lookup
        int[] answer = new int[2];

        for (int i = 1; i < nums.Length; i++)
        {

            x = target - nums[i];
            //If solution is already in the dictionary, grab the index
            if (previous.ContainsKey(x))
            {
                answer = [previous[x], i];
            }

            if (!previous.ContainsKey(nums[i]))//Add the number to the dictionary and continued
            {
                previous.Add(nums[i], i);
            }
        }

        return answer;
    }

    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //CONTRAINTS
        // The number of nodes in each linked list is in the range[1, 100].
        // 0 <= Node.val <= 9
        // It is guaranteed that the list represents a number that does not have leading zeros.

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