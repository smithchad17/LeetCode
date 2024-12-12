using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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

    public static int LengthOfLongestSubstring(string s)
    {
        /*BETTER SOLUTION
         * var charSet = new HashSet<char>();
        int left = 0, maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left++]);
            }

            charSet.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
         * */


        //s = abcabcbb
        //int[] v = myarr.Select((b, i) => b == "s" ? i : -1).Where(i => i != -1).ToArray(); //Find indexes of characters
        int stringLength = 0;
        char[] charArray;

        charArray = s.ToCharArray();

        //This is the max limit substring, but does it exist?
        var distinctArray = charArray.Distinct().ToArray();
        int maxLimit = distinctArray.Length;

        if (maxLimit == 1)
        {
            stringLength = 1;
        }
        else if (maxLimit == charArray.Length)
        {
            stringLength = maxLimit;
        }
        else if (maxLimit > 1)
        {
            int begIndex = 0;
            int endIndex = 1;
            int scanIndex = endIndex - begIndex;

            while (endIndex <= charArray.Length) 
            {
                string tempSubString;

                if (endIndex == charArray.Length)
                {
                    tempSubString = s.Substring(begIndex); //beginning index until end of string
                }
                else
                {
                    tempSubString = s.Substring(begIndex, scanIndex); //beginning index, length of scan
                }

                var tempArray = tempSubString.Distinct().ToArray().Length;
                var subLength = tempSubString.Length;

                //
                if (subLength == tempArray && stringLength < subLength)
                {
                    endIndex++;
                    stringLength = subLength;
                    scanIndex = endIndex - begIndex;
                }
                if (subLength != tempArray)
                {
                    begIndex++;
                    endIndex++;
                    scanIndex = endIndex - begIndex;
                }

            }


        }

        return stringLength;
    }
}