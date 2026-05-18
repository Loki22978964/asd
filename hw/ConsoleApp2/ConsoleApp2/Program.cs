using ConsoleApp2;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ДОМАШНЯ РОБОТА: Обчислювальні алгоритми ===");
            Console.WriteLine("1. Завдання 1: Вирішення СЛАР методом LUP-розкладання");
            Console.WriteLine("2. Завдання 2: Вирішення диференційного рівняння 2-го порядку (Рунге-Кутта)");
            Console.WriteLine("0. Вихід");
            Console.Write("\nОберіть пункт меню: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ExecuteTask1();
                    break;
                case "2":
                    ExecuteTask2();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Натисніть будь-яку клавішу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ExecuteTask1()
    {
        Console.Clear();
        Console.WriteLine("--- Завдання 1: LUP-розклад ---");

        Console.Write("Введіть розмірність матриці (для вашого варіанту - 3): ");
        int n = int.Parse(Console.ReadLine());

        double[,] A = new double[n, n];
        double[] b = new double[n];

        Console.WriteLine("Введіть коефіцієнти матриці A рядками:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i},{j}] = ");
                A[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Введіть елементи вектора правої частини b:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"b[{i}] = ");
            b[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("\n--- Задана система лінійних алгебраїчних рівнянь ---");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"({A[i, j]:F2})*x{j + 1} ");
                if (j < n - 1) Console.Write("+ ");
            }
            Console.WriteLine($"= {b[i]:F2}");
        }

        var (L, U, P) = LupSolver.Decompose(A);

        double[] y = LupSolver.ForwardSubstitution(L, b, P);
        double[] x = LupSolver.BackwardSubstitution(U, y);

        PrintMatrix("Матриця L (одинична нижня-трикутна):", L);
        PrintMatrix("Матриця U (верхня-трикутна):", U);

        double[,] pMatrix = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            pMatrix[i, P[i]] = 1.0;
        }
        PrintMatrix("Матриця перестановки P:", pMatrix);

        Console.WriteLine("\n--- Розв'язок системи (Вектор X) ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"x{i + 1} = {x[i]:F6}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
        Console.ReadKey();
    }

    static void ExecuteTask2()
    {
        Console.Clear();
        Console.WriteLine("--- Завдання 2: Метод Рунге-Кутти 4-го порядку ---");

        double t0 = 0;
        double tEnd = 5.0;
        double h = 0.1;

        double[] Y0 = { 1.0, 0.0 };

        RungeKuttaSolver.SystemEquations mySystem = (t, Y) => {
            double[] dY = new double[2];
            dY[0] = Y[1];
            dY[1] = -2 * Y[1] - 5 * Y[0];
            return dY;
        };

        var points = RungeKuttaSolver.Solve(mySystem, Y0, t0, tEnd, h);

        Console.WriteLine("\nРезультати обчислень:");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{"t",-8} | {"y (Функція)",-15} | {"y' (Похідна)",-15}");
        Console.WriteLine("------------------------------------------");

        List<double> tValues = new List<double>();
        List<double> yValues = new List<double>();
        List<double> dyValues = new List<double>();

        foreach (var point in points)
        {
            Console.WriteLine($"{point.t,-8:F2} | {point.Y[0],-15:F6} | {point.Y[1],-15:F6}");

            tValues.Add(point.t);
            yValues.Add(point.Y[0]);
            dyValues.Add(point.Y[1]);
        }
        Console.WriteLine("------------------------------------------");

        try
        {
            Console.WriteLine("\nГенерація графіка... Зачекайте.");

            var plot = new ScottPlot.Plot();

            var sigY = plot.Add.Scatter(tValues.ToArray(), yValues.ToArray());
            sigY.LegendText = "y (Функція)";
            sigY.LineWidth = 2;

            var sigDy = plot.Add.Scatter(tValues.ToArray(), dyValues.ToArray());
            sigDy.LegendText = "y' (Похідна)";
            sigDy.LineWidth = 2;

            plot.Title("Рішення диф. рівняння 2-го порядку (Метод РК4)");
            plot.XLabel("Час (t)");
            plot.YLabel("Значення");
            plot.ShowLegend();

            string fileName = "F:\\asd\\hw\\ConsoleApp2\\ConsoleApp2\\differential_equation_graph.png";
            plot.SavePng(fileName, 800, 600);
            Console.WriteLine($"Графік успішно збережено у файл: {System.IO.Path.GetFullPath(fileName)}");

            ScottPlot.WinForms.FormsPlotViewer.Launch(plot, "Графік диф. рівняння");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при створенні графіка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
        Console.ReadKey();
    }

    static void PrintMatrix(string title, double[,] matrix)
    {
        Console.WriteLine($"\n{title}");
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F3} ");
            }
            Console.WriteLine();
        }
    }
}