using System;
using GPK.FirstLab.ArrayList;
using GPK.FirstLab.LinkList;
using System.Reflection;
using System.Linq;

namespace GPK.FirstLab.Additional.Viewers
{
    public class ViewForDefense : ILinkedListViewer<int>
    {
        public void View(ILinkedList<int> linkedList)
        {
            if (linkedList.GetType() == typeof(AssociativeLinkedList<int>))
            {
                //--------------------------------------------Initialization--------------------------------------------
                FieldInfo fieldInfo = typeof(AssociativeLinkedList<int>)
                     .GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(t => t.Name == "AssociativeArray");

                var arr = fieldInfo.GetValue(linkedList) as AssociativeNode<int>[];
                //------------------------------------------------------------------------------------------------------


                Console.WriteLine();

                PrintStandartList(linkedList);

                Console.WriteLine();


                for (int i = 0; i < linkedList.Count; i++)
                    Console.WriteLine($"linkedList[{i}]:\t{arr[i].Value}\t|\tnextNode:\t{arr[i].Next}");
  
            }
            else if (linkedList.GetType() == typeof(LinkedList<int>))
                PrintStandartList(linkedList);



            Console.WriteLine();
        }

        private void PrintStandartList(ILinkedList<int> linkedList)
        {
            for (int i = 0; i < linkedList.Count; i++)
                if (i != (linkedList.Count - 1))
                    Console.Write($"{linkedList[i]} -> ");
                else
                    Console.WriteLine(linkedList[i]);
        }

    }
}
