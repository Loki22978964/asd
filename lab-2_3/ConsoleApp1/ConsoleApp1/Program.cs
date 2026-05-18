using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace CombinatoricsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА 2.3: ДОСЛІДЖЕННЯ КОМБІНАТОРНИХ АЛГОРИТМІВ ===");
            Console.WriteLine("Варіант 2\n");

            Console.WriteLine("--- Завдання першого рівня ---");
            Console.WriteLine("Умова: Група студентів – 20 осіб. Скільки різних за складом підгруп з 12 осіб можна сформувати?");

            Console.WriteLine("Тип вибірки: Комбінації без повторень (порядок членів у підгрупі не має значення).");

            int n1 = 20;
            int k1 = 12;
            BigInteger resultLevel1 = CalculateCombinations(n1, k1);
            Console.WriteLine($"Результат: Кількість можливих підгруп = {resultLevel1}\n");


            Console.WriteLine("--- Завдання другого рівня ---");
            Console.WriteLine("Умова: A[] = {8, 4, 9, 2, 4, 8, 1, 8, 2, 5, 8, 1, 1}. Визначити кількість різних масивів, що можна сформувати.");

            Console.WriteLine("Тип вибірки: Перестановки з повтореннями (переставляємо елементи, серед яких є однакові).");

            int[] array = { 8, 4, 9, 2, 4, 8, 1, 8, 2, 5, 8, 1, 1 };
            BigInteger resultLevel2 = CalculatePermutationsWithRepeats(array);
            Console.WriteLine($"Результат: Кількість різних масивів = {resultLevel2}\n");


            Console.WriteLine("--- Завдання третього рівня ---");
            string fileName = @"F:\asd\lab-2_3\ConsoleApp1\ConsoleApp1\res\combinations_level1.txt";
            Console.WriteLine($"Генерація та запис усіх комбінацій для Завдання 1 у файл '{fileName}'...");

            try
            {
                GenerateAndSaveCombinations(n1, k1, fileName);
                Console.WriteLine("Всі комбінації успішно записані у файл!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при записі у файл: {ex.Message}");
            }

            Console.WriteLine("\nРоботу завершено. Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        static BigInteger Factorial(int number)
        {
            BigInteger result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        static BigInteger CalculateCombinations(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static BigInteger CalculatePermutationsWithRepeats(int[] elements)
        {
            int totalCount = elements.Length;

            var frequencies = elements.GroupBy(x => x)
                                      .Select(g => g.Count())
                                      .ToList();

            BigInteger numerator = Factorial(totalCount);
            BigInteger denominator = 1;

            foreach (int count in frequencies)
            {
                denominator *= Factorial(count);
            }

            return numerator / denominator;
        }

        static void GenerateAndSaveCombinations(int n, int k, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int[] combination = Enumerable.Range(1, k).ToArray();
                long counter = 0;

                while (combination != null)
                {
                    writer.WriteLine($"Підгрупа {++counter}: [{string.Join(", ", combination)}]");

                    int i = k - 1;
                    while (i >= 0 && combination[i] == n - k + i + 1)
                    {
                        i--;
                    }

                    if (i < 0)
                    {
                        combination = null;
                    }
                    else
                    {
                        combination[i]++;
                        for (int j = i + 1; j < k; j++)
                        {
                            combination[j] = combination[j - 1] + 1;
                        }
                    }
                }
            }
        }
    }
}