using GPK.SecondLab.Models.ExceptionsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.Nodes
{
    public class AbstractTreeNode<T>  
          where T : new()
    {       
        public T Value { get; set; }


        public AbstractTreeNode(T value)
        {
            if (value == null)
                throw new TreeNodeException("The value can't be null");

            this.Value = value;
        }

        public AbstractTreeNode() : this(new T())
        {
        }



        public static bool operator >(AbstractTreeNode<T> treeNodeFirst, AbstractTreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() > treeNodeSecond.GetHashCode());
      
        public static bool operator <(AbstractTreeNode<T> treeNodeFirst, AbstractTreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() < treeNodeSecond.GetHashCode());

        public static bool operator >=(AbstractTreeNode<T> treeNodeFirst, AbstractTreeNode<T> treeNodeSecond)
            => (treeNodeFirst.GetHashCode() >= treeNodeSecond.GetHashCode());
   
        public static bool operator <=(AbstractTreeNode<T> treeNodeFirst, AbstractTreeNode<T> treeNodeSecond)
           => (treeNodeFirst.GetHashCode() <= treeNodeSecond.GetHashCode());


        public override int GetHashCode()
                => (Value.GetHashCode());

        public override bool Equals(object obj)
            => ((obj is AbstractTreeNode<T> treeNode) && (this.GetHashCode() == treeNode.GetHashCode()));
  
        public override string ToString()
            => Value.ToString();
    }
}
