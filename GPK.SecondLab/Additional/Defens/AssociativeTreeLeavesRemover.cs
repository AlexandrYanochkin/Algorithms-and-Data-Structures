using GPK.SecondLab.Models.AssociativeTree;
using GPK.SecondLab.Models.Nodes;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GPK.FirstLab.Additional;
using GPK.FirstLab.LinkList;
using GPK.SecondLab.Additional.TreeViewers;

namespace GPK.SecondLab.Additional.Defens
{
    public class AssociativeTreeLeavesRemover<T> : ILeafRemover<T>
        where T : IComparable<T>,new()
    {
        public AssociativeTree<T> Tree { get; set; }

        private ILinkedList<T> linkedList = new LinkedList<T>();

        public AssociativeTreeLeavesRemover(AssociativeTree<T> associativeTree)
        {
            Tree = associativeTree ?? throw new ArgumentNullException("Tree can't be null!!!");
        }

        private AssociativeTreeNode<T>[] GetArray()
        {
            var array = typeof(AssociativeTree<T>)
                .GetField("AssociativeTreeNodes", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(Tree) as AssociativeTreeNode<T>[];

            return array;
        }

        public void RemoveLeaves()
        {
            var array = GetArray();

            StepToAllNodes(array, Tree.Root);

            for (int i = 0; i < linkedList.Count; i++)
            {
                Tree.DeleteNode(linkedList[i]);
                Tree.View(new TreeConsoleViewer<T>());
            }
        }

        private void StepToAllNodes(AssociativeTreeNode<T>[] array, AssociativeTreeNode<T> treeNode)
        {
            if(treeNode != null)
            {
                var leftNode = (treeNode.Left != -1) ? array[treeNode.Left] : null;
                StepToAllNodes(array, leftNode);

                if (treeNode.Left == -1 && treeNode.Right == -1)
                    linkedList.Add(treeNode.Value);

                var rightNode = (treeNode.Right != -1) ? array[treeNode.Right] : null;
                StepToAllNodes(array,rightNode);
            }
        }
   
    }
}
