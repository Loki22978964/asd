using lab5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.DataStructure
{
    internal class BSTree
    {
        public Node Root { get; private set; }

        // --- Методи ротації (Рівень 2) ---
        private Node RotateRight(Node y)
        {
            Node x = y.left;
            y.left = x.right;
            x.right = y;
            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.right;
            x.right = y.left;
            y.left = x;
            return y;
        }

        // --- Вставка в корінь через ротації (Рівень 2) ---
        public void InsertAtRoot(Student student)
        {
            Root = InsertAtRootRecursive(Root, student);
        }

        private Node InsertAtRootRecursive(Node node, Student student)
        {
            if (node == null) return new Node(student);

            if (student.AverageGrade < node.data.AverageGrade)
            {
                node.left = InsertAtRootRecursive(node.left, student);
                return RotateRight(node);
            }
            else
            {
                node.right = InsertAtRootRecursive(node.right, student);
                return RotateLeft(node);
            }
        }

        // --- Оптимізація/Балансування (Рівень 3) ---
        public void Optimize()
        {
            List<Student> students = new List<Student>();
            InOrderTraversal(Root, students);
            Root = BuildBalanced(students, 0, students.Count - 1);
        }

        private void InOrderTraversal(Node node, List<Student> list)
        {
            if (node == null) return;
            InOrderTraversal(node.left, list);
            list.Add(node.data);
            InOrderTraversal(node.right, list);
        }

        private Node BuildBalanced(List<Student> list, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            Node node = new Node(list[mid]);
            node.left = BuildBalanced(list, start, mid - 1);
            node.right = BuildBalanced(list, mid + 1, end);
            return node;
        }

        // Пошук за ключем (Рівень 2, 3)
        public Node Search(double grade)
        {
            Node current = Root;
            while (current != null)
            {
                if (Math.Abs(current.data.AverageGrade - grade) < 0.001) return current;
                current = (grade < current.data.AverageGrade) ? current.left : current.right;
            }
            return null;
        }

        // Обхід у ширину (BFS)
        public void PrintBFS()
        {
            if (Root == null) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                Console.WriteLine(node.data);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
    }
}
