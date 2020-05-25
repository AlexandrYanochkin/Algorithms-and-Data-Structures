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
        int GetHeight(TreeNode<T> treeNode)
        {
            int maxHeight = default;

            GetHeight(treeNode, 0, ref maxHeight);

            return maxHeight;
        }

        void GetHeight(TreeNode<T> node, int heightOfNode, ref int maxHeight)
        {
            if (node != null)
            {
                GetHeight(node.Right, (heightOfNode + 1), ref maxHeight);

                if (heightOfNode > maxHeight)
                    maxHeight = heightOfNode;

                GetHeight(node.Left, (heightOfNode + 1), ref maxHeight);
            }
        }

        TreeNode<T> RotateLeft(TreeNode<T> treeNode)
        {
            if (treeNode != null && treeNode.Left != null && treeNode.Right != null)
            {
                TreeNode<T> rightNode = treeNode.Right;
                treeNode.Right = rightNode.Left;
                rightNode.Left = treeNode;

                return rightNode;
            }

            return treeNode;
        }

        TreeNode<T> RotateRight(TreeNode<T> treeNode)
        {
            if (treeNode != null && treeNode.Left != null && treeNode.Right != null)
            {
                TreeNode<T> leftNode = treeNode.Left;
                treeNode.Left = leftNode.Right;
                leftNode.Right = treeNode;

                return leftNode;
            }

            return treeNode;
        }

        int BFactor(TreeNode<T> treeNode)
            => (GetHeight(treeNode.Right) - GetHeight(treeNode.Left));

        TreeNode<T> Balance(TreeNode<T> treeNode)
        {
            if (BFactor(treeNode) == 2)
            {
                if (BFactor(treeNode.Right) < 0)
                    treeNode.Right = RotateRight(treeNode.Right);

                return RotateLeft(treeNode);
            }
            else if (BFactor(treeNode) == -2)
            {
                if (BFactor(treeNode.Left) > 0)
                    treeNode.Left = RotateLeft(treeNode.Left);

                return RotateRight(treeNode);
            }

            return treeNode;
        }

    }
}
