using GPK.SecondLab.Models.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.Nodes
{

    public class TreeNode<T> : AbstractTreeNode<T>
        where T : new()
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }


        public TreeNode(T value) : base(value)
        {
        }
        public TreeNode() 
        {
        }
 
    }
}
