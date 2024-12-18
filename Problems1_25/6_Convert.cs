using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public static class _6_Convert
    {
        public static string Convert(string s, int numRows)
        {
            //PAYPALISHIRING length = 14
            //0 4 [11] 5 1 6 [12] 7 2 8 [13] 9 3 [10]   

            //numrows = 4
            int pointer = 0;
            int zigCols = numRows - 2; //zigzag characters are never in the first or last row
            char[] chars = s.ToCharArray();
            int rowNum = 1;
            string answer = "";
            bool skipLoop = false;
            bool prep = true;

            while (prep)
            {
                if (numRows == 1 || numRows == chars.Length)
                {
                    foreach (var item in chars)
                    {
                        answer += item.ToString();
                    }
                    skipLoop = true;
                    prep = false;
                }
                else if (numRows == 2)
                {
                    if (pointer < chars.Length)
                    {
                        answer += chars[pointer].ToString();
                        pointer += 2;
                    }
                    else if (rowNum < numRows)
                    {
                        pointer = rowNum;
                        rowNum++;
                    }
                    else 
                    { 
                        skipLoop = true;
                        prep = false;
                    }
                }
                else
                {
                    prep = false;
                }
            }
            

            while (!skipLoop)
            {
                if (rowNum == 1)
                {
                    if (pointer < chars.Length)
                    {
                        answer += chars[pointer].ToString();
                        pointer += numRows + zigCols;
                    }
                    else
                    {
                        rowNum++;
                        pointer = rowNum - 1;
                    }
                }
                else if (rowNum == numRows)
                {
                    if (pointer < chars.Length)
                    {
                        answer += chars[pointer].ToString();
                        pointer += numRows + zigCols;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (rowNum > numRows)
                {
                    break;
                }
                else
                {
                    var nextPointer = pointer + numRows + zigCols;
                    var zigIndex = pointer +(2*(numRows-rowNum));
                    
                    if (pointer <= chars.Length - 1)
                    {
                        answer += chars[pointer].ToString();
                        if (pointer > chars.Length)
                        {
                            rowNum++;
                            pointer = rowNum - 1;
                        }
                        else
                        {
                            pointer = nextPointer;
                        }
                        
                        
                        if (zigIndex <= chars.Length - 1)
                        {
                            answer += chars[zigIndex].ToString();
                         }
                    }
                    else
                    {
                        rowNum++;
                        pointer = rowNum - 1;
                    }
                }

            }

            //Console.WriteLine(answer);
            return answer;
        }


    }
}
