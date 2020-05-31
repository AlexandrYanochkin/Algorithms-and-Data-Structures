using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services
{
    public class GraphMenu
    {

        public event EventHandler InputOfGraph;
        public event EventHandler OutputOfGraph;
        public event EventHandler SearchOfPath;
        public event EventHandler BreadthFirstSearch;
        public event EventHandler DepthFirstSearch;
        public event EventHandler InputFromFile;
        public event EventHandler OutputInFile;
        public event EventHandler IsGraphDictyledonous;

        public GraphMenu()
        {
        }

        public GraphMenu(Facade facade)
        {
            InputOfGraph += facade.GraphInput;
            OutputOfGraph += facade.GraphOutput;
            SearchOfPath += facade.SearchOfPath;
            BreadthFirstSearch += facade.BreadthFirstSearch;
            DepthFirstSearch += facade.DepthFirstSearch;
            InputFromFile += facade.InputFromFile;
            OutputInFile += facade.OutputInFile;
            IsGraphDictyledonous += facade.CheckIsGraphDictyledonous;
        }

        public void Menu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"\t\t\tGraph Menu\n" +
                    $"\t1.Input Graph\n" +
                    $"\t2.Output Graph\n" +
                    $"\t3.SearchOfShortestPath(Deijkstra)\n" +
                    $"\t4.BreadthFirstSearch\n" +
                    $"\t5.DepthFirstSearch\n" +
                    $"\t6.InputFromFile\n" +
                    $"\t7.OutputInFile\n" +
                    $"\t8.IsGraphDictyledonous\n" +
                    $"\t9.Exit\n");

                var keyInfo = Console.ReadKey();

                Console.WriteLine();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        InputOfGraph.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D2:
                        OutputOfGraph.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D3:
                        SearchOfPath.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D4:
                        BreadthFirstSearch.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D5:
                        DepthFirstSearch.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D6:
                        InputFromFile.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D7:
                        OutputInFile.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D8:
                        IsGraphDictyledonous.Invoke(this, EventArgs.Empty);
                        break;

                    case ConsoleKey.D9:
                        exit = true;
                        break;

                }

                Console.ReadKey();
                
                Console.Clear();
            }
        }

    }
}
