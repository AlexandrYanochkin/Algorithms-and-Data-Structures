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
        public bool Contains(T data)
                => Contains(new TreeNode<T>(data));

        public bool Contains(TreeNode<T> treeNode)
                => Contains(Root, treeNode);

        bool Contains(TreeNode<T> startNode, TreeNode<T> nodeForSearch)
        {
            if (startNode != null)
            {
                if (nodeForSearch > startNode)
                    return Contains(startNode.Right, nodeForSearch);
                else if (nodeForSearch < startNode)
                    return Contains(startNode.Left, nodeForSearch);
                else
                    return nodeForSearch.Equals(startNode);
            }

            return false;
        }

        TreeNode<T> FindPrev(TreeNode<T> nodeForStart, TreeNode<T> nodeForSearch)
        {
            if (nodeForStart != null)
            {
                if (nodeForSearch.Equals(nodeForStart.Right) || nodeForSearch.Equals(nodeForStart.Left))
                    return nodeForStart;
                else if (nodeForSearch.Equals(Root))
                    throw new TreeException("You can't find Prev Node For Root!!!");
                else
                {
                    if (nodeForSearch > nodeForStart)
                        return FindPrev(nodeForStart.Right, nodeForSearch);
                    else
                        return FindPrev(nodeForStart.Left, nodeForSearch);
                }
            }

            throw new TreeException("The node doesn't exist");
        }

        TreeNode<T> FindNode(TreeNode<T> startNode, TreeNode<T> treeNode)
        {
            if (startNode != null)
            {
                if (treeNode > startNode)
                    return FindNode(startNode.Right, treeNode);
                else if (treeNode < startNode)
                    return FindNode(startNode.Left, treeNode);
            }

            return startNode;
        }

    }
}
