using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.Interfaces
{  
    public interface ITreePrinter<T> where T : new()
    {      
        void PrintTree(ITree<T> root);
    }
}
