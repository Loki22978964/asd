using helper;
using Data_Structures;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            helper1 queue = new helper1();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("First task");
            queue.QueueSimulation();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________________________________________________________________________________");
            
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Second task");

            helper2 linkedList = new helper2();
            linkedList.LinkedListSimulation();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Third task");
            helper3 h3 = new helper3();

            Console.Write("Enter how many elements you want in the initial list: ");
            if (!int.TryParse(Console.ReadLine(), out int listSize)) listSize = 5;

            LinkedList myList = h3.GetLinkedList(listSize);

            Queue myQueue = new Queue(listSize);

            h3.Task3Simulation(myQueue, myList);
        }
    }
}
