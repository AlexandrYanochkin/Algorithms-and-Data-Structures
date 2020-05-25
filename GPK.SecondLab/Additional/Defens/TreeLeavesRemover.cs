using GPK.FirstLab.Additional;
using GPK.SecondLab.Models.Nodes;
using GPK.SecondLab.Models.SimpleTree;
using System;
using GPK.FirstLab.LinkList;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Additional.Defens
{
    public class TreeLeavesRemover<T> : ILeafRemover<T>
        where T : IComparable<T>,new()
    {
        public Tree<T> Tree { get; set; }

        private ILinkedList<T> linkedList = new LinkedList<T>();

        public TreeLeavesRemover(Tree<T> tree)
        {
            Tree = tree ?? throw new ArgumentNullException("Tree can't be null");
        }

        public void RemoveLeaves()
        {
            StepToAllNodes(Tree.Root);

            for (int i = 0; i < linkedList.Count; i++)
                Tree.DeleteNode(linkedList[i]);
        }

        private void StepToAllNodes(TreeNode<T> treeNode)
        {
            if(treeNode != null)
            {
                StepToAllNodes(treeNode.Left);

                if (treeNode.Left == null && treeNode.Right == null)
                    linkedList.Add(treeNode.Value);

                StepToAllNodes(treeNode.Right);
            }
        }
       
    }
}
