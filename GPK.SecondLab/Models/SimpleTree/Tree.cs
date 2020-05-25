using GPK.SecondLab.Models.ExceptionsClasses;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.SimpleTree
{
    public partial class Tree<T> : ITree<T>
        where T : new()
    {
        public TreeNode<T> Root { get; private set; }


        public Tree(T data) : this(new TreeNode<T>(data))
        {
        }

        public Tree(TreeNode<T> treeNode)
        {
            Root = treeNode ?? throw new TreeException("The node can't be null");
        }

        public Tree()
        {
        }



        public void AddNode(T data)
            => AddNode(new TreeNode<T>(data));

        public void AddNode(TreeNode<T> nodeForAdd)
        {
            if (Root == null)
                Root = nodeForAdd;
            else
                AddNode(Root, nodeForAdd);
        }

        void AddNode(TreeNode<T> nodeOfTree, TreeNode<T> nodeForAdd)
        {
            if (nodeForAdd > nodeOfTree)
            {
                if (nodeOfTree.Right == null)
                {
                    nodeOfTree.Right = nodeForAdd;
                   // Root = Balance(Root);
                }
                else
                    AddNode(nodeOfTree.Right, nodeForAdd);
            }
            else if (nodeForAdd < nodeOfTree)
            {
                if (nodeOfTree.Left == null)
                {
                    nodeOfTree.Left = nodeForAdd;
                   // Root = Balance(Root);
                }
                else
                    AddNode(nodeOfTree.Left, nodeForAdd);
            }
            else
                throw new TreeException("The element already exists in a Tree");

        }


        public T GetMaxNode()
        {
            var maxNode = GetMaxNode(Root);

            return (maxNode != null) ? maxNode.Value : throw new TreeException("The tree is empty!!!"); 
        }

        public T GetMinNode()
        {
            var minNode = GetMinNode(Root);

            return (minNode != null) ? minNode.Value : throw new TreeException("The tree is empty!!!");
        }

        TreeNode<T> GetMaxNode(TreeNode<T> startNode)
               => ((startNode?.Right == null) ? startNode : GetMaxNode(startNode.Right));     
         
        TreeNode<T> GetMinNode(TreeNode<T> startNode)
               => ((startNode?.Left == null) ? startNode : GetMinNode(startNode.Left));
     

        public void View(ITreePrinter<T> treePrinter)
            => treePrinter.PrintTree(this);
    }

}
