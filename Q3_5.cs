/*
Implement a MyQueue class which implements a queue using two stacks.
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
        public int top()
        {
            if(topIndex > -1)
                return stk[topIndex];
            else
                return -1;
        }
    }
    public class MyQueue
    {
        int len;
        Stack enque;
        Stack deque;
        public MyQueue(int _len)
        {
            len = _len;
            enque = new Stack(len);
            deque = new Stack(len);
        }
        public bool enqueue(int k)
        {
            if(enque.top() == -1 || deque.top() > -1)
            {
                while(deque.top() > -1)
                {
                    enque.push(deque.pop());
                }
            }
            return enque.push(k);
        }
        public int dequeue()
        {
            if(deque.top() == -1 || enque.top() > -1)
            {
                while(enque.top() > -1)
                    deque.push(enque.pop());
            }
            return deque.pop();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            MyQueue q = new MyQueue(len);
            Console.WriteLine(q.enqueue(15));
            Console.WriteLine(q.enqueue(10));
            Console.WriteLine(q.enqueue(20));
            Console.WriteLine(q.dequeue());
            
        }
        
    }
}
