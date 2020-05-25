using GPK.FirstLab.Additional;
using GPK.FirstLab.Additional.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.FirstLab
{

    public static class UserInterface
    {
        public static ILinkedList<int> linkedList { get; set; }

        public static ILinkedListViewer<int> linkedListViewer { get; set; } = new ViewForDefense();

        public static void Menu()
        {
            bool exitFlag = false;

            while (!exitFlag)
            {
                Console.WriteLine($"\t0.AddRange\n" +
                                  $"\t1.AddElement\n" +
                                  $"\t2.DeleteElementByIndex\n" +
                                  $"\t3.ViewElements\n" +
                                  $"\t4.Contains\n" +
                                  $"\t5.SortByAscending\n" +
                                  $"\t6.SortBydescending\n" +
                                  $"\t7.TaskForLab()\n" +
                                  $"\t8.Defense\n" +
                                  $"\t9.Exit\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        AddRange();
                        break;


                    case ConsoleKey.D1:
                        AddElement();
                        break;


                    case ConsoleKey.D2:
                        DeleteElement();
                        break;


                    case ConsoleKey.D3:
                        Console.WriteLine("linkedList:\t");
                        if (linkedList != null && linkedListViewer != null)
                            linkedList.View(linkedListViewer);
                        break;

                    case ConsoleKey.D4:
                        ContainsValue();
                        break;


                    case ConsoleKey.D5:
                        linkedList.SortByAscending();
                        break;

                    case ConsoleKey.D6:
                        linkedList.SortByDescending();
                        break;

                    case ConsoleKey.D7:
                        TaskForLab();
                        break;

                    case ConsoleKey.D8:
                        Defense();
                        break;

                    case ConsoleKey.D9:
                        exitFlag = true;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

        }

        static void AddRange()
        {
            try
            {
                Console.WriteLine("Input range of elements in csv format:");

                string csvRange = Console.ReadLine();

                string[] values = csvRange.Split(';');

                foreach (var value in values)
                    linkedList.Add(int.Parse(value));
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void AddElement()
        {
            try
            {
                Console.WriteLine("Input Element:");
                int element = int.Parse(Console.ReadLine());

                linkedList.Add(element);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DeleteElement()
        {
            try
            {
                Console.WriteLine("Input index of element:\t");

                int index = int.Parse(Console.ReadLine());

                linkedList.Remove(index);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ContainsValue()
        {
            try
            {
                Console.WriteLine($"Input value for search:");
                int value = int.Parse(Console.ReadLine());

                Console.WriteLine($"Contains:\t{linkedList.Contains(value)}");

            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void TaskForLab()
        {
            try
            {
                int min = linkedList.GetMin();
                int indexOfMin = linkedList.IndexOf(min);

                linkedList.Remove(indexOfMin);

                int lastElement = linkedList[(linkedList.Count - 1)];

                while (linkedList.Contains(lastElement))
                    linkedList.Remove(linkedList.IndexOf(lastElement));

                Console.WriteLine("linkedList:");

                linkedList.View(linkedListViewer);

            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        static void Defense()
        {
            try
            {
                linkedList.DeleteAllBeforeVal();

                linkedList.View(new ViewForDefense());
            }
            catch(Exception e) //I should change it later!!!
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
