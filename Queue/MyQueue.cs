using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExam.Queue
{
    public class MyQueue<T>
    {
        Node head { get; set; }

        public int Count
        {
            get
            {
                int count = 0;
                var curr = head;
                while (curr != null)
                {
                    curr = curr.next;
                    count++;
                }

                return count;
            }
        }

        class Node
        {
            public Node next { get; set; }
            public Node prev { get; set; }
            public T value { get; set; }

            public Node(T val)
            {
                this.value = val;
            }
        }

        public void Enqueue(T value)
        {
            if (head is null) { head = new Node(value); return; }

            Node curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
            }

            curr.next = new Node(value);
            curr.next.prev = curr;
        }

        public T Dequeue()
        {
            T ret = head.value;
            head = head.next;
            if (head != null) head.prev = null;

            return ret;
        }

        public void Insert(T value, int index)
        {
            int count = 0;
            Node curr = head;
            while (count != index)
            {
                curr = curr.next;
                count++;
            }

            Node node = new Node(value);
            curr.prev.next = node;
            node.prev = curr.prev;
            curr.prev = node;
            node.next = curr;
        }

        public void Print()
        {
            Node curr = head;
            while (curr is not null)
            {
                Console.Write(curr.value + " ");
                curr = curr.next;
            }
            Console.WriteLine();
        }
    }

}
