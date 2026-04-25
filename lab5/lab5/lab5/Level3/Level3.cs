using lab5.DataStructure;
using lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Level3
{
    public class Level3
    {
        public void Execute()
        {
            BSTree tree = new BSTree();
            Console.WriteLine("\n--- Level 3: Optimization (Balancing) ---");

            // Наповнюємо дерево
            tree.InsertAtRoot(new Student("Student1", "A", "G1", 60.0, "None"));
            tree.InsertAtRoot(new Student("Student2", "B", "G1", 70.0, "None"));
            tree.InsertAtRoot(new Student("Student3", "C", "G1", 80.0, "None"));
            tree.InsertAtRoot(new Student("Student4", "D", "G1", 90.0, "None"));

            Console.WriteLine("Tree before optimization (Highly unbalanced):");
            tree.PrintBFS();

            tree.Optimize();

            Console.WriteLine("\nTree after optimization (Balanced BFS):");
            tree.PrintBFS();
        }
    }
}
