using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _1_TwoSum
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
    }
}
