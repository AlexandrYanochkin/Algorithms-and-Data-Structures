using GPK.SecondLab.Models.AssociativeTree;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.Nodes;
using GPK.SecondLab.Models.SimpleTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GPK.SecondLab.Additional.TreeViewers
{
    public class TreeConsoleViewer<T> : ITreePrinter<T>
        where T : new()
    {
        public void PrintTree(ITree<T> root)
        {
            Console.WriteLine();

            if (root is AssociativeTree<T>)
            {
                var associativeTree = (root as AssociativeTree<T>);

                var rootOfTree = GetRootFromAssociativeTree(associativeTree);
                var arrayOfTree = GetArrayFromAssociativeTree(associativeTree);
                

                AssociativeArrayOutput(arrayOfTree, associativeTree.Count);
                Console.WriteLine();
                AssociativeTreeOutput(rootOfTree, arrayOfTree, 0);
            }
            else if (root is Tree<T>)
                SimpleTreeOutput((root as Tree<T>).Root, 0);

            Console.WriteLine();
        }

        private void SimpleTreeOutput(TreeNode<T> treeNode,int level)
        {
            if (treeNode != null)
            {
                SimpleTreeOutput(treeNode.Right, (level + 1));

                Console.WriteLine($"{new string('\t',level)}lvl({level}):{treeNode.Value}");

                SimpleTreeOutput(treeNode.Left, (level + 1));
            }
        }


        private void AssociativeTreeOutput(AssociativeTreeNode<T> treeNode, AssociativeTreeNode<T>[] array, int level)
        {
            if(treeNode != null)
            {
                var rightLeaf = (treeNode.Right != -1) ? array[treeNode.Right] : null;
                var leftLeaf = (treeNode.Left != -1) ? array[treeNode.Left] : null;

                AssociativeTreeOutput(rightLeaf, array, (level + 1));

                Console.WriteLine($"{new string('\t',level)}{treeNode.Value}");

                AssociativeTreeOutput(leftLeaf, array, (level + 1));
            }
        }


        private void AssociativeArrayOutput(AssociativeTreeNode<T>[] array,int countOfArray) 
        {
            Console.WriteLine();

            for(int i = 0;i < countOfArray; i++)            
                Console.WriteLine($"array[{i}]:\t{array[i].Value};Left:{array[i].Left};Right:{array[i].Right}");
            

            Console.WriteLine();
        }

        private AssociativeTreeNode<T>[] GetArrayFromAssociativeTree(AssociativeTree<T> tree)
        {
            var array = typeof(AssociativeTree<T>)
                .GetField("AssociativeTreeNodes", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(tree) as AssociativeTreeNode<T>[];

            return array;
        }

        private AssociativeTreeNode<T> GetRootFromAssociativeTree(AssociativeTree<T> tree)
        {
            var root = typeof(AssociativeTree<T>)
                .GetProperty("Root", BindingFlags.Instance | BindingFlags.Public)
                .GetValue(tree) as AssociativeTreeNode<T>;

            return root;
        }

    }
}
