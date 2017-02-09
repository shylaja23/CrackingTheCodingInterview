/*
Given a circular linked list, implement an algorithm which returns the node at
the beginning of the loop.
DEFINITION
Circular linked list: A (corrupt) linked list in which a node's next pointer points
to an earlier node, so as to make a loop in the linked list.
EXAMPLE
Input: A - > B - > C - > D - > E - > C [the same C as earlier]
Output: C

Solution: Runner technique. 2 nodes, slow node will hop one node per loop, fast node will hop 2 nodes per loop. 
the node at which slow node and fast node will meet at node X 
reset the slow node to root and this time, hop one node per loop for slow node and fast node. they will meet at loop head.

Eg:       5      2       3
                       7    1
                         6

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
            Node pt = CreateCircularList();
            FindHead(pt);
        }
        public static Node CreateCircularList()
        {
            Node root = new Node(0);
            Node curr = root;
            for(int i = 1; i <7;i++)
            {
                string inp = Console.ReadLine();
                Node temp = new Node(Convert.ToInt32(inp));
                curr.next = temp;
                curr = curr.next;
            }
            curr.next = root.next.next.next;
            return root;
            
        }
        public static void FindHead(Node pt)
        {
            Node slow = pt;
            Node fast = pt;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow.val == fast.val)
                    break;
            }
            slow = pt;
            while(slow.val != fast.val)
            {
                slow = slow.next;
                fast = fast.next;
            }
            Console.WriteLine("Collision Point: "+slow.val);
        }
    }
}
