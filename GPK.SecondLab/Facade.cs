using GPK.FirstLab.Additional.Viewers;
using GPK.FirstLab.LinkList;
using GPK.SecondLab.Additional.Defens;
using GPK.SecondLab.Additional.TreeFinders;
using GPK.SecondLab.Models.AssociativeTree;
using GPK.SecondLab.Models.ExceptionsClasses;
using GPK.SecondLab.Models.Interfaces;
using GPK.SecondLab.Models.SimpleTree;
using System;
using System.Linq;

namespace GPK.SecondLab
{
    public class Facade
    {
        public ITree<int> Tree { get; set; }

        public ITreePrinter<int> TreeViewer { get; set; }

        public ITreeFinder<int> Finder { get; set; }

        public ILeafRemover<int> LeafRemover { get; set; } 

        public Facade(ITree<int> tree,ITreePrinter<int> treeViewer,ITreeFinder<int> treeFinder,ILeafRemover<int> leafRemover)
        {
            Tree = tree ?? throw new ArgumentNullException("Tree can't be null!!!");
            TreeViewer = treeViewer ?? throw new ArgumentNullException("TreeViewer can't be null!!!");
            Finder = treeFinder ?? throw new ArgumentNullException("TreeFinder can't be null");
            LeafRemover = leafRemover ?? throw new ArgumentNullException("LeafRemover can't be null");
        }


        public void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"\n\t0.AddNodes" +
                    $"\n\t1.AddNode" +
                    $"\n\t2.DeleteNode" +
                    $"\n\t3.FindNode" +
                    $"\n\t4.ViewTree" +
                    $"\n\t5.MaxAndMinElements" +
                    $"\n\t6.MainTask()" +
                    $"\n\t7.Defens()" +
                    $"\n\t8.Exit");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D0:
                        AddNodes();
                        break;


                    case ConsoleKey.D1:
                        InputWithAction(Tree.AddNode);
                        break;

                    case ConsoleKey.D2:
                        InputWithAction(Tree.DeleteNode);
                        break;


                    case ConsoleKey.D3:
                        FindNode();
                        break;

                    case ConsoleKey.D4:
                        Tree.View(TreeViewer);                       
                        break;

                    case ConsoleKey.D5:
                        ViewMaxAndMinElements();
                        break;


                    case ConsoleKey.D6:
                        MainTask();
                        break;

                    case ConsoleKey.D7:
                        Defens();
                        break;

                    case ConsoleKey.D8:
                        exit = true;
                        break;

                }

                Console.ReadKey();
                Console.Clear();
            }
            
        }

        private void Defens()
        {
            try
            {
                LeafRemover.RemoveLeaves();
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddNodes()
        {
            try
            {
                Console.WriteLine("Input values in csv format:");

                var listOfValues = Console.ReadLine().Split(';').Select(t => Int32.Parse(t)).ToList();

                listOfValues.ForEach(value => Tree.AddNode(value));
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TreeException e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        private void FindNode()
        {
            try
            {
                Console.WriteLine($"Input Element for Searching:\t");
                int elementForSearch = Int32.Parse(Console.ReadLine());

                bool result = Tree.Contains(elementForSearch);

                string resStr = result ? "Tree Contains an element" : "Tree doesn't contain an element";
                Console.WriteLine(resStr);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InputWithAction(Action<int> action)
        {
            try
            {
                Console.WriteLine($"Input element:");
                int value = Int32.Parse(Console.ReadLine());

                action(value);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TreeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ViewMaxAndMinElements()
        {
            try
            {
                Console.WriteLine($"\tMaxElement:\t{Tree.GetMaxNode()}");
                Console.WriteLine($"\tMinElement:\t{Tree.GetMinNode()}");
            }
            catch(TreeException e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        private void MainTask()
        {
            try
            { 
                Tree.View(TreeViewer);

                Console.WriteLine("\nLongest Branch:\n");

                var maxBranch = Finder.FindLongestRightBranch();

                maxBranch.View(new ConsoleViewer<int>());

            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
