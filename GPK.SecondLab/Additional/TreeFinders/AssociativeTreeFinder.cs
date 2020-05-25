using GPK.FirstLab.Additional;
using GPK.FirstLab.ArrayList;
using GPK.SecondLab.Models.AssociativeTree;
using GPK.SecondLab.Models.Nodes;
using System;
using System.Linq;
using System.Reflection;

namespace GPK.SecondLab.Additional.TreeFinders
{
    public class AssociativeTreeFinder<T> : ITreeFinder<T>
        where T : IComparable<T>,new()
    {
        public AssociativeTree<T> Tree { get; set; }

        private AssociativeLinkedList<T> maxRightBranch = null;

        public AssociativeTreeFinder(AssociativeTree<T> tree)
        {
            Tree = tree ?? throw new ArgumentNullException("Tree can't be null!!!");
        }  

        public ILinkedList<T> FindLongestRightBranch()
        {
            var array = GetArrayFromAssociativeTree(Tree);

            StepToAllNodes(array, Tree.Root);


            return maxRightBranch;
        }

        private AssociativeTreeNode<T>[] GetArrayFromAssociativeTree(AssociativeTree<T> tree)
        {
            var array = typeof(AssociativeTree<T>)
                .GetField("AssociativeTreeNodes", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(tree) as AssociativeTreeNode<T>[];

            return array;
        }

        private void StepToAllNodes(AssociativeTreeNode<T>[] array,AssociativeTreeNode<T> associativeTreeNode)
        {
            if(associativeTreeNode != null)
            {       
                var leftNode = (associativeTreeNode.Left != -1) ? array[associativeTreeNode.Left] : null;
                StepToAllNodes(array, leftNode);

                var linkedList = GetRightBranch(array, associativeTreeNode);

                if (maxRightBranch == null)
                    maxRightBranch = linkedList;
                else if (maxRightBranch.Count < linkedList.Count)
                    maxRightBranch = linkedList;


                var rightNode = (associativeTreeNode.Right != -1) ? array[associativeTreeNode.Right] : null;
                StepToAllNodes(array, rightNode);
            }
        }

        private AssociativeLinkedList<T> GetRightBranch(AssociativeTreeNode<T>[] array,AssociativeTreeNode<T> associativeTreeNode)
        {
            AssociativeLinkedList<T> associativeLinkedList = new AssociativeLinkedList<T>();

            while(associativeTreeNode != null)
            {
                associativeLinkedList.Add(associativeTreeNode.Value);
                associativeTreeNode = (associativeTreeNode.Right != -1) ? array[associativeTreeNode.Right] : null;
            }

            return associativeLinkedList;
        }

    }
}
