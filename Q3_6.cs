/*
Write a program to sort a stack in ascending order (with biggest items on top).
You may use at most one additional stack to hold items, but you may not copy
the elements into any other data structure (such as an array). The stack supports
the following operations: push, pop, peek, and isEmpty.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Stack
    {
        int len;
        int topIndex = -1;
        int[] stk;
        public Stack(int _len)
        {
            len = _len;
            stk = new int[len];
        }
        public bool push(int k)
        {
            if(topIndex+1 < len)
            {
                topIndex++;
                stk[topIndex] = k;
                return true;
            }
            return false;
        }
        public int pop()
        {
            if(topIndex > -1)
            {
                int temp = stk[topIndex];
                stk[topIndex] = 0;
                topIndex--;
                return temp;
            }
            return -1;
        }
        public int peek()
        {
            if(topIndex > -1)
                return stk[topIndex];
            else
                return -1;
        }
        public bool isEmpty()
        {
            if(topIndex == -1)
                return true;
            else
                return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            Stack main = new Stack(len);
            Stack buffer = new Stack(len);
            for(int i = 0; i < len; i++){
                Insert(ref main, buffer,Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine(main.peek());
            }
            
        }
        public static void Insert(ref Stack main, Stack buffer, int k)
        {
            if(main.isEmpty() || main.peek() < k){
                main.push(k);
                return; 
            }
            
            while(main.peek() > k || !main.isEmpty())
                buffer.push(main.pop());
            
            main.push(k);
            
            while(!buffer.isEmpty())
                main.push(buffer.pop());
        }
        
    }
}
