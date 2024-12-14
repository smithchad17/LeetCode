
using LeetCode.Models;

namespace LeetCode
{

    class Program {


        static void Main(string[] args)
        {

            //string s = "babad";
            string s = "ccc";
            //string s = "aaabbbbbbbbbbc";
            //string s = "bacabab";
            //string s = "babaddtattarrattatddetartrateedredividerb";
            //string s = "aba";
            //string s = "caba";
            //string s = "abb";
            //string s = "a";
            //string s = "ac";
            //string s = "aaaa";
            //string s = "cbbd";

            var answer = ProblemLibrary.LongestPalindrome(s);

            Console.WriteLine(answer);

        }
    }



}
