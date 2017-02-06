/*Implement an algorithm to determine if a string has all unique characters. What
if you cannot use additional data structures?

Solution: This solution will consider small caps and capital letters as same.
Question is to find if a given string is unique. and no datastructure be used in solution. 
 this solution uses binary representation of a var datatype variable to uniquely identify each character and binary OR int value of each character to checker if it is unique. Binary AND is used to check each character with checker if the same character is repeated.
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
            Console.WriteLine(isUnique(inp));
        }
        
        public static bool isUnique(string s)
        {
            var checker = 0;
            for(int i = 0; i < s.Length;i++){
                var val = s[i] - 'a';
                Console.WriteLine(Convert.ToInt32(val));
                if((checker & (1<<val)) > 0)
                    return false;
                checker |= (1 << val);
                Console.WriteLine("checker"+checker);
            }
            return true;
        }
    }
}
