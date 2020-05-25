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
        public bool Contains(T value)
            => Contains(new AssociativeTreeNode<T>(value));
        public bool Contains(AssociativeTreeNode<T> treeNode)
            => Contains(Root, treeNode);
        private bool Contains(AssociativeTreeNode<T> treeNode, AssociativeTreeNode<T> nodeForSearch)
        {
            if (treeNode != null)
            {
                var rightNode = (treeNode.Right != -1) ? AssociativeTreeNodes[treeNode.Right] : null;
                var leftNode = (treeNode.Left != -1) ? AssociativeTreeNodes[treeNode.Left] : null;
                
                if (nodeForSearch > treeNode)
                    return Contains(rightNode, nodeForSearch);
                else if (nodeForSearch < treeNode)
                    return Contains(leftNode, nodeForSearch);
               
            }

            return (treeNode != null && treeNode.Equals(nodeForSearch));
        }

        private AssociativeTreeNode<T> FindNode(AssociativeTreeNode<T> treeNode)
                => FindNode(Root, treeNode);

        private AssociativeTreeNode<T> FindNode(AssociativeTreeNode<T> treeNode, AssociativeTreeNode<T> nodeForSearch)
        {
            if (treeNode != null)
            {
                var leftNode = (treeNode.Left != -1) ? AssociativeTreeNodes[treeNode.Left] : null;
                var rightNode = (treeNode.Right != -1) ? AssociativeTreeNodes[treeNode.Right] : null;

                if (nodeForSearch > treeNode)
                    return FindNode(rightNode, nodeForSearch);
                else if (nodeForSearch < treeNode)
                    return FindNode(leftNode, nodeForSearch);
                else
                    return treeNode;
            }

            throw new TreeException("Can't Find the node!");
        }

        private AssociativeTreeNode<T> FindPrev(AssociativeTreeNode<T> treeNode)
                => FindPrev(Root, treeNode);

        private AssociativeTreeNode<T> FindPrev(AssociativeTreeNode<T> treeNode,AssociativeTreeNode<T> nodeForSearch)
        {
            if (treeNode != null)
            {
                var leftNode = (treeNode.Left != -1) ? AssociativeTreeNodes[treeNode.Left] : null;
                var rightNode = (treeNode.Right != -1) ? AssociativeTreeNodes[treeNode.Right] : null;

                if (nodeForSearch > treeNode)
                    return nodeForSearch.Equals(rightNode) ? treeNode : FindPrev(rightNode, nodeForSearch);
                else if (nodeForSearch < treeNode)
                    return nodeForSearch.Equals(leftNode) ? treeNode : FindPrev(leftNode, nodeForSearch);
            }

            throw new TreeException("Can't Find the node!");
        }

        private int FindIndexOfNode(AssociativeTreeNode<T> nodeForSearch)
        {
            int index = -1;

            for (int i = 0; i < Count && (index == -1); i++)
                if (nodeForSearch.Equals(AssociativeTreeNodes[i]))
                    index = i;

            return index;
        }
    }
}
