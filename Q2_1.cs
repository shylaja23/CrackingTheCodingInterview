/*
Write code to remove duplicates from an unsorted linked list.
FOLLOW UP
How would you solve this problem if a temporary buffer is not allowed?

Solution: Use tracker integer and bitwise AND to tracker with current value , if result is  > 0 then it is a duplicate. use 2 pointers while traversing linked list, prev and curr. whenever a duplicate is encountered, prev.next = curr.next will eleminate curr from linked list.
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
            RemoveDuplicates(root);
            PrintList(root);
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
        public static void RemoveDuplicates(Node root)
        {
            int tracker = 0;
            Node prev = root;
            Node curr = root.next;
            while(true)
            {
                Console.WriteLine(curr.val);
                if((tracker & 1<<curr.val) > 0)
                {
                    prev.next = curr.next;
                }
                else
                {
                    tracker = tracker | 1<<curr.val;
                }
                if(curr.next == null)
                {
                    break;
                }
                prev = curr;
                curr = curr.next;
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
        }
    }
}
