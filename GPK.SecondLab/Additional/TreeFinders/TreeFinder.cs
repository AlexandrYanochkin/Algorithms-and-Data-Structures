using GPK.SecondLab.Models.Nodes;
using GPK.SecondLab.Models.SimpleTree;
using System;
using System.Linq;
using GPK.FirstLab.LinkList;
using GPK.FirstLab.Additional;

namespace GPK.SecondLab.Additional.TreeFinders
{
    public class TreeFinder<T> : ITreeFinder<T>
        where T : IComparable<T>,new()
    {
        public Tree<T> Tree { get; set; }

        private LinkedList<T> maxRightBranch = null;

        public TreeFinder(Tree<T> tree)
        {
            Tree = tree ?? throw new ArgumentNullException("Tree can't be null!!!");
        }

        public ILinkedList<T> FindLongestRightBranch()
        {
            StepToAllNodes(Tree.Root);

            return maxRightBranch;
        }

        private void StepToAllNodes(TreeNode<T> treeNode)
        {
            if(treeNode != null)
            {
                StepToAllNodes(treeNode.Left);

                var linkedList = GetRightBranch(treeNode);

                if (maxRightBranch == null)
                    maxRightBranch = linkedList;
                else if (maxRightBranch.Count < linkedList.Count)
                    maxRightBranch = linkedList;

                StepToAllNodes(treeNode.Right);
            }
        }

        private LinkedList<T> GetRightBranch(TreeNode<T> treeNode)
        {
            LinkedList<T> linkedList = new LinkedList<T>();

            while (treeNode != null)
            {
                linkedList.Add(treeNode.Value);
                treeNode = treeNode.Right;
            }              

            return linkedList;
        }

    }
}
