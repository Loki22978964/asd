using Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helper
{
    public class helper2
    {
        public void LinkedListSimulation()
        {
            LinkedList list = new LinkedList();

            Console.WriteLine("Adding elements:");
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);

            list.Print();

            Console.WriteLine("\nRemoving 20:");
            list.Remove(20);
            list.Print();

            Console.WriteLine("\nRemoving 10 (head):");
            list.Remove(10);
            list.Print();

            Console.WriteLine("\nChecking IsEmpty:");
            Console.WriteLine(list.IsEmpty());

            Console.WriteLine("\nAdding more:");
            list.Add(50);
            list.Add(60);
            list.Print();

            Console.WriteLine("\nRemoving non-existent element (999):");
            list.Remove(999);
            list.Print();
        }
    }
}
