/*
2.2 implementing stack with current minmum of O(1) time

Solution: I read it somewhere that in order to keep track of current min do the following while push and pop

Push(k)
if(k>= min) insert the number as it is into the stack, minEle is not changed
if(k< min) then insert 2k - minEle into the stack, minEle = k;

pop
if(top >= min) then just pop the element, minEle is not changed
if(top < min) then before popping, minEle = 2minEle - topEle

top
if(stk[topIndex] >= minEle) then return stk[topIndex]
if(stk[topIndex] < minEle) then return minEle
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Stack 
    {
        public int len;
        public int[] stk;
        int topIndex = 0;
        int minEle;
        public Stack(int _len)
        {
            len = _len;
            this.stk = new int[len];
        }
        public void put(int k)
        {
            int ele = k;
            if(topIndex == 0)
                minEle = ele;
            if(k < minEle){
                ele = (2*ele) - minEle;
                minEle = k;
            }
            if(topIndex+1 < len){
                stk[this.topIndex] = ele;
                //Console.WriteLine(this.stk[topIndex]);
                topIndex++;
            }
        }
        public int top()
        {
            int tp = topIndex-1;
            if(stk[tp] < minEle)
                return minEle;
            else
                return stk[tp];
        }
        public void pop()
        {
            int tp = topIndex -1;
            int temp = stk[tp];
            if(temp < minEle)
                minEle = (2*minEle) - temp;
            stk[tp] = 0;
            this.topIndex--;
        }
        public int min()
        {
            return minEle;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            Stack s = new Stack(len);
            s.put(7);
            s.put(5);
            s.put(3);
            Console.WriteLine(s.top()+"min"+s.min());
            s.put(8);
            //s.pop();
            //s.pop();
            Console.WriteLine(s.top()+"min"+s.min());
        }
        
    }
}
