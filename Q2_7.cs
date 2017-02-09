/*
Implement a function to check if a linked list is a palindrome

Solution: Runner technique, 2 nodes, one slow node will hop one node per loop, fast node will hop 2 nodes per loop.
keep track of the length of list by cnt which will do cnt = cnt+2 in the loop.
either fast node will have one node left to hop or it actually is at the end of the list.check if fast node has one node left and increment the cnt to get correct length of linked list
once length is determined, calc if length is even or odd,if list length is even then slow = slow.next, else slow = slow.next.next
use slow node to put 2nd half of the linked list into a stack.
use fast node to point it back to root, now compare fast node value and top of the stack value. if at any point values dont match, it is not a palindrome.

INPUT :[1234567] 
slow = 1
fast = 2 len = 2

slow = 2
fast = 4 len = 4

slow = 3
fast = 6 len = 6

fast.next is 7, so len = 7

len/2 = 3.5 = 3 , which means slow should be pointing to 5 , slow = slow.next.next

slow node is iterating and is putting in stack, fast is pointing to first node
_      _
 | 7  |
 | 6  |       [1 2 3]
 | 5  |
 ~~~~~~
 
 7 =? 3
 6 =? 2
 5 =? 1
 
 if palindrome then OUTPUT is YES
 
 
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
            Node pt = CreateList();
            FindPalindrome(pt);
        }
        public static Node CreateList()
        {
            Node root = new Node(0);
            Node curr = root;
            for(int i = 1; i <8;i++)
            {
                string inp = Console.ReadLine();
                Node temp = new Node(Convert.ToInt32(inp));
                curr.next = temp;
                curr = curr.next;
            }
            return root;
        }
        public static void FindPalindrome(Node pt)
        {
            Node slow = pt;
            Node fast = pt;
            int len = 0;
            while(fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                len++;len++;
            }
            if(fast.next != null)
                len++;
            if(len%2 == 0)
                slow = slow.next;
            else
                slow = slow.next.next;
            
            int[] a = new int[len/2];
            int i = 0;
            while(slow != null){
                a[i] = slow.val;
                i++;
                slow = slow.next;
            }
            fast= pt.next;
            i--;
            while(i >= 0)
            {
                if(fast.val == a[i--])
                    fast = fast.next;
                else
                    break;
            }
            if(i<0)
                Console.WriteLine("Palindrome: Yes");
            else
                Console.WriteLine("Palindrome: No");
        }
    }
}
