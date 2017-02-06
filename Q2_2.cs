//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

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
