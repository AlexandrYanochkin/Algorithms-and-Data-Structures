using GPK.SecondLab.Models.ExceptionsClasses;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.AssociativeTree
{
    public partial class AssociativeTree<T> : ITree<T>
        where T : new()
    {
        public AssociativeTreeNode<T> Root { get; private set; }

        private AssociativeTreeNode<T>[] AssociativeTreeNodes = new AssociativeTreeNode<T>[8];

        public int Count { get; private set; }


        public AssociativeTree(T data) : this(new AssociativeTreeNode<T>(data))
        {
        }

        public AssociativeTree(AssociativeTreeNode<T> treeNode)
        {
            Root = treeNode ?? throw new ArgumentNullException("Root can't be null");
            AssociativeTreeNodes[Count++] = Root;
        }

        public AssociativeTree()
        {
        }



        public void AddNode(T value)
            => AddNode(new AssociativeTreeNode<T>(value));

        public void AddNode(AssociativeTreeNode<T> nodeForAdd)
        {
            if(Root == null)
            {
                Root = nodeForAdd;
                AssociativeTreeNodes[Count++] = Root;
            }
            else
                AddNode(Root, nodeForAdd);
        }

        private void AddNode(AssociativeTreeNode<T> treeNode,AssociativeTreeNode<T> nodeForAdd)
        {
            if (nodeForAdd > treeNode)
            {
                if (treeNode.Right == -1)
                {
                    if (Count == AssociativeTreeNodes.Length)
                        Array.Resize(ref AssociativeTreeNodes, Count * 2);

                    treeNode.Right = Count;
                    AssociativeTreeNodes[Count++] = nodeForAdd;
                }
                else
                    AddNode(AssociativeTreeNodes[treeNode.Right], nodeForAdd);
            }
            else if (nodeForAdd < treeNode)
            {
                if (treeNode.Left == -1)
                {
                    if (Count == AssociativeTreeNodes.Length)
                        Array.Resize(ref AssociativeTreeNodes, Count * 2);

                    treeNode.Left = Count;
                    AssociativeTreeNodes[Count++] = nodeForAdd;
                }
                else
                    AddNode(AssociativeTreeNodes[treeNode.Left], nodeForAdd);
            }
            else 
                throw new TreeException("The Tree contains the element");
                         
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

        private AssociativeTreeNode<T> GetMaxNode(AssociativeTreeNode<T> treeNode)
            => ((treeNode != null && treeNode.Right != -1) ? GetMaxNode(AssociativeTreeNodes[treeNode.Right]) : treeNode);

        private AssociativeTreeNode<T> GetMinNode(AssociativeTreeNode<T> treeNode)
          => ((treeNode != null && treeNode.Left != -1) ? GetMinNode(AssociativeTreeNodes[treeNode.Left]) : treeNode);



        public void View(ITreePrinter<T> treePrinter)
            => treePrinter.PrintTree(this);
    }
}
