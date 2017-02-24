/*
An animal shelter holds only dogs and cats, and operates on a strictly "first in,
first out" basis. People must adopt either the "oldest" (based on arrival time) of
all animals at the shelter, or they can select whether they would prefer a dog or
a cat (and will receive the oldest animal of that type). They cannot select which
specificanimal they would like. Create the data structures to maintain this system
and implement operations such as enqueue, dequeueAny, dequeueDog and
dequeueCat.You may use the built-in LinkedList data structure.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Queue
    {
        int len;
        int front = 0;
        int rear = 0;
        List<int> que;
        public Queue(int _len)
        {
            len = _len;
            que = new List<int>();
        }
        public bool enqueue(int k)
        {
            if(isEmpty() || rear - front < len){
                que.Add(k);
                rear++;
                Console.WriteLine(rear+" "+front+" "+k);
                return true;
            }
            Console.WriteLine(rear+" "+front+" "+k);
            return false;
            
        }
        public int dequeue()
        {
            if(!isEmpty()){
                int temp = que[front];
                que[front]= 0;
                front++;
                return temp;
            }
            return -1;
        }
        public int Front()
        {
            if(!isEmpty())
                return que[front];
            return -1;
        }
        public bool isEmpty()
        {
            if(front == rear && rear == -1)
                return true;
            else
                return false;
        }
    }
    public class PetDonor
    {
        int current = 0;
        int len;
        Queue cats;
        Queue dogs;
        public PetDonor(int _len)
        {
            cats = new Queue(_len);
            dogs = new Queue(_len);
            len = _len;
        }
        public bool setPet(string type)
        {
            int k = 0;
            bool inserted = false;
            if(type == "dog")
            {
                k = current+1;
                inserted = dogs.enqueue(k);
            }
            if(type == "cat")
            {
                k = current+len+1;
                inserted = cats.enqueue(k);
                
            }
            if(inserted)
                current++;
            return inserted;
        }
        public int dequeueAny()
        {
            int a = dogs.Front();
            int b = cats.Front()-len;
            Console.WriteLine(a.ToString()+" "+b);
            if(a<b && !dogs.isEmpty())
            {
                return dogs.dequeue();
            }
            if(b < a && !cats.isEmpty())
            {
                return (cats.dequeue()-len);
            }
            return -1;
        }
        public int dequeueDog()
        {
            return dogs.dequeue();
        }
        public int dequeueCat()
        {
            return (cats.dequeue()-len);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            PetDonor shylu = new PetDonor(3);
            Console.WriteLine(shylu.setPet("dog"));
            Console.WriteLine(shylu.setPet("dog"));
            Console.WriteLine(shylu.setPet("cat"));
            Console.WriteLine(shylu.setPet("dog"));
            Console.WriteLine(shylu.setPet("cat"));
            Console.WriteLine(shylu.dequeueCat());
        }
        
        
    }
}
