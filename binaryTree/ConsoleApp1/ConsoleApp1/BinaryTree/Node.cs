using ConsoleApp1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BinaryTree
{
    public class Node
    {
        public Product Left {  get; set; }
        public Product Right { get; set; }
        public Product Data { get; set; }

        public Node(Product product)
        {
            this.Data = product;
        }
    }
}
