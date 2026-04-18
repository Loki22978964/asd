using Data_Structures;

namespace helper
{
    public class helper3
    {
        public void Task3Simulation(Queue queue, LinkedList linkedList)
        {
            Console.WriteLine("     Starting Task 3      ");
            Console.WriteLine("Initial List content:");
            linkedList.Print();

            Node current = linkedList.Head;
            List<int> positiveValues = new List<int>();

            while (current != null)
            {
                if (current.value > 0)
                {
                    positiveValues.Add(current.value);
                }
                current = current.next;
            }

            foreach (int val in positiveValues)
            {
                linkedList.Remove(val);

                int lastInQueue = queue.IsEmpty() ? 0 : queue.GetLast();
                int newValue = lastInQueue + val;

                if (queue.Enqueue(newValue))
                {
                    Console.WriteLine($"Moved {val}: New queue element = {lastInQueue} + {val} = {newValue}");
                }
                else
                {
                    Console.WriteLine("Queue is full!");
                    break;
                }
            }

            Console.WriteLine("\nFinal state of LinkedList:");
            linkedList.Print();

            Console.WriteLine("Final state of Queue:");
            queue.Print();
        }

        public LinkedList GetLinkedList(int size)
        {
            Console.WriteLine($"     Populating List (Size: {size})    ");
            LinkedList linkedList = new LinkedList();

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter value for node {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    linkedList.Add(n);
                }
                else
                {
                    Console.WriteLine("Invalid input. Adding 0.");
                    linkedList.Add(0);
                }
            }
            return linkedList;
        }
    }
}