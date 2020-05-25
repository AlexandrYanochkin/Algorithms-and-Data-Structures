using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.FirstLab.Additional
{
    public abstract class AbstractNode<T> where T : IComparable<T>, new()
    {
        public T Value
        {

            get => nodeValue;

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value can't be null!!!");

                nodeValue = value;
            }

        }
       

        T nodeValue;

        public AbstractNode(T value)
        {
            Value = value;
        }

        public AbstractNode() : this(new T())
        {
        }



        public static bool operator >(AbstractNode<T> firstNode, AbstractNode<T> secNode)
            => (firstNode.Value.CompareTo(secNode.Value) == 1);

        public static bool operator <(AbstractNode<T> firstNode, AbstractNode<T> secNode)
            => (firstNode.Value.CompareTo(secNode.Value) == -1);




        public override int GetHashCode()
            => (Value.GetHashCode());

        public override bool Equals(object obj)
            => (obj is AbstractNode<T> node && node.GetHashCode() == GetHashCode());

        public override string ToString()
            => (Value.ToString());
    }
}
