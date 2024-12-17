using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _5_LongestPalindrome
    {
        public static string LongestPalindrome(string s)
        {
            string answer = "";
            int left = 0;
            int right = 1;
            int target = 0;
            bool skipLoop = false;
            bool checkDoubles = true;
            bool checkOdds = false;
            int evenLength = 0;
            int oddLength = 0;
            int[] subIndexes = new int[2];

            //Check if string is only one character
            if (s.Length == 1)
            {
                answer = s[0].ToString();
                skipLoop = true;
            }
            else if (s.Length == 2)
            {
                if (s[0] == s[1]) { answer = s[0].ToString() + s[1].ToString(); }
                else { answer = s[0].ToString(); }
                skipLoop = true;
            }

            while (!skipLoop)
            {
                while (checkDoubles)
                {
                    while (s[left] == s[right])
                    {
                        if (right - left > evenLength)
                        {
                            evenLength = right - left;
                            subIndexes[0] = left;
                            subIndexes[1] = right;
                        }

                        if (evenLength != s.Length - 1)
                        {
                            if (left != 0) { left--; } //extend left if possible
                            if (right != s.Length - 1) { right++; } //extend right if possible
                        }
                        else
                        {
                            checkOdds = false;
                            checkDoubles = false;
                            break;
                        }
                    }
                    if (right != s.Length - 1)
                    {
                        target++;
                        left = target;
                        right = left + 1;
                    }
                    else
                    {
                        checkDoubles = false;
                        checkOdds = true;
                    }
                }
                //reset index variables. If doubles found a palindrome of length 5. No need
                //to start at the beginning since anything found would be less than 5
                if (evenLength / 2 > 0)
                {
                    target = evenLength / 2;
                    left = target - 1;
                    right = target + 1;
                }
                else
                {
                    left = 0;
                    target = 1;
                    right = 2;
                }

                while (checkOdds)
                {
                    if (s[left] == s[right])
                    {
                        if (right - left >= oddLength)
                        {
                            oddLength = right - left;
                            if (oddLength >= evenLength)
                            {
                                subIndexes[0] = left;
                                subIndexes[1] = right;
                            }
                        }
                        if (!(left == 0 || right == s.Length - 1))
                        {
                            left--;
                            right++;
                        }
                        else if (oddLength == s.Length - 1)
                        {
                            checkOdds = false;
                            skipLoop = true;
                        }
                        else if (right == s.Length - 1)
                        {
                            checkOdds = false;
                            skipLoop = true;
                        }
                        else
                        {
                            target++;
                            left = target - 1;
                            right = target + 1;
                        }
                    }
                    else if (target != s.Length - 2)
                    {
                        target++;
                        left = target - 1;
                        right = target + 1;
                    }
                    else
                    {
                        checkOdds = false;
                        skipLoop = true;
                    }
                }

                if (evenLength >= oddLength) { return s.Substring(subIndexes[0], evenLength + 1); }
                else { return s.Substring(subIndexes[0], oddLength + 1); }
            }
            return answer;


        }


    }
}
