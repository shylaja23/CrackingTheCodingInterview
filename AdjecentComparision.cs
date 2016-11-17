/*
Given an integer array, for each element in the array check whether there exist a smaller element on the next immediate position of the array. If it exist print the smaller element. If there is no smaller element on the immediate next to the element then print -1.

Input:

The first line of input contains an integer T denoting the number of test cases.
The first line of each test case contains an integer N, where N is the size of array.
The second line of each test case contains N integers sperated with a space which is input for the array arr[ ]

Output:

For each test case, print in a newline the next immediate smaller elements for each element in the array.

Constraints:

1 ≤ T ≤ 100
1 ≤ N ≤ 500
1 ≤ arr[i] ≤ 1000

Example:

Input
2
5
4 2 1 5 3
6
5 6 2 3 1 7

Output
2 1 -1 3 -1
-1 2 -1 1 -1 -1
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
            Program p = new Program();
            p.CompareValues(p.getInput());
             
        }
        public int[][] getInput(){
            int noOfArrays = Convert.ToInt32(Console.ReadLine());
            int[][] inp = new int[noOfArrays][];
            //Console.WriteLine(noOfArrays);
            for(int i = 0; i< noOfArrays;i++){
                int len = Convert.ToInt32(Console.ReadLine());
                int j = 0;
                string strArray = Console.ReadLine();
                //Console.WriteLine(strArray);
                string[] arr = strArray.Trim().Split(new Char[]{' '});
                int[] temp = new int[len];
                for(;j<len;j++)
                    temp[j] = Convert.ToInt32(arr[j]);
                inp[i] = temp;
                
            }
            return inp;
        }
        public void CompareValues(int[][] arr){
            
            for(int i = 0; i<arr.GetLength(0);i++){
                int j = 0;
                for(; j < (arr[i].Length)-1;j++){
                    if(arr[i][j] > arr[i][j+1])
                        Console.Write(arr[i][j+1]+" ");
                    else
                        Console.Write("-1 ");
                }
                Console.Write("-1");
                Console.WriteLine("");
            }
            
        }
    }
}
