
using LeetCode.Models;

namespace LeetCode
{

    class Program {


        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2, new ListNode(4, new Models.ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new Models.ListNode(4)));


            ListNode answer = ProblemLibrary.AddTwoNumbers(l1, l2);

            


        }
    }



}
