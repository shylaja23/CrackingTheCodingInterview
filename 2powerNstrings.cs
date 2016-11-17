
/*

Given a string str your task is to complete the function printSpaceString which takes only one argument the string str and  prints all possible strings that can be made by placing spaces (zero or one) in between them. 

For eg .  for the string abc all valid strings will be
                abc
                ab c
                a bc
                a b c
                
*/                
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Program p = new Program();
            p.insertSpaces("abcde".ToCharArray());
            
        }
        
        public void insertSpaces(char[] arr)
        {
            if(arr.Length == 1)
                Console.WriteLine(arr[0].ToString());
            if(arr.Length > 1)
            {
            HashSet<string> str_set = new HashSet<string>();
            str_set = (insertSpacesIntoArray(arr,str_set,0,arr.Length-1));
            foreach(string s in str_set)
                Console.WriteLine(s);
            }
        }
        
        public HashSet<string> insertSpacesIntoArray(char[] arr, HashSet<string> st, int begin, int end)
        {
            if(st.Count == 0)
            {
                st.Add(arr[begin]+"_");
                st.Add(arr[begin].ToString());
                return insertSpacesIntoArray(arr, st, begin+1, end);
            }
            if(end == begin && st.Count > 0)
            {
                HashSet<string> temp = new HashSet<string>();
                foreach(string s in st)
                    temp.Add(s+arr[begin]);
                return temp;
            }
            else
            {
                HashSet<string> temp = new HashSet<string>();
                foreach(string s in st)
                    temp.Add(s+arr[begin]);
                foreach(string s in st)
                    temp.Add(s+arr[begin]+"_");
                return insertSpacesIntoArray(arr, temp, begin+1, end);
             }
                
        }
        
    }
}
