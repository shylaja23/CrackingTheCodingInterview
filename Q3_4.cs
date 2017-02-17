//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

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
        public string towerName;
        public Stack(int _len, string name)
        {
            len = _len;
            towerName = name;
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
        public int top()
        {
            if(topIndex > -1)
                return stk[topIndex];
            else
                return -1;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int discs = Convert.ToInt32(Console.ReadLine());
            Stack t1 = new Stack(discs,"t1");
            Stack t2 = new Stack(discs,"t2");
            Stack t3 = new Stack(discs,"t3");
            for(int i =1;i <= discs;i++)
            {
                t1.push(Convert.ToInt32(Console.ReadLine()));
            }
            SolvePuzzle(t1,t2,t3,discs);
        }
        public static void SolvePuzzle(Stack source, Stack buffer, Stack dest,int len)
        {
            if(len == 1){
               int temp = source.pop();
                dest.push(temp);
                Console.WriteLine(temp +": "+source.towerName+" -> "+dest.towerName);
                return;
            }
            SolvePuzzle(source,dest,buffer,len-1);
            int temp1 = source.pop();
            dest.push(temp1);
            Console.WriteLine(temp1 +": "+source.towerName+" -> "+dest.towerName);
            SolvePuzzle(buffer,source,dest,len-1);
            
        }
    }
}
