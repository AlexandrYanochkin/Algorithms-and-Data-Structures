using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.ExceptionsClasses
{   
    public class TreeNodeException : Exception
    {
        public TreeNodeException()
        {
        }

        public TreeNodeException(string message) : base(message)
        {
        }

    }
}
