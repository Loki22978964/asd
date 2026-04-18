using ConsoleApp1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BinaryTree
{
    public class BinaryTree
    {
        public Node _root;

        public void Add(Product product)
        {
            _root = Insert(product, _root);
        }

        private Node Insert(Product product, Node node)
        {
            if(node == null)
            {
                return new Node(product);
            }
            if(node.Data.Id > product.Id)
            {
                node.Left = Insert(product, node.Left);
            }
            else
            {
                node.Right = Insert(product, node.Right);
            }

            return node;
        }

        public void FindProduct(int id)
        {
            Node temp = FindProductRecursive(id, _root);

            if (temp is not null) 
            {
                Console.WriteLine($"Node: {temp.Data.Name} Id: {temp.Data.Id} Price: {temp.Data.Price}");
            }
        }

        private Node FindProductRecursive(int id, Node? node)
        {
            if(node == null)
            {
                return null;
            }

            if(node.Data.Id < id)
            {
                return FindProductRecursive(id, node.Left);
            }

            return FindProductRecursive(id, node.Right);
        }

        public int ShowLowStock(int threshold)
        {
            return TraverseAndCheck(_root, threshold);
        }

        private int TraverseAndCheck(Node root, int threshold)
        {
            // some code to ShowLowStock method
            return Int16.MinValue;
        }
    }
}
