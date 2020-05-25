using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.ExceptionsClasses
{
    public class TreeException : Exception
    {
        public TreeException()
        {
        }

        public TreeException(string message) : base(message)
        {
        }

    }
}
