/*
Implement a method to perform basic string compression using the counts
of repeated characters. For example, the string aabcccccaaa would become
a2blc5a3. If the "compressed" string would not become smaller than the original
string, your method should return the original string.


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
            StringBuilder ret = new StringBuilder();
            int curCount = 0;
            char curChar = '\0';
            for(int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if(curChar == '\0'){
                    curChar = c;
                    curCount = 1;
                }
                else if(curChar != '\0'){
                    if(c == curChar)
                        curCount++;
                    else if(c != curChar){
                        curChar = c;
                        curCount = 1;
                    }
                }
                if(i == s.Length-1 || ((i < s.Length-1) && c != s[i+1]))
                {
                    ret.Append(curChar);
                    ret.Append(curCount);
                }
                Console.WriteLine("curCount"+curCount+"   curChar"+curChar);
            }
            if(ret.Length < s.Length)
                return ret.ToString();
            else
                return s;
            
        }
    }
}
