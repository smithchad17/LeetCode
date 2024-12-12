
using LeetCode.Models;

namespace LeetCode
{

    class Program {


        static void Main(string[] args)
        {

            string s = "abcabcbb";

            var answer = ProblemLibrary.LengthOfLongestSubstring(s);

            Console.WriteLine(answer);

        }
    }



}
