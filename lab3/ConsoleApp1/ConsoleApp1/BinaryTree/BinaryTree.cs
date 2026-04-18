using ConsoleApp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.BinaryTree
{
    public class BinaryTree
    {
        private Node _root;

        public void Add(Student st)
        {
            _root = Insert(_root, st);
        }

        private Node Insert(Node node, Student st)
        {
            if(node == null) return new Node(st);

            if (string.Compare(st.StudentId, node.Data.StudentId) < 0)
            { 
                node.Left = Insert(node.Left, st); 
            }
            else
            {
                node.Right = Insert(node.Right, st);
            }
                
            return node;
        }

        public void PrintTable()
        {
            Console.WriteLine($"{"Last Name",-12} | {"First Name",-10} | {"Course",-6} | {"ID Card",-10} | {"Birth Date",-12}");
            Console.WriteLine(new string('-', 65));
            InOrderTraversal(_root);
            Console.WriteLine();
        }

        private void InOrderTraversal(Node node)
        {
            if (node == null) return;
            InOrderTraversal(node.Left);
            var s = node.Data;
            Console.WriteLine($"{s.LastName,-12} | {s.FirstName,-10} | {s.Course,-6} | {s.StudentId,-10} | {s.BirthDate:MM/dd/yyyy}");
            InOrderTraversal(node.Right);
        }

        public void FindSpecificStudents()
        {
            Console.WriteLine("SEARCH RESULTS (3rd year, born in summer):");
            bool found = SearchCriteria(_root);
            if (!found) Console.WriteLine("No records found.");
            Console.WriteLine();
        }

        private bool SearchCriteria(Node node)
        {
            if (node == null) return false;
            bool left = SearchCriteria(node.Left);

            bool match = node.Data.Course == 3 &&
                         node.Data.BirthDate.Month >= 6 &&
                         node.Data.BirthDate.Month <= 8;

            if (match)
            {
                var s = node.Data;
                Console.WriteLine($"- {s.LastName} {s.FirstName} (ID: {s.StudentId})");
            }

            bool right = SearchCriteria(node.Right);
            return left || match || right;
        }

        public void DeleteSpecificStudents()
        {
            List<string> idsToDelete = new List<string>();
            CollectIDs(_root, idsToDelete);

            foreach (var id in idsToDelete)
            {
                _root = Remove(_root, id);
            }
            Console.WriteLine($"Nodes deleted: {idsToDelete.Count}\n");
        }

        private void CollectIDs(Node node, List<string> ids)
        {
            if (node == null) return;
            if (node.Data.Course == 3 && node.Data.BirthDate.Month >= 6 && node.Data.BirthDate.Month <= 8)
                ids.Add(node.Data.StudentId);

            CollectIDs(node.Left, ids);
            CollectIDs(node.Right, ids);
        }

        private Node Remove(Node node, string id)
        {
            if (node == null) return null;

            int cmp = string.Compare(id, node.Data.StudentId);
            if (cmp < 0) node.Left = Remove(node.Left, id);
            else if (cmp > 0) node.Right = Remove(node.Right, id);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                node.Data = MinValue(node.Right);
                node.Right = Remove(node.Right, node.Data.StudentId);
            }
            return node;
        }

        private Student MinValue(Node node)
        {
            Student min = node.Data;
            while (node.Left != null)
            {
                min = node.Left.Data;
                node = node.Left;
            }
            return min;
        }
    }
}
