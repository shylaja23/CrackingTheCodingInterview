/*Given two strings, write a method to decide if one is a permutation of the other.
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
            string str = Console.ReadLine();
            string permutation = Console.ReadLine();
            Console.WriteLine(PermutationOfString(str,permutation));
        }
        
        public static bool PermutationOfString(string s,string p)
        {
            
            int j = 0;
            for(int i = 0; (j <= p.Length-1 && i <= s.Length-1) ;i++)
            {
                //Console.WriteLine("s[i]="+s[i]+ "  p[j]="+p[j]+"  i="+i+"   j="+j);
                if(j > 0 && s[i] != p[j])
                    j = 0;
                if(s[i] == p[j])
                {
                    j++;
                    continue;
                }
            }
            if(j == p.Length)
                return true;
            return false;
            
        }
    }
}
