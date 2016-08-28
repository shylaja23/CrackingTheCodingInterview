/*
1.7 Write an algorithm such that if an element in an MxN matrix is 0, its entire row
and column are set to 0.

Assumptions:
>0 length of matrix is given
all content in matrix is integer

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
            Console.WriteLine("Enter length of mXn matrix");
            string len  = Console.ReadLine();
            int m = Convert.ToInt32(len.Split(',')[0]);
            int n = Convert.ToInt32(len.Split(',')[1]);
            
            int[,] input = new int[m,n];
            if(m <= 0 || n <= 0)
                Console.WriteLine("");
            else
            {
            example.getInput(input,m,n);
            example.print(input,m,n);
            int[,] result = new int[m,n];
            result = example.check0(input,m,n);
            Console.WriteLine("-----------------------");
            example.print(result,m,n);
            }

        }
        private void print(int[,] input,int m, int n)
        {
            for(int i = 0 ; i < m;i++)
            {
                for(int j = 0;j<n;j++)
                {
                    if(j < n-1)
                    Console.Write(input[i,j]+ "     ");
                    else
                    Console.WriteLine(input[i,j]);
                }
            }
        }
        private void getInput(int[,] input,int m, int n)
        {
            for(int i = 1 ; i <= m;i++)
            {
                for(int j = 1;j<=n;j++)
                {
                    //Console.WriteLine("Enter for "+i+"X"+j);
                    input[i-1,j-1]  = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        private int[,] check0(int[,] input, int m,int n) 
        {
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();
            
            for(int i = 0;i < m;i++)
            {
                for(int j = 0 ; j < n;j++)
                {
                    if(input[i,j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }
            
            return CopyArray(input,rows,cols,m,n);
        }
        private int[,] CopyArray(int[,] input, HashSet<int> rows ,HashSet<int> cols,int m, int n)
        {
            int[,] result = new int[m,n];
            for(int i = 0;i < m;i++)
            {
                for(int j = 0 ; j < n;j++)
                {
                    if(!rows.Contains(i) && !cols.Contains(j))
                        result[i,j] = input[i,j];
                    else
                        result[i,j] = 0;
                }
            }
            return result;
        }
    }
}
/*
Tests
1. single element
*/