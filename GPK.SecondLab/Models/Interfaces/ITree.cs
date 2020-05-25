using GPK.SecondLab.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab.Models.Interfaces
{
    public interface ITree<T> where T : new()
    {
        void AddNode(T value);
        void DeleteNode(T data);
        void View(ITreePrinter<T> treePrinter);
        bool Contains(T value);

        T GetMaxNode();
        T GetMinNode();
    }
}
