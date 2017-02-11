/*
3.3 Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
Therefore, in real life, we would likely start a new stack when the previous stack
exceeds some threshold. Implement a data structure SetOf Stacks that mimics
this. SetOf Stacks should be composed of several stacks and should create a
new stack once the previous one exceeds capacity. SetOf Stacks. push() and
SetOf Stacks. pop() should behave identically to a single stack (that is, popO
should return the same values as it would if there were just a single stack)

SOLUTION: 
Assuming that all stacks have fixed given length of "len"
maintain the current stack with stk int[], maintain topIndex of current stk with "topIndex"

put:    whenever a stack is not initialized ,initialize the stack and add the integer given 
        whenever stack topIndex is len-1 value after integer is added, add to lst List<int[]>
        whenever stack topIndex is len value, initialize stk with new int[] because the prev stk int[] is already added to  lst List<int[]> in step 2
        
        
pop:    remember that when put is made, topIndex will always point to the current topIndex
        if topIndex = 0 , it means the stack has only one value which will be popped, this also means stk int[] must point to prev stack and curr stack must be removed from lst List<int[]>
        if topIndex > 0 , value will be popped out of the current stk
    
    
top:   if topIndex > -1 returns stk[topIndex] else -1 to indicate that nothing is inserted yet.


FOLLOWUP
Implement a function popAt(int index) which performs a pop operation on
a specific sub-stack.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class SetOfStacks
    {
        int len;
        List<int[]> lst = new List<int[]>();
        int[] stk;
        int topIndex = -1;
        public SetOfStacks(int _len)
        {
            len = _len;
        }
        public void put(int k)
        {
            if(topIndex == len-1 || stk == null){
                stk = new int[len];
                topIndex = -1;
            }
            if(topIndex+1 < len){
                topIndex++;
                stk[topIndex] = k;
            }
            if(topIndex == len-1)
                lst.Add(stk);
        }
        public int top()
        {
            if(topIndex > -1)
                return stk[topIndex];
            else
                return -1;
        }
        public void pop()
        {
            if(topIndex == 0 && lst.Count > 0)
            {
                int setIndex = lst.Count-1;
                stk = lst[setIndex];
                lst.RemoveAt(setIndex);
                topIndex = len-1;
            }
            else
            {
                stk[topIndex] = 0;
                this.topIndex--;
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            SetOfStacks s = new SetOfStacks(len);
            s.put(7);
            s.put(5);
            s.put(3);
            Console.WriteLine(s.top());
            s.put(8);
            s.pop();
            //s.put(6);
            Console.WriteLine(s.top());
        }
        
    }
}
