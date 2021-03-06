/*
Implement an algorithm to find the kth to last element of a singly linked list.

SOlution: track number of elements traversed so far with tracker int and curr NOde. when kth element = tracker, create a kELe NOde and traverse nodes until curr reaches last element in linked list. this way you got the kth element from last, runner technique. 
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
            Node root = CreateList();
            FindKElement(root);
            //PrintList(root);
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
        public static void FindKElement(Node root)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            int tracker = 0;
            Node curr = root;
            Node kEle = root;
            while(true)
            {
                if(curr.next == null)
                {
                    break;
                }
                if(tracker >= k)
                    kEle = kEle.next;
                curr = curr.next;
                tracker++;
            }
            if(kEle != null)
                Console.WriteLine(kEle.val);
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
        }
    }
}
