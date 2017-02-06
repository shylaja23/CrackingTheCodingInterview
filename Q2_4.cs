/*
Write code to partition a linked list around a value x, such that all nodes less than
x come before all nodes greater than or equal to x.

Solution: Create prev node to keep track of highest number that is greater than or equal to x, create curr node to keep track of current node in list. 
when current node value is less than x then swap the value of nodes curr and prev.
input 1 7 2 6 3 5 4
curr = 1
prev = 1

curr = 7
prev = 1 then becomes 7

curr = 2
prev = 7 swaps values
1 2 7 6 3 5 4

curr = 6
prev = 7 

curr = 3
prev = 7 swap values
1 2 3 7 6 5 4

curr = 5
prev = 7 

curr = 4
prev = 7

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
            PartitionList(root);
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
        public static void PartitionList(Node root)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            Node curr = root.next;
            Node prev = root.next;
            
            while(true)
            {
                if(curr.val >= k && prev.val < k)
                    prev = curr;
                if(curr.val < k)
                {
                   int temp = prev.val;
                    prev.val = curr.val;
                    curr.val = temp;
                    prev = prev.next;
                }
                
                if(curr.next == null)
                    break;
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
