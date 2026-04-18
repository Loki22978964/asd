using ConsoleApp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BinaryTree
{
    public class Node
    {
        public Student Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Student Data)
        {
            this.Data = Data;
        }
    }
}
