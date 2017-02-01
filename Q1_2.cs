/*Implement a function void reverse(char* str) in C or C++ which reverses a nullterminated
string
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
            //Your code goes here
            string inp = Console.ReadLine();
            Console.WriteLine(ReverseString(inp));
        }
        
        public static string ReverseString(string s)
        {
            char[] ret = new char[s.Length];
            for(int i = 0, j = s.Length-1;i<j;i++,j--)
            {
                //Console.WriteLine("i="+i+"   j="+j+"   s[i]="+s[i]+"   s[j]"+s[j]);
                ret[i] = s[j];
                ret[j] = s[i];
                    
            }
            if(s.Length %2 > 0) ret[s.Length/2] = s[s.Length/2];
            return new string(ret);
        }
    }
}
