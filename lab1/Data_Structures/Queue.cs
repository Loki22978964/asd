using System;

namespace Data_Structures
{
    public class Queue
    {
        private int[] data;
        private int head;
        private int tail;
        private int count;

        public int Count => count;
        public int Capacity => data.Length;

        public Queue(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be greater than 0");

            data = new int[size];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Clear()
        {
            Array.Clear(data, 0, data.Length);

            head = 0;
            tail = 0;
            count = 0;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[(head + i) % data.Length] + " ");
            }
            Console.WriteLine();
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == data.Length;
        }

        public bool Enqueue(int item)
        {
            if (IsFull())
                return false;

            data[tail] = item;
            tail = (tail + 1) % data.Length;
            count++;
            return true;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            int item = data[head];
            head = (head + 1) % data.Length;
            count--;
            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            return data[head];
        }

        public int GetLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            int lastIndex = (tail - 1 + data.Length) % data.Length;
            return data[lastIndex];
        }
    }
}