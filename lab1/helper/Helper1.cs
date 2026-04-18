using Data_Structures;

namespace helper
{
    public class helper1
    {
        public void QueueSimulation()
        {
            Queue queue = new Queue(5);

            Console.WriteLine("Adding elements:");
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            queue.Print(); // 10 20 30

            Console.WriteLine("\nFirst element (Peek): " + queue.Peek());
            Console.WriteLine("Last element: " + queue.GetLast());

            Console.WriteLine("\nRemoving element: " + queue.Dequeue());
            queue.Print(); // 20 30

            Console.WriteLine("\nAdding more:");
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60); // checking circularity

            queue.Print(); // 20 30 40 50 60

            Console.WriteLine("\nCount: " + queue.Count);
            Console.WriteLine("Capacity: " + queue.Capacity);

            Console.WriteLine("\nClearing the queue:");
            queue.Clear();
            Console.WriteLine("IsEmpty: " + queue.IsEmpty());
        }
    }
}