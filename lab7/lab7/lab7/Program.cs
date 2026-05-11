using System;

namespace Lab_2_1_NumericalMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Лабораторна робота 2.1: Варіант 2 ===");
                Console.WriteLine("1. Завдання 1: Числове інтегрування");
                Console.WriteLine("2. Завдання 2: Корені рівняння");
                Console.WriteLine("3. Завдання 3: Диференціальне рівняння");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть завдання: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "0": return;
                }
                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        // 1
        static double F1(double x) => Math.Sin(Math.Exp(x / 3.0) + x);

        static void Task1()
        {
            Console.WriteLine("\n[Завдання 1] Інтеграл sin(e^(x/3)+x) від a до b");
            Console.Write("Введіть a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введіть b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введіть крок h : ");
            double h = double.Parse(Console.ReadLine());

            int n = (int)((b - a) / h);

            double rectSum = 0;
            for (int i = 0; i < n; i++) rectSum += F1(a + h * (i + 0.5));

            double trapSum = (F1(a) + F1(b)) / 2.0;
            for (int i = 1; i < n; i++) trapSum += F1(a + i * h);

            double simpSum = F1(a) + F1(b);
            for (int i = 1; i < n; i++)
                simpSum += (i % 2 == 0 ? 2 : 4) * F1(a + i * h);

            Console.WriteLine($"Метод прямокутників: {rectSum * h:F6}");
            Console.WriteLine($"Метод трапецій: {trapSum * h:F6}");
            Console.WriteLine($"Метод Сімпсона: {(simpSum * h / 3.0):F6}");
        }

        // 2
        static double F2(double x) => Math.Pow(x, 2) - 2 * Math.Log(x + 1);
        static double DF2(double x) => 2 * x - 2 / (x + 1);

        static void Task2()
        {
            Console.WriteLine("\n[Завдання 2] Корінь x^2 - 2ln(x+1) = 0");
            Console.Write("Введіть початок інтервалу a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введіть кінець інтервалу b: ");
            double b = double.Parse(Console.ReadLine());
            double eps = 0.0001;

            if (F2(a) * F2(b) > 0)
            {
                Console.WriteLine("На цьому інтервалі коренів може не бути або їх парна кількість.");
            }

            double a1 = a, b1 = b, x1 = 0;
            while ((b1 - a1) > eps)
            {
                x1 = (a1 + b1) / 2;
                if (F2(a1) * F2(x1) <= 0) b1 = x1; else a1 = x1;
            }
            Console.WriteLine($"Метод половинчастого ділення: {x1:F6}");

            double a2 = a, b2 = b, x2 = a;
            for (int i = 0; i < 100; i++)
            {
                x2 = a2 - (F2(a2) * (b2 - a2)) / (F2(b2) - F2(a2));
                if (Math.Abs(F2(x2)) < eps) break;
                if (F2(a2) * F2(x2) < 0) b2 = x2; else a2 = x2;
            }
            Console.WriteLine($"Метод хорд: {x2:F6}");

            double x3 = b;
            for (int i = 0; i < 100; i++)
            {
                double nextX = x3 - F2(x3) / DF2(x3);
                if (Math.Abs(nextX - x3) < eps) { x3 = nextX; break; }
                x3 = nextX;
            }
            Console.WriteLine($"Метод дотичних: {x3:F6}");
        }

        // 3
        static double DY(double x, double y) => x * x; // dy/dx = x^2

        static void Task3()
        {
            Console.WriteLine("\n[Завдання 3] Рівняння dy/dx = x^2 (Метод Рунге-Кутта 4-го порядку)");
            Console.Write("Введіть початкове x0: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введіть початкове y0: ");
            double y = double.Parse(Console.ReadLine());
            Console.Write("Введіть кінцеве x_end: ");
            double x_end = double.Parse(Console.ReadLine());
            Console.Write("Введіть крок h: ");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("\n{0,10} | {1,10}", "x", "y");
            Console.WriteLine("-------------------------");

            while (x <= x_end + h / 2)
            {
                Console.WriteLine("{0,10:F4} | {1,10:F6}", x, y);

                double k1 = h * DY(x, y);
                double k2 = h * DY(x + h / 2, y + k1 / 2);
                double k3 = h * DY(x + h / 2, y + k2 / 2);
                double k4 = h * DY(x + h, y + k3);

                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6.0;
                x += h;
            }
        }
    }
}