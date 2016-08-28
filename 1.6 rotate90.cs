/*
1.5 Implement a method to perform basic string compression using the counts of repeated charcters. 
For Example, the string aabcccccaaa would become a2b1c5a3. 
If the compressed string would not become smaller than the original string, your method should return the original string.

Assumptions:
If the compressed string and orignal string are of same length, choose original string.
Considering numbers as strings
Spaces on the ends of input string will be trimmed.
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
            Console.WriteLine("Enter length of nXn matrix");
            int arrLen = Convert.ToInt32(Console.ReadLine());
            int[,] input = new int[arrLen,arrLen];
            example.getInput(input,arrLen);
            if(arrLen <= 0)
                Console.WriteLine("");
            else
            example.rotate90(input,arrLen);

        }
        private void getInput(int[,] input,int arrLen)
        {
            for(int i = 0 ; i < arrLen;i++)
            {
                for(int j = 0;j<arrLen;j++)
                {
                    Console.WriteLine("Enter for "+i+"X"+j);
                    input[i,j]  = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        private void rotate90(int[,] input, int arrLen) 
        {
            for(int j = arrLen-1;j >= 0;j--)
            {
                for(int i = 0 ; i < arrLen;i++)
                {
                    if(i < arrLen-1)
                    Console.Write(input[i,j]);
                    else
                     Console.WriteLine(input[i,j]);
                }
            }
        }
    }
}
/*
Tests
1. empty string
2. null string
3. aabcccccaaa
4. aaaaaaa
5. a
6. abc
7. what about spaces?
8. what about numbers in string?
9. abababababab
*/