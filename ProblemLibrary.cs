using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Tar;
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

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int num1Length = nums1.Length;
        int num2Length = nums2.Length;
        double median = (num1Length + num2Length) / 2.0;
        int ceiling = 0;

        if ((num1Length + num2Length) % 2 == 0)
        {
            ceiling = (int)Math.Ceiling(median) + 1;
        }
        else
        {
            ceiling = (int)Math.Ceiling(median);
        }

        int[] mainArray = new int[ceiling];
        int a = 0;
        int b = 0;
        int c = 0;

        while (c < ceiling)
        {
            if (a < num1Length && b < num2Length)
            {
                if (nums1[a] < nums2[b])
                {
                    mainArray[c] = nums1[a];
                    a++;
                    c++;
                }
                else
                {
                    mainArray[c] = nums2[b];
                    c++;
                    b++;
                }
            }
            else if (a < num1Length && b == num2Length)
            {
                mainArray[c] = nums1[a];
                a++;
                c++;
            }
            else if (a == num1Length && b < num2Length)
            {
                mainArray[c] = nums2[b];
                c++;
                b++;
            }
        }

        if ((num1Length + num2Length) % 2 == 0)
        {
            return ((mainArray[ceiling - 1] + mainArray[ceiling - 2]) / 2.0);
        }
        else
        {
            return mainArray[ceiling - 1];
        }

    }

    public static string LongestPalindrome(string s)
    {
        bool moveTarget = false;
        bool canExit = false;
        bool good = true;
        int before = 0;
        int target = 1;
        int evenTarget;
        int after = 2;
        int[] palIndexes = new int[2]; //hold the beginning and end indexes for the palindrome
        int palLength = 0;
        string pal = "";

        if (s.Length ==1)
        {
            good = false;
            pal = s[0].ToString();
        }
        else if (s.Length == 2 && (s[0] == s[1])){
            good = false;
            pal = s[0].ToString() + s[1].ToString();
        }
        else if (s.Length == 2 && (s[0] != s[1]))
        {
            good = false;
            pal = s[0].ToString();
        }

        while (good)
        {
            //Check if palindrome is a even or odd string
            if (s[before] == s[after] && s.Length > 2)
            {
                while (!canExit)
                {
                    palIndexes[0] = before;
                    palIndexes[1] = after;
                    palLength = after - before;
                    if (before == 0 || after == s.Length - 1)
                    {
                        moveTarget = true;
                        canExit = true;

                    }
                    else
                    {
                        before--;
                        after++;
                        if (s[before] != s[after])
                        {
                            canExit = true;
                            moveTarget = true;
                        }
                    }
                }
                before = target - 1;
                after = target + 1;
                canExit = false;
            }
            else if (s[before] == s[target])
            {
                evenTarget = target;
                while (!canExit)
                {
                    palIndexes[0] = before;
                    palIndexes[1] = evenTarget;
                    palLength = evenTarget - before;
                    if (before == 0 || evenTarget == s.Length - 1)
                    {
                        moveTarget = true;
                        canExit = true;
                    }
                    else
                    {
                        before--;
                        evenTarget++;
                        if (s[before] != s[evenTarget])
                        {
                            canExit = true;
                            moveTarget = true;
                        }
                    }
                }
            }
            else 
            {
                target++;
                before = target - 1;
                after = target + 1;
                moveTarget = false;
                canExit = false;
            }

            if (moveTarget)
            {
                target++;
                before = target - 1;
                after = target + 1;
                moveTarget = false;
                canExit = false;
            }

            pal = s.Substring(palIndexes[0], palLength + 1);
            if (after >= s.Length) { break; }

        }

        if (good)
        {
            return pal;
        }
        else
        {
            return pal;
        }

    }
}