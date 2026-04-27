using ConsoleApp1;
using System;
using System.Diagnostics;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.Unicode;

int N = 100;
int[] sizes = { N, N * N, N * N * N }; // 100, 10,000, 1,000,000

Console.WriteLine("Дослідження швидкодії (час у наносекундах):");
Console.WriteLine("-----------------------------------------------------------------");
Console.WriteLine("{0,10} | {1,20} | {2,20}", "Розмір", "Radix Binary", "Bubble Sort");
Console.WriteLine("-----------------------------------------------------------------");

foreach (int size in sizes)
{
    int[] originalData = GenerateData(size);

    int[] dataForRadix = (int[])originalData.Clone();
    long radixTime = MeasureNanoTime(() => SortingAlgorithms.RadixBinarySort(dataForRadix));

    string bubbleResult;
    if (size <= 10000)
    {
        int[] dataForBubble = (int[])originalData.Clone();
        long bubbleTime = MeasureNanoTime(() => SortingAlgorithms.BubbleSort(dataForBubble));
        bubbleResult = bubbleTime.ToString("N0");
    }
    else
    {
        bubbleResult = "Занадто довго (> O(N²))";
    }

    Console.WriteLine("{0,10} | {1,20:N0} | {2,20}", size, radixTime, bubbleResult);
}

Console.WriteLine("\n--- Аналіз для Завдання 3 (N=10,000) ---");
RunAnalysis(10000);

int[] GenerateData(int size)
{
    Random rand = new Random();
    int[] arr = new int[size];
    for (int i = 0; i < size; i++) arr[i] = rand.Next(0, int.MaxValue);
    return arr;
}

long MeasureNanoTime(Action action)
{
    action();

    Stopwatch sw = Stopwatch.StartNew();
    action();
    sw.Stop();

    return (long)(sw.Elapsed.TotalMilliseconds * 1000000);
}

void RunAnalysis(int size)
{
    int[] sorted = Enumerable.Range(0, size).ToArray();
    int[] reverse = Enumerable.Range(0, size).Reverse().ToArray();
    int[] random = GenerateData(size);

    Console.WriteLine("{0,-15} | {1,15} | {2,15}", "Тип масиву", "Radix (нс)", "Bubble (нс)");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine("{0,-15} | {1,15:N0} | {2,15:N0}", "Відсортований",
        MeasureNanoTime(() => SortingAlgorithms.RadixBinarySort(sorted)),
        MeasureNanoTime(() => SortingAlgorithms.BubbleSort(sorted)));

    Console.WriteLine("{0,-15} | {1,15:N0} | {2,15:N0}", "Зворотний",
        MeasureNanoTime(() => SortingAlgorithms.RadixBinarySort(reverse)),
        MeasureNanoTime(() => SortingAlgorithms.BubbleSort(reverse)));

    Console.WriteLine("{0,-15} | {1,15:N0} | {2,15:N0}", "Випадковий",
        MeasureNanoTime(() => SortingAlgorithms.RadixBinarySort(random)),
        MeasureNanoTime(() => SortingAlgorithms.BubbleSort(random)));
}
