using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _3_LengthOfLongestSubstring
    {
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
}
