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
        public void DeleteNode(T data)
          => DeleteNode(new TreeNode<T>(data));

        public void DeleteNode(TreeNode<T> treeNode)
        {
            if (treeNode.Equals(Root))
                RemoveRoot();
            else
                DeleteNode(Root, treeNode);
        }

        private void DeleteNode(TreeNode<T> startNode, TreeNode<T> nodeForRemove)
        {
            if (startNode != null)
            {
                if (nodeForRemove > startNode)
                    DeleteNode(startNode.Right, nodeForRemove);
                else if (nodeForRemove < startNode)
                    DeleteNode(startNode.Left, nodeForRemove);
                else if (nodeForRemove.Equals(startNode))
                {
                    RemoveFromNodeOperation(startNode);

                   // if (Root != null)
                      //  Root = Balance(Root);
                }

            }
        }

        private void RemoveRoot()
        {
            if (Root.Left == null && Root.Right == null)
                Root = null;
            else if (Root.Left == null && Root.Right != null)
                Root = Root.Right;
            else if (Root.Left != null && Root.Right == null)
                Root = Root.Left;
            else if(Root.Left != null && Root.Right != null)
            {
                var nodeForSwap = Root.Right;

                while (nodeForSwap.Left != null)
                    nodeForSwap = nodeForSwap.Left;

                DeleteNode(nodeForSwap);

                Root.Value = nodeForSwap.Value;
            }
        }

        private void RemoveFromNodeOperation(TreeNode<T> nodeForRemove)
        {
            if (nodeForRemove.Left == null && nodeForRemove.Right == null)
                RemoveOperationFirstCase(FindPrev(Root, nodeForRemove), nodeForRemove);         
            else if ((nodeForRemove.Left != null && nodeForRemove.Right == null) || (nodeForRemove.Left == null && nodeForRemove.Right != null))
                RemoveOperationSecondCase(FindPrev(Root, nodeForRemove), nodeForRemove);
            else if (nodeForRemove.Left != null && nodeForRemove.Right != null)
                RemoveOperationThirdCase(nodeForRemove);
        }

        private void RemoveOperationFirstCase(TreeNode<T> prevNode, TreeNode<T> nodeForRemove, TreeNode<T> nextAfterNodeForRemove = null)
        {
            if (nodeForRemove.Equals(prevNode.Right))
                prevNode.Right = nextAfterNodeForRemove;
            else
                prevNode.Left = nextAfterNodeForRemove;
        }

        private void RemoveOperationSecondCase(TreeNode<T> prevNode, TreeNode<T> nodeForRemove)
        {
            TreeNode<T> nextAfterNodeForRemove = (nodeForRemove.Right == null) ? nodeForRemove.Left : nodeForRemove.Right;

            RemoveOperationFirstCase(prevNode, nodeForRemove, nextAfterNodeForRemove);
        }

        private void RemoveOperationThirdCase(TreeNode<T> nodeForRemove)
        {
            TreeNode<T> forSwap = nodeForRemove.Left;

            while (forSwap.Right != null)
                forSwap = forSwap.Right;

            DeleteNode(Root, forSwap);

            forSwap.Left = nodeForRemove.Left;
            forSwap.Right = nodeForRemove.Right;

            if (!nodeForRemove.Equals(Root))
            {
                TreeNode<T> prevNode = FindPrev(Root, nodeForRemove);

                if (nodeForRemove.Equals(prevNode.Right))
                    prevNode.Right = forSwap;
                else if (nodeForRemove.Equals(prevNode.Left))
                    prevNode.Left = forSwap;
            }
            else
                Root = forSwap;

        }

    }
}
