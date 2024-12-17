using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _4_FindMedianSortedArrays
    {
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


    }
}
