using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Collections
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public Node(T data) => Data = data;
    }
    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public void Add(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null) Head = newNode;
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }
            Tail = newNode;
        }

        public void PrintAll()
        {
            var current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
