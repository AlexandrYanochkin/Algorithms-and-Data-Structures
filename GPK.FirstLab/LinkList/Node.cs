using GPK.FirstLab.Additional;
using System;

namespace GPK.FirstLab.LinkList
{
    public class Node<T> : AbstractNode<T>
                 where T : IComparable<T>, new()
    {   

        public Node<T> Next { get; set; }

        public Node(T value) : base(value)
        {
        }

        public Node()
        {
        }

    }
}
