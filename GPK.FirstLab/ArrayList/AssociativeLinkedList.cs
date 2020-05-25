using GPK.FirstLab.Additional;
using System;

namespace GPK.FirstLab.ArrayList
{
    public class AssociativeLinkedList<T> : ILinkedList<T>
                                  where T : IComparable<T>, new()
    {
        private AssociativeNode<T> Root { get;  set; }

        private AssociativeNode<T>[] AssociativeArray = new AssociativeNode<T>[10];



        public AssociativeLinkedList(params T[] values)
        {
            if (values == null)
                throw new ArgumentNullException("Array with values can't be null");

            foreach (var value in values)
                    Add(value);
        }

        public AssociativeLinkedList()
        {
        }



        public T this[int index]
            => Find(index);

        public int Count { get; private set; }

     

        public void Add(T value)
        {
            if (Count == AssociativeArray.Length)
                Array.Resize(ref AssociativeArray, AssociativeArray.Length * 2);

            if (Count == 0)
            {
                Root = new AssociativeNode<T>(value);
                AssociativeArray[Count] = Root;
            }
            else
            {
                AssociativeArray[Count] = new AssociativeNode<T>(value);
                AssociativeArray[(Count - 1)].Next = Count;
            }


            Count++;
        }

        public bool Contains(T value)
        {
            AssociativeNode<T> node = Root;
            bool forRet = false;

            while(node != null && !forRet)
            {
                forRet = node.Value.Equals(value);
                node = (node.Next != -1) ? AssociativeArray[node.Next] : null;
            }


            return forRet;
        }

        public T Find(int index)
            => FindNode(index).Value;

        private AssociativeNode<T> FindNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of range");

            AssociativeNode<T> node = Root;
            int startInd = 0;

            while (startInd++ != index && node.Next != -1)
                node = AssociativeArray[node.Next];

            return node;
        }

        public void Remove(int index)
        {
            AssociativeNode<T> node = FindNode(index);

            if (index == 0)
                Root = (Root.Next != -1) ? AssociativeArray[Root.Next] : null;
            else
                FindNode(index - 1).Next = node.Next;

            DeleteNodeInArray(node);

            
            Count--;
        }

        private void DeleteNodeInArray(AssociativeNode<T> node)
        {
            int indexForDelete = FindIndexOfNode(node);

            DecrementIndexes(indexForDelete);

            RemoveElementInArray(indexForDelete);
        }

        private int FindIndexOfNode(AssociativeNode<T> node)
        {
            int indexForOperation = -1;
            int saveInd = node.Next;
            node.Next = -2;


            for (int i = 0; i < Count && (indexForOperation == -1); i++)
                if (AssociativeArray[i].Next == -2)
                    indexForOperation = i;

            node.Next = saveInd;

            return indexForOperation;
        }

        private void DecrementIndexes(int index)
        {
            for (int i = 0; i < Count; i++)
                if (AssociativeArray[i].Next > index)
                    AssociativeArray[i].Next--;
        }

        private void RemoveElementInArray(int index)
        {          
            for (int i = index; i < Count; i++)
                AssociativeArray[i] = AssociativeArray[(i + 1)];     
        }

        private AssociativeNode<T> GetPrevNode(AssociativeNode<T> node)
        {
            AssociativeNode<T> outNode = null;
            int indexOfNode = FindIndexOfNode(node);

            for (int i = 0; i < Count && (outNode == null); i++)
                if (indexOfNode == AssociativeArray[i].Next)
                    outNode = AssociativeArray[i];

            return outNode;
        }

        private void Swap(AssociativeNode<T> fNode, AssociativeNode<T> sNode)
        {
            var prevNode = GetPrevNode(fNode);
            int indFirst = FindIndexOfNode(fNode);
            int indSec = FindIndexOfNode(sNode);


            fNode.Next = sNode.Next;
            prevNode.Next = indSec;
            sNode.Next = indFirst;
        }

        private void BubbleSort(Func<AssociativeNode<T>,AssociativeNode<T>,bool> compareFunc)
        {

            for (int i = 0; i < Count; i++)
            {
                AssociativeNode<T> firstNode = Root;
                AssociativeNode<T> secNode = AssociativeArray[(Root.Next == -1) ? 0 : Root.Next];


                for (int g = 0; g < (Count - 1) && firstNode != null && secNode != null; g++)
                {
                    if (compareFunc(firstNode, secNode))
                    {
                        if(g > 0)
                            Swap(firstNode, secNode);
                        else
                        {
                           
                            firstNode.Next = secNode.Next;
                            secNode.Next = FindIndexOfNode(firstNode);

                            Root = secNode;
                        }

                        var node = firstNode;
                        firstNode = secNode;
                        secNode = node;

                    }

                    firstNode = (firstNode.Next != -1) ? AssociativeArray[firstNode.Next] : null;
                    secNode = (secNode.Next != -1) ? AssociativeArray[secNode.Next] : null;
                }

            }

        }

        public void SortByAscending()
                => BubbleSort((fNode, sNode) => fNode > sNode);

        public void SortByDescending()
                => BubbleSort((fNode, sNode) => fNode < sNode);



        public void View(ILinkedListViewer<T> linkedListViewer)
                => linkedListViewer.View(this);
    }
}



