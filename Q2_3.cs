/*
Implement an algorithm to delete a node in the middle of a singly linked list,
given only access to that node.
EXAMPLE
Input: the node c from the linked list a - > b - > c - > d - > e
Result: nothing is returned, but the new linked list looks like a- >b- >d->e

Solution: Create prev, curr nodes to keep track, traverse through the nodes until given node is reached, then prev.next = curr.next, 
we are assuming the curr.next exists since node given will be the middle node in list
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
            RemoveKElement(root);
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
        public static void RemoveKElement(Node root)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            Node curr = root.next;
            Node prev = root;
            while(true)
            {
                if(curr.val == k)
                {
                   if(curr.next != null)
                       prev.next = curr.next;
                }
                if(curr.next == null)
                    break;
                prev = prev.next;
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
