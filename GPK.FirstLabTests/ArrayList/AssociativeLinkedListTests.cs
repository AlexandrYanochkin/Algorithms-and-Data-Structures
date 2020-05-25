using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPK.FirstLab.ArrayList;
using GPK.FirstLab.Additional;

namespace GPK.FirstLab.ArrayList.Tests
{
    [TestClass()]
    public class AssociativeLinkedListTests
    {
        [DataTestMethod()]
        [DataRow(50, new int[] { 1, 2, 3, 4, 5 })]
        public void LinkedListContainsAndAddTest(int value, params int[] values)
        {
            //arrange
            ILinkedList<int> linkedList = new AssociativeLinkedList<int>(values);

            //act 
            linkedList.Add(value);

            //assert
            Assert.IsTrue(linkedList.Contains(value));
        }

        [DataTestMethod()]
        [DataRow(new int[] { 44, 45, 47, 48, 49 })]
        public void LinkedListDeleteTest(params int[] values)
        {
            //arrange
            ILinkedList<int> linkedList = new AssociativeLinkedList<int>(values);

            //act
            int last = linkedList[linkedList.Count - 1];
            linkedList.Remove(linkedList.Count - 1);

            //assert
            Assert.IsTrue(!linkedList.Contains(last));
        }

        [DataTestMethod()]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        public void FindTest(params int[] values)
        {
            //arrange
            ILinkedList<int> linkedList = new AssociativeLinkedList<int>(values);

            //act
            int value = linkedList[0];

            //assert
            Assert.IsTrue(value == values[0]);
        }


    }
}