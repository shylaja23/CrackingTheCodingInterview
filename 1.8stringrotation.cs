/*
Question:
------------
1.8 Assume you have a method isSubstring which checks if one word is a
substring of another. Given two strings, si and s2, write code to check if s2 is
a rotation of s1 using only one call to isSubstring (e.g.,"waterbottle"is a rotation
of "erbottlewat").

Assumptions:
------------
string doesn't contain special characters

*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program example = new Program();
            //Console.WriteLine("Enter String1 and String2 in new line");
            string s1  = Console.ReadLine();
            string s2 = Console.ReadLine();
            bool isSubString = example.chkSubString(s1,s2);
            Console.WriteLine(isSubString);
        }
        
        private bool chkSubString(string s1,string s2)
        {
            if(s1.Length == s2.Length)
            {
               char[] s1arr = s1.ToArray();
               char[] s2arr = s2.ToArray();
               List<int> premch = new List<int>();
               List<int> postmch = new List<int>();
               for(int i=0;i<s1.Length;i++) postmch.Add(i);
               int index2 = 0;
               for(; index2 < s2.Length ; index2++)
               {
                   
                    premch = new List<int>();
                    foreach(int index1 in postmch)
                   {
                       Console.WriteLine("Comparing s2arr["+index2+"]  = "+s2arr[index2]+" s1arr["+index1+"] "+s1arr[index1]);
                       if(s2arr[index2] == s1arr[index1])
                       {
                           premch.Add((index1 == s1.Length-1 ? 0 : index1+1));
                       }
                   }
                   if(premch.Count == 0) break;
                   postmch.Clear();
                   foreach(int i in premch) postmch.Add(i);
                   
               }
               if(postmch.Count == 1 && index2 == s2.Length) return true;
               else return false;
            }
            else return false;
        }          
    }
       
}

/*
Tests
-------
1. single element
2. tested cloud clone
3. s1 = babaa s2 = ababa this should pass the test

s1 = babaa s2 = ababa

a
a2 a4 a5
ab
a2b3 a5b1
aba
a2b3a4 a5b1a2
abab
a5b1a2b3
ababa
a5b1a2b3a4

*/
/*
Observations
------------------
nlogn time complexity
cannot remove any more data structures
*/