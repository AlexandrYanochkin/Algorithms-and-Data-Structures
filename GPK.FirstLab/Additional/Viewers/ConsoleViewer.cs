using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.FirstLab.Additional.Viewers
{
    public class ConsoleViewer<T> : ILinkedListViewer<T>
    {
        public void View(ILinkedList<T> linkedList)
        {
            Console.WriteLine();

            for (int i = 0; i < linkedList.Count; i++)
                if(i != (linkedList.Count - 1))
                    Console.Write($"{linkedList[i]} -> ");
                else
                    Console.Write(linkedList[i]);

            Console.WriteLine();
        }
    }
}
