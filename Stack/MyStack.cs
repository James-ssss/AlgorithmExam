using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.Stack
{
    public class MyStack<T>
    {
        Node tail { get; set; }

        public int Count
        {
            get
            {
                int count = 0;
                Node curr = tail;
                while (curr is not null)
                {
                    curr = curr.prev;
                    count++;
                }
                return count;
            }
        }

        public class Node
        {
            public T val { get; set; }
            public Node prev { get; set; }
            public Node next { get; set; }

            public Node(T val)
            {
                this.val = val;
            }
        }

        public void Push(T val)
        {
            if (tail is null)
            {
                tail = new Node(val);
                return;
            }

            Node node = new Node(val);
            tail.next = node;
            node.prev = tail;
            tail = tail.next;
        }

        public T Pop()
        {
            T last = tail.val;
            tail = tail.prev;
            tail.next = null;

            return last;
        }

        public void Insert(T val, int ind)
        {
            int count = Count - 1;
            Node curr = tail;
            while (count != ind)
            {
                curr = curr.prev;
                count--;
            }

            Node node = new Node(val);
            curr.prev.next = node;
            node.prev = curr.prev;
            curr.prev = node;
            node.next = curr;
        }

        public void Print()
        {
            Node curr = tail;
            while (curr is not null)
            {
                Console.Write(curr.val + " ");
                curr = curr.prev;
            }
            Console.WriteLine();
        }
    }

}
