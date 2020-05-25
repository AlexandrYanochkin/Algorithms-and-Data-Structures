using GPK.FirstLab.ArrayList;
using GPK.FirstLab.LinkList;
using System;

namespace GPK.FirstLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t1.LinkedList\n" +
                              "\t2.AssociativeLinkedList\n");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    UserInterface.linkedList = new LinkedList<int>();
                    break;

                case ConsoleKey.D2:
                    UserInterface.linkedList = new AssociativeLinkedList<int>();
                    break;


            }

            if(UserInterface.linkedList != null)
                UserInterface.Menu();

          


            Console.ReadKey();
        }
    }
}
