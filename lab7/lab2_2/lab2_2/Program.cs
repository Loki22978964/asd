using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab_2_2_Identification
{
    enum State { Start, Underscore, Digits, Hash1, HashOrAmp, Letters, Final, Error }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Task1();

            Task2();

            Task3();
        }

        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1 ---");
            string pattern = @"^%\d+(##|#%)[A-Z]*%$";
            string filePath = "input1.txt";

            if (!File.Exists(filePath))
                File.WriteAllLines(filePath, new[] { "%123##ABC%", "%5#%XYZ%", "invalid", "%12##%", "123##ABC%" });

            Console.WriteLine("Знайдені слова:");
            foreach (string line in File.ReadLines(filePath))
            {
                if (Regex.IsMatch(line.Trim(), pattern))
                    Console.WriteLine(line);
            }
        }

        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2 (Скінченний автомат switch) ---");
            Console.Write("Уведіть рядок для перевірки (_\\d+#(#|&)[A-Z]*%): ");
            string input = Console.ReadLine();

            State currentState = State.Start;

            foreach (char c in input)
            {
                switch (currentState)
                {
                    case State.Start:
                        currentState = (c == '_') ? State.Underscore : State.Error;
                        break;
                    case State.Underscore:
                        currentState = char.IsDigit(c) ? State.Digits : State.Error;
                        break;
                    case State.Digits:
                        if (char.IsDigit(c)) currentState = State.Digits;
                        else if (c == '#') currentState = State.Hash1;
                        else currentState = State.Error;
                        break;
                    case State.Hash1:
                        currentState = (c == '#' || c == '&') ? State.HashOrAmp : State.Error;
                        break;
                    case State.HashOrAmp:
                        if (char.IsUpper(c)) currentState = State.Letters;
                        else if (c == '%') currentState = State.Final;
                        else currentState = State.Error;
                        break;
                    case State.Letters:
                        if (char.IsUpper(c)) currentState = State.Letters;
                        else if (c == '%') currentState = State.Final;
                        else currentState = State.Error;
                        break;
                    case State.Final:
                        currentState = State.Error;
                        break;
                }
                if (currentState == State.Error) break;
            }

            if (currentState == State.Final)
                Console.WriteLine("Результат: Образ розпізнано!");
            else
                Console.WriteLine("Результат: Помилка синтаксису.");
        }

        static void Task3()
        {
            Console.WriteLine("\n--- Завдання 3 (Таблиця переходів) ---");

            var transitions = new Dictionary<(State, string), State>
            {
                { (State.Start, "_"), State.Underscore },
                { (State.Underscore, "digit"), State.Digits },
                { (State.Digits, "digit"), State.Digits },
                { (State.Digits, "#"), State.Hash1 },
                { (State.Hash1, "#"), State.HashOrAmp },
                { (State.Hash1, "&"), State.HashOrAmp },
                { (State.HashOrAmp, "letter"), State.Letters },
                { (State.HashOrAmp, "%"), State.Final },
                { (State.Letters, "letter"), State.Letters },
                { (State.Letters, "%"), State.Final }
            };

            string filePath = "input3.txt";
            
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "_123#&ABC%@_99##%~неправильне_слово");

            string content = File.ReadAllText(filePath);
            string[] words = Regex.Split(content, "[@~]");

            Console.WriteLine("{0,-20} | {1}", "Слово", "Валідність");
            Console.WriteLine(new string('-', 35));

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                State current = State.Start;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    string type = GetCharType(c);

                    if (transitions.TryGetValue((current, type), out State next))
                        current = next;
                    else
                    {
                        current = State.Error;
                        break;
                    }
                }

                Console.WriteLine("{0,-20} | {1}", word, current == State.Final ? "OK" : "Error");
            }
        }

        static string GetCharType(char c)
        {
            if (char.IsDigit(c)) return "digit";
            if (char.IsUpper(c)) return "letter";
            if (c == '_') return "_";
            if (c == '#') return "#";
            if (c == '&') return "&";
            if (c == '%') return "%";
            return "unknown";
        }
    }
}