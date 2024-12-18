using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems1_25;

public static class _7_ReverseInteger
{
    public static int Reverse(int x)
    {
        int revNum = 0;
        while (x > 0)
        {
            revNum = revNum * 10 + x % 10;
            x = x / 10;
        }
        return revNum;


        //string intToString = x.ToString();
        //StringBuilder sb = new StringBuilder();
        //int reverse;

        //if (x < 0) 
        //{
        //    //intToString = intToString.Substring(1);
        //    for (int i = intToString.Length - 1; i >= 1;  i--)
        //    {
        //        sb.Append(intToString[i]);
        //    }
        //    try 
        //    { 
        //        reverse = int.Parse(sb.ToString());
        //        reverse *= -1;
        //    }
        //    catch
        //    {
        //        reverse = 0;
        //    }


        //}
        //else
        //{
        //    for (int i = intToString.Length - 1; i >= 0; i--)
        //    {
        //        sb.Append(intToString[i]);
        //    }
        //    try
        //    {
        //        reverse = int.Parse(sb.ToString());
        //    }
        //    catch
        //    {
        //        reverse = 0;
        //    }
        //}

        ////Console.WriteLine(intToString);

        //return reverse;
    }
}
