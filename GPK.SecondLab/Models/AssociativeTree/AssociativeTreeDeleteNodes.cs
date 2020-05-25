using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.Nodes;
using System;

namespace GPK.SecondLab.Models.AssociativeTree
{
    public partial class AssociativeTree<T> : ITree<T>
        where T : new()
    {
        public void DeleteNode(T data)
            => DeleteNode(new AssociativeTreeNode<T>(data));

        public void DeleteNode(AssociativeTreeNode<T> treeNode)
        {           
            if (treeNode.Equals(Root))
                DeleteRoot();
            else
                DeleteNode(Root, treeNode);

            DeleteInArray(treeNode);
        }

        private void DeleteInArray(AssociativeTreeNode<T> treeNode)
        {
            int indexForRemove = FindIndexOfNode(treeNode);

            if (indexForRemove != -1)
            {
                Count--;
                RemoveInArray(indexForRemove);
                DecrementIndexes(indexForRemove);
            }
        }

        private void DeleteRoot()
        {
            if (Root.Left == -1 && Root.Right == -1)
                Root = null;
            else if ( (Root.Left != -1 && Root.Right == -1) || (Root.Left == -1 && Root.Right != -1) )
                Root = AssociativeTreeNodes[Math.Max(Root.Left,Root.Right)];
            else if(Root.Left != -1 && Root.Right != -1)
            {
                var nodeForSwap = AssociativeTreeNodes[Root.Right];

                while (nodeForSwap.Left != -1)
                    nodeForSwap = AssociativeTreeNodes[nodeForSwap.Left];

                DeleteNode(nodeForSwap);

                Root.Value = nodeForSwap.Value;
            }

        }

        private void DeleteNode(AssociativeTreeNode<T> treeNode, AssociativeTreeNode<T> nodeForRemove)
        {
            if(treeNode != null)
            {
                var rightNode = (treeNode.Right != -1) ? AssociativeTreeNodes[treeNode.Right] : null;
                var leftNode = (treeNode.Left != -1) ? AssociativeTreeNodes[treeNode.Left] : null;

                if (nodeForRemove > treeNode)
                    DeleteNode(rightNode, nodeForRemove);
                else if (nodeForRemove < treeNode)
                    DeleteNode(leftNode, nodeForRemove);
                else if (nodeForRemove.Equals(treeNode))            
                    RemoveFromNodeOperation(treeNode);
                
            }
        }

        private void RemoveFromNodeOperation(AssociativeTreeNode<T> nodeForRemove)
        {
            var node = FindNode(nodeForRemove);

            if (node.Left == -1 && node.Right == -1)
                RemoveOperationFirstCase(node);
            else if ((node.Left == -1 && node.Right != -1) || (node.Left != -1 && node.Right == -1))
                RemoveOperationSecondCase(node);
            else if (node.Left != -1 && node.Right != -1)
                RemoveOperationThirdCase(node);

        }

        private void RemoveInArray(int index)
        {
            for (int i = index; i < Count; i++)
                AssociativeTreeNodes[i] = AssociativeTreeNodes[(i + 1)];
        }

        private void DecrementIndexes(int index)
        {
            for (int i = 0; i < Count; i++)
            {
                var node = AssociativeTreeNodes[i];
                node.Left = (node.Left >= index) ? (node.Left - 1) : node.Left;
                node.Right = (node.Right >= index) ? (node.Right - 1) : node.Right;
            }
               
        }

        private void RemoveOperationFirstCase(AssociativeTreeNode<T> nodeForRemove,int valueForReplace = -1)
        {
            var prevNode = FindPrev(nodeForRemove);

            if (prevNode.Left != -1)
                prevNode.Left = valueForReplace;
            else if (prevNode.Right != -1)
                prevNode.Right = valueForReplace;
        }

        private void RemoveOperationSecondCase(AssociativeTreeNode<T> nodeForRemove)
            => RemoveOperationFirstCase(nodeForRemove, Math.Max(nodeForRemove.Left,nodeForRemove.Left));

        private void RemoveOperationThirdCase(AssociativeTreeNode<T> nodeForRemove)
        {
            var nodeForSwap = AssociativeTreeNodes[nodeForRemove.Right];

            while (nodeForSwap.Left != -1)
                nodeForSwap = AssociativeTreeNodes[nodeForSwap.Left];

            DeleteNode(nodeForSwap);

            nodeForRemove.Value = nodeForSwap.Value;
        }

    }
}