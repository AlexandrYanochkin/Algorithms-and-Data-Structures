using GPK.FirstLab.Additional;
using System;

namespace GPK.FirstLab.LinkList
{
    public class LinkedList<T> : ILinkedList<T>
                       where T : IComparable<T>,new()
    {
        private Node<T> Root { get; set; }

        public int Count { get; private set; }



        public LinkedList()
        {
        }

        public LinkedList(params T[] values)
        {
            if (values == null)
                throw new ArgumentNullException("Array with values can't be null");

            foreach (var value in values)
                Add(value);
        }



        public void Add(T value)
        {
            if (Root == null)
                Root = new Node<T>(value);
            else
                Add(Root, value);

            Count++;
        }

        private void Add(Node<T> node,T value)
        {
            if (node.Next == null)
                node.Next = new Node<T>(value);
            else
                Add(node.Next, value);
        }




        public T this[int index]
            => Find(index);

        public T Find(int index)
        {
            Node<T> node = FindNode(index);
            
            return (node != null) ? node.Value : default(T);
        }

        private Node<T> FindNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Argument out of range");

            int start = 0;
            Node<T> node = Root;

            while (start++ != index && node.Next != null)
                node = node.Next;

            return node;
        }

        public void Remove(int index)
        {       
            if (index == 0)
                Root = Root.Next;
            else
                FindNode(index - 1).Next = FindNode(index).Next;
            

            Count--;
        }



        public bool Contains(T value)
             => Contains(Root, value);

        private bool Contains(Node<T> node, T value)
            => (node == null) ? false : (node.Value.Equals(value) ? true : Contains(node.Next, value));
      

        private void SwapNodes(Node<T> prevNode,Node<T> fNode,Node<T> sNode)
        {
            //From first throwing reference next on sNode.Next
            // By this action I just skip sNode element

            fNode.Next = sNode.Next;
            sNode.Next = fNode;//I return the reference sNode.Next back on the fNode
            prevNode.Next = sNode;// I set prevNode on sNode, because it was setted on fNode element
        }

        private void BubbleSort(Func<Node<T>, Node<T>, bool> compareFunc)
        {
            for (int i = 0; i < Count; i++)
            {
                Node<T> firstNode = Root;// I save Root element
                Node<T> secNode = Root.Next;// And next

                for (int g = 0; g < (Count - 1) && firstNode != null && secNode != null; g++)
                {
                    //If my comparing function returns True - then I should Swap Elements!!!
                    if (compareFunc(firstNode,secNode))
                    {
                        //Two cases

                        if (g > 0) //First case, Very important to use FindNode function, because our linkedList changes everytime!
                            SwapNodes(FindNode(g - 1), firstNode, secNode);                                             
                        else
                        {
                            //I throw reference from first to sec.Next
                            firstNode.Next = secNode.Next;
                            secNode.Next = firstNode;//I back reference of second and setted it on the first
                            Root = secNode; // Roott changes because we're in the beggining
                        }

                        //And one little moment, I should change references, because my first is going after second, 
                        //but should be before second

                        Node<T> node = secNode;
                        secNode = firstNode;
                        firstNode = node;
                    }

                    //Going to next iteration

                    firstNode = firstNode.Next; 
                    secNode = secNode.Next;
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
