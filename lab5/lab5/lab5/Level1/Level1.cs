using System;
using System.Collections.Generic;
using lab5.Model;

namespace lab5.Level1
{
    public class Level1
    {
        public void Execute()
        {
            List<Student> students = new List<Student>();

            AddUniqueStudent(students, new Student("Ivanov", "Petro", "CS-101", 85.5, "Football"));
            AddUniqueStudent(students, new Student("Shevchenko", "Andrii", "CS-102", 90.2, "Basketball"));
            AddUniqueStudent(students, new Student("Koval", "Oleh", "CS-101", 78.3, "Tennis"));
            AddUniqueStudent(students, new Student("Melnyk", "Ihor", "CS-103", 88.8, "Swimming"));
            AddUniqueStudent(students, new Student("Bondarenko", "Serhii", "CS-104", 92.1, "Boxing"));
            AddUniqueStudent(students, new Student("Tkachenko", "Dmytro", "CS-102", 74.6, "Football"));
            AddUniqueStudent(students, new Student("Kravchenko", "Yurii", "CS-105", 81.0, "Volleyball"));
            AddUniqueStudent(students, new Student("Lysenko", "Maksym", "CS-101", 69.4, "Chess"));
            AddUniqueStudent(students, new Student("Hrytsenko", "Roman", "CS-103", 95.3, "Swimming"));
            AddUniqueStudent(students, new Student("Polishchuk", "Denys", "CS-104", 87.7, "Basketball"));
            AddUniqueStudent(students, new Student("Savchenko", "Artem", "CS-105", 76.9, "Football"));
            AddUniqueStudent(students, new Student("Marchenko", "Oleksii", "CS-102", 84.2, "Tennis"));
            AddUniqueStudent(students, new Student("Rudenko", "Vladyslav", "CS-103", 91.5, "Boxing"));
            AddUniqueStudent(students, new Student("Mazur", "Taras", "CS-101", 73.8, "Chess"));
            AddUniqueStudent(students, new Student("Zakharchenko", "Bohdan", "CS-104", 89.9, "Volleyball"));
            AddUniqueStudent(students, new Student("Danylenko", "Vitalii", "CS-105", 82.4, "Swimming"));
            AddUniqueStudent(students, new Student("Shapoval", "Kyrylo", "CS-102", 77.1, "Basketball"));
            AddUniqueStudent(students, new Student("Klymenko", "Mykhailo", "CS-103", 93.6, "Football"));
            AddUniqueStudent(students, new Student("Yatsenko", "Oleksandr", "CS-104", 68.2, "Tennis"));
            AddUniqueStudent(students, new Student("Horbenko", "Illia", "CS-105", 86.0, "Boxing"));

            Console.WriteLine("--- Initial list of students (Unordered) ---");
            PrintList(students);

            students.Sort();
            Console.WriteLine("\n--- Sorted list for Binary Search ---");
            PrintList(students);

            double searchKey = 76.9;
            int foundIndex = BinarySearch(students.ToArray(), searchKey);

            // 5. Виконання завдання: видалити, якщо футбол
            if (foundIndex != -1)
            {
                Student found = students[foundIndex];
                Console.WriteLine($"\nFound student with grade {searchKey}: {found.LastName}");

                if (found.Sport.Equals("Football", StringComparison.OrdinalIgnoreCase))
                {
                    students.RemoveAt(foundIndex);
                    Console.WriteLine("Action: Student plays football -> REMOVED.");

                    Console.WriteLine("\n--- Final list of students ---");
                    PrintList(students);
                }
                else
                {
                    Console.WriteLine("Action: Student does not play football -> NO DELETION.");
                }
            }
            else
            {
                Console.WriteLine($"\nStudent with grade {searchKey} not found.");
            }
        }

        private void AddUniqueStudent(List<Student> list, Student s)
        {
            foreach (var item in list)
            {
                if (item.AverageGrade == s.AverageGrade) return;
            }
            list.Add(s);
        }

        private int BinarySearch(Student[] arr, double key)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (Math.Abs(arr[mid].AverageGrade - key) < 0.001) return mid;
                if (arr[mid].AverageGrade < key) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        private void PrintList(List<Student> list)
        {
            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}