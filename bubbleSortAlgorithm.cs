/*
Question:
------------
Implement bubble sort
Assumptions:
------------
string doesn't contain special characters
string is not alphanumeric
string is not empty
array length is fixed adn preset to 9


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
            example.bubbleSort(example.getInput());
        }

        private int[] getInput()
        {
            int[] arr = new int[9];
            int i = 0;
            
            while(i < 9)
            {
                string str = Console.ReadLine();
                if(str.Trim() != "0")
                {
                    arr[i] = Convert.ToInt32(str);
                    i++;
                }
            }
            return arr;
        }
        
        private void bubbleSort(int[] arr)
        {
            int k = 1;
            
            for(int i = 0; i <= arr.Length - 1; i++)
            {
                if( (i+1 <= arr.Length - k) && (arr[i] > arr[i+1]))
                    swap(arr,i);
                    
                if(i == arr.Length - k && k <= arr.Length )
                {
                    i = -1;
                    k++;
                }
            }
            print(arr);
        }
        private void swap(int[] arr, int i)
        {
            int tmp = arr[i+1];
            arr[i+1] = arr[i];
            arr[i] = tmp;
        }
        
        private void print(int[] arr)
        {
            for(int i = 0 ; i < arr.Length ; i++)
                Console.Write(arr[i] + "  ");
            Console.WriteLine("");
        }
    }
       
}

/*
Tests
-------
1. duplicate element


*/
/*
Observations
------------------
n(n-1)/2 time complexity

*/
