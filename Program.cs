
using LeetCode.Models;

namespace LeetCode
{

    class Program {


        static void Main(string[] args)
        {

            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };

            var answer = ProblemLibrary.FindMedianSortedArrays(nums1, nums2);

            Console.WriteLine(answer);

        }
    }



}
