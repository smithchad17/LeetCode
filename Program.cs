
using LeetCode.Models;
using LeetCode.Problems;

namespace LeetCode
{

    class Program {


        static void Main(string[] args)
        {

            string s = "ABCD";
            int numRows = 3;
            
            var answer = _6_Convert.Convert(s,numRows);

            Console.WriteLine(answer);

        }
    }



}
