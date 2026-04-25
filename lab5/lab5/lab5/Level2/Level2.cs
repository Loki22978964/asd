using lab5.DataStructure;
using lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Level2
{
    public class Level2
    {
        public void Execute()
        {
            BSTree tree = new BSTree();
            Console.WriteLine("--- Level 2: Root Insertion (Rotations) ---");

            // Тестові дані
            Student[] students = {
                new Student("Ivanov", "Petro", "CS-101", 85.5, "Football"),
                new Student("Koval", "Oleh", "CS-101", 78.3, "Tennis"),
                new Student("Shevchenko", "Andrii", "CS-102", 90.2, "Basketball")
            };

            foreach (var s in students)
            {
                Console.WriteLine($"\nInserting: {s.LastName} (Grade: {s.AverageGrade})");
                tree.InsertAtRoot(s);
                Console.WriteLine("Current Tree (BFS):");
                tree.PrintBFS();
            }

            double searchKey = 78.3;
            var result = tree.Search(searchKey);
            Console.WriteLine(result != null ? $"\nFound: {result.data}" : "\nNot found");
        }
    }
}
