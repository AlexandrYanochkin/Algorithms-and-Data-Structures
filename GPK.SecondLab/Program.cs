using GPK.SecondLab.Additional.Defens;
using GPK.SecondLab.Additional.TreeFinders;
using GPK.SecondLab.Additional.TreeViewers;
using GPK.SecondLab.Models.AssociativeTree;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.SimpleTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPK.SecondLab
{
    class Program
    {
        static ITree<int> Tree;

        static void Main(string[] args)
        {
            Facade Facade = null;

            Console.WriteLine("\n\t1.Tree" +
                "\n\t2.AssociativeTree" +
                "\n\tAnother. Exit");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:

                    Tree = new Tree<int>();
                    Facade = new Facade(Tree, new TreeConsoleViewer<int>()
                                        ,new TreeFinder<int>(Tree as Tree<int>)
                                        ,new TreeLeavesRemover<int>(Tree as Tree<int>));
                    break;

                case ConsoleKey.D2:

                    Tree = new AssociativeTree<int>();
                    Facade = new Facade(Tree, new TreeConsoleViewer<int>()
                                        , new AssociativeTreeFinder<int>(Tree as AssociativeTree<int>)
                                        , new AssociativeTreeLeavesRemover<int>(Tree as AssociativeTree<int>));
                    break;
            }

            if (Facade != null)
                Facade.Main();

        }

    }
}
