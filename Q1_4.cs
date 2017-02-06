/*
/*Write a method to replace all spaces in a string with'%20'. You may assume that
the string has sufficient space at the end of the string to hold the additional
characters, and that you are given the "true" length of the string. (Note: if implementing
in Java, please use a character array so that you can perform this operation
in place.)
EXAMPLE
Input: "Mr John Smith
Output: "Mr%20Dohn%20Smith"

Solution: Use char array to loop through trimmed version of the input string and add %20 when ever a space is encountered.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inp = Console.ReadLine();
            Console.WriteLine(ModifyString(inp));
        }
        
        public static string ModifyString(string s)
        {
            char[] ret = new char[s.Length];
            int j = 0;
            for(int i = 0; i < s.Trim().Length; i++)
            {
                if(s[i] != ' ')
                {
                    ret[j++] = s[i];
                }
                else
                {
                    ret[j++]= '%';
                    ret[j++] = '2';
                    ret[j++] = '0';
                }
            }
            return new string(ret);
        }
    }
}
