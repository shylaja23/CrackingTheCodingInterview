/*
You have two numbers represented by a linked list, where each node contains a
single digit. The digits are stored in reverse order, such that the Ts digit is at the
head of the list. Write a function that adds the two numbers and returns the sum
as a linked list.
EXAMPLE
Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is, 617 + 295.
Output: 2 -> 1 -> 9.That is, 912.
FOLLOW UP
Suppose the digits are stored in forward order. Repeat the above problem.
EXAMPLE
Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).That is, 617 + 295.
Output: 9 -> 1 -> 2.That is, 912.


Solution1: add the units digits and keep track of carryover value with int carry, then add 10s digits and carry and 100s digits and carry, add results of addition into a new linked list.
Solution2: 
calculate the length of each lists l1, l2, 
pad the number with 0 to even both list lengths.
put both lists  in 2 stacks s1, s2 (in this case , array) and start adding the numbers from top of the stack
for every addition, create a new node with the result number and attach it after root


newnode.next = root.next;
root.next = newnode;


*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Node
    {
        public int val;
        public Node next;
        public Node(int _val)
        {
            val = _val;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Node root1 = CreateList();
            Node root2 = CreateList();
            Node resultroot = AddLists(root1,root2); //Part1
            Node resultroot2 = AddListsReverse(root1,root2); //Part2
            PrintList(resultroot2);
        }
        public static Node CreateList()
        {
            Node root = new Node(0);
            Node curr = root;
            while(true)
            {
                string inp = Console.ReadLine();
                if(inp == String.Empty){
                    break;
                }
                Node temp = new Node(Convert.ToInt32(inp));
                curr.next = temp;
                curr = temp;
            }
            return root;
        }
        public static Node AddLists(Node root1, Node root2)
        {
            Node curr1 = root1.next;
            Node curr2 = root2.next;
            int carry = 0;
            Node ret = new Node(0);
            Node curr = ret;
            while(true)
            {
               int temp = curr1.val+curr2.val+carry;
                if(temp > 9)
                    carry = 1;
                Node tmp = new Node(temp%10);
                curr.next = tmp;
                curr = curr.next;
                if(curr1.next == null && curr2.next == null)
                    break;
                else{
                if(curr1.next == null)
                    curr1.val = 0;
                else
                    curr1 = curr1.next;
                 if(curr2.next == null)
                    curr2.val = 0;
                else
                    curr2 = curr2.next;
                }
            }
            return ret;
        }
        public static Node AddListsReverse(Node root1, Node root2)
        {
            int l1 = getLength(root1.next);
            int l2 = getLength(root2.next);
            getPadding(ref root1,ref root2, l1,l2);
            int carry = 0;
            int[] a1 = new int[l1];
            int[] a2 = new int[l2];
            int i=0;
            Node curr1 = root1.next;
            Node curr2 = root2.next;
            while(curr1 != null)
            {
                a1[i] = curr1.val;
                a2[i++] = curr2.val;
                curr1 = curr1.next;
                curr2 = curr2.next;
            }
            i--;
            Node resultroot = new Node(0);
            while(i >= 0)
            {
                int temp = a1[i]+a2[i--]+carry;
                if(temp > 10)
                    carry = 1;
                Node tmp = new Node((temp > 10 ? temp-10 : temp));
                if(resultroot.next == null)
                    resultroot.next = tmp;
                else{
                    tmp.next = resultroot.next;
                    resultroot.next = tmp;
                    }
            }
            return resultroot;    
        }
        public static int getLength(Node pt)
        {
            int len = 1;
            while(pt.next != null)
            {
                len++;
                pt = pt.next;
            }
            return len;
        }
        public static void getPadding(ref Node root1, ref Node root2, int l1, int l2)
        {
            if(l1>l2)
            {
                int diff = l1-l2;
                while(diff > 0)
                {
                    Node temp = new Node(0);
                    temp.next = root2.next;
                    root2.next = temp.next;
                    diff--;
                }
            }
            if(l2>l1)
            {
                int diff = l2-l1;
                while(diff > 0)
                {
                    Node temp = new Node(0);
                    temp.next = root1.next;
                    root1.next = temp.next;
                    diff--;
                }
            }
        }
        public static void PrintList(Node root)
        {
            Node curr = root.next;
            while(true)
            {
                Console.Write(curr.val);
                if(curr.next == null)
                    break;
                else
                curr = curr.next;
            }
            Console.WriteLine("");
        }
    }
}
