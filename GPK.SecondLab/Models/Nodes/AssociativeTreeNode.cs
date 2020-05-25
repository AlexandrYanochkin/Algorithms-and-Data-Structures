using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.Nodes
{
    public class AssociativeTreeNode<T> : AbstractTreeNode<T>
        where T : new()
    {
        public int Left { get; set; }
        public int Right { get; set; }


        public AssociativeTreeNode(T value) : base(value)
        {
            Left = Right = -1;
        }

        public AssociativeTreeNode()
        {
        }

    }
}
