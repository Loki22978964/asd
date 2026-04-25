using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Model
{
    public class Node
    {
        public Student data;
        public Node left;
        public Node right;

        public Node(Student data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
