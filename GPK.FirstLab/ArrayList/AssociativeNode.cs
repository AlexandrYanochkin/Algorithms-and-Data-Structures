using GPK.FirstLab.Additional;
using System;

namespace GPK.FirstLab.ArrayList
{
    public class AssociativeNode<T> : AbstractNode<T>,ICloneable
                            where T : IComparable<T>, new()
    {
        public int Next { get; set; } = -1;

        public AssociativeNode(T value) : base(value)
        {
        }

        public AssociativeNode()
        {
        }


        public object Clone()
               => this.MemberwiseClone();

        public override string ToString() 
            => ($"({Value};{Next})");
    }
}
