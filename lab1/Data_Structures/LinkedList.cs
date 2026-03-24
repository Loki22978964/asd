using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data_Structures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int value)
        {
            this.value = value;
        }
    }

    public class LinkedList
    {
        private Node head;
        private int count;

        public Node Head { get { return head; } }

        public bool IsEmpty()
        {
            return head == null;
        }

        public bool IsFull()
        {
            return count > 0;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                ++count;
                return;
            }

            Node temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
            ++count;
        }

        public void Remove(int data)
        {
            if (head == null)
            {
                return;
            }

            if (head.value == data)
            {
                head = head.next;
                --count;

                return;
            }

            Node current = head;

            while (current.next != null && current.next.value != data)
            {
                current = current.next;
            }

            if (current.next != null)
            {
                current.next = current.next.next;
                count--;
            }
        }

        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.value + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}