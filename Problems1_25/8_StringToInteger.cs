using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems1_25;

public static class _8_StringToInteger
{
    public static int MyAtoi(string s)
    {
        //Remove leading whitespace
        //sign will be '-' or '+'
        //skip leading zeros
        //Return 0 if no non-zero/no-digit integers are found
        //Stop reading the string if the first character is a non-digit character, return 0
        //Round to keep integer in 32-bit range.
        string newString = string.Empty;
        s = s.Trim();
        bool exitLoop = false;
        bool isLeadingZero = true;
        bool digitAlreadyFound = false;
        bool isNeg = false;
        bool signChecked = false;
        int answer;

        while (!exitLoop)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var isDigit = Char.IsDigit(s[i]);
                var isAlpha = Char.IsLetter(s[i]);

                if (!isDigit && !isAlpha) //Not a digit and not already determined as negative or positive
                {
                    if (!digitAlreadyFound && !signChecked)
                    {
                        if (s[i] == '-')
                        {
                            isNeg = true;
                            signChecked = true;
                            newString = string.Empty;
                            digitAlreadyFound = true;
                            isLeadingZero = false;
                        }
                        else if (s[i] == '+')
                        {
                            signChecked = true;
                            newString = string.Empty;
                            digitAlreadyFound = true;
                            isLeadingZero = false;
                        }
                        else
                        {
                            exitLoop = true;
                            break;
                        }
                    }
                    else
                    {
                        exitLoop = true;
                        break;
                    }
                }
                else if (isDigit)
                {
                    digitAlreadyFound = true;

                    if (s[i] == '0' && isLeadingZero)
                    {
                        newString = string.Empty;
                        newString += s[i];
                    }
                    //else if (s[i] != '0')
                    else
                    {
                        newString += s[i];
                        signChecked = true;
                        isLeadingZero = false;
                    }
                }
                else
                {
                    break; //non-digit character was found so string reading can be stopped
                }
            }
            exitLoop = true;
        }


        //-2,147,483,648 to 2,147,483,647
        try
        {
            if (isNeg && newString.Length != 0)
            {
                answer = Convert.ToInt32(newString);
                answer *= -1;
            }
            else if (newString.Length == 0)
            {
                answer = 0;
            }
            else
            {
                answer = Convert.ToInt32(newString);
            }
        }
        catch (Exception)
        {
            if (isNeg && newString.Length != 0)
            {
                answer = -2147483648;
            }
            else if (newString.Length == 0)
            {
                answer = 0;
            }
            else
            {
                answer = 2147483647;
            }
            //throw;
        }
      
        return answer;

    }
}

