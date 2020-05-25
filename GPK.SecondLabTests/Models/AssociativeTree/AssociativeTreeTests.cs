using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPK.SecondLab.Models.AssociativeTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPK.SecondLab.Models.SimpleTree;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.ExceptionsClasses;

namespace GPK.SecondLab.Models.AssociativeTree.Tests
{
    [TestClass()]
    public class AssociativeTreeTests
    {
        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 99 })]
        public void CreateTreeValidTest(params int[] arr)
        {
            //arrange
            ITree<Int32> tree = new AssociativeTree<int>(arr.First());


            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));

            //result
            Assert.IsTrue(tree != null);
        }

        [DataTestMethod()]
        [DataRow(new int[] { 50, 30, 75, 50, 94, 87, 55 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 24 })]
        [DataRow(new int[] { 50, 60, 25, 2, 2, 60, 99 })]
        public void CreateTreeInvalidTest(params int[] arr)
        {
            //arrange
            ITree<Int32> tree = new AssociativeTree<int>(arr.First());


            //result
            Assert.ThrowsException<TreeException>(() =>
            {
                arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            });
        }

        [DataTestMethod()]
        [DataRow(105, new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(58, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(100, new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeContainsTest(int element, params int[] arr)
        {
            //arrange 
            ITree<Int32> tree = new AssociativeTree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            bool result = tree.Contains(element);


            //assert
            Assert.IsTrue(result == arr.Contains(element));
        }

        [DataTestMethod()]
        [DataRow(79, new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(24, new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(2, new int[] { 50, 60, 25, 2, 5, 7, 99 })]
        [DataRow(50, new int[] { 50 })]
        [DataRow(50, new int[] { 50, 24, 46 })]
        [DataRow(50, new int[] { 50, 60 })]
        public void TreeDeleteNodesTest(int elementForDelete, params int[] arr)
        {
            //arrange 
            AssociativeTree<Int32> tree = new AssociativeTree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            tree.DeleteNode(elementForDelete);


            //assert
            Assert.IsTrue(!tree.Contains(elementForDelete) && tree.Count == (arr.Length - 1));
        }

        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeGetMaxNodeTest(params int[] arr)
        {
            //arrange 
            ITree<Int32> tree = new AssociativeTree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            int result = tree.GetMaxNode();


            //assert
            Assert.IsTrue(result == arr.Max());
        }

        [DataTestMethod()]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 99 })]
        [DataRow(new int[] { 50, 24, 46, 79, 58, 32, 23 })]
        [DataRow(new int[] { 50, 60, 25, 2, 5, 7, 100 })]
        public void TreeGetMinNodeTest(params int[] arr)
        {
            //arrange 
            ITree<Int32> tree = new AssociativeTree<int>(arr.First());

            //act
            arr.Skip(1).ToList().ForEach(value => tree.AddNode(value));
            int result = tree.GetMinNode();


            //assert
            Assert.IsTrue(result == arr.Min());
        }

    }
}