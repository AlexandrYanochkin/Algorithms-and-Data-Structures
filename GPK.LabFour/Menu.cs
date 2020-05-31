using GPK.LabFour.Models;
using GPK.LabFour.Models.Algorithms;
using GPK.LabFour.Models.DTO;
using GPK.LabFour.Models.Factories;
using GPK.LabFour.Services;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour
{
    public static class Menu
    {
        public static SortAlgorithm Algorithm { get; set; } 

        public static SortMode Mode { get; set; }

        public static ISearch<Data> SearchingAlgorithm { get; set; }

        public static int Count { get; set; }

        public static void MainMenu()
        {
            Facade facade = new Facade()
            {
                CountOfElements = Count,
                ResultPrinter = new TxtWriter()
            };

            bool exit = false;

            while (!exit)
            {

                Console.WriteLine($"\n\t1.SortArray" +
                    $"\n\t2.ChooseSortAlgorithm" +
                    $"\n\t3.ChooseSortMode" +
                    $"\n\t4.SearchData" +
                    $"\n\t5.Exit\n");


                var consoleKey = Console.ReadKey();

                Console.WriteLine();

                switch (consoleKey.Key)
                {
                    case ConsoleKey.D1:
                        facade.SortAlgorithm = SortAlgorithmFactory.GetAlgorithm(Algorithm, Mode);
                        facade.PathToFile = $@"..\..\..\Files\ResultsOf{Algorithm}{Mode}.txt";
                        facade.StartMethod();

                        break;

                    case ConsoleKey.D2:
                        ChooseSortAlgorithm();

                        break;

                    case ConsoleKey.D3:
                        ChooseSortMode();

                        break;


                    case ConsoleKey.D4:
                        SearchMethod();
                        break;

                    case ConsoleKey.D5:
                        exit = true;
                        break;

                }

                Console.WriteLine("\nDone");
                Console.ReadKey();
                Console.Clear();
            }

           
        }

        public static void SearchMethod()
        {
            var dataArray = DataGenerator.Generate(1000);
            QuickSort quickSort = new QuickSort(CompareMethodFactory.GetMethod(SortMode.SortByTwoKeys));
            quickSort.Sort(dataArray);
            var data = dataArray[999];

            Array.ForEach(dataArray, data => Console.WriteLine($"{data} - {data.GetHashCode()}"));


            int ind = SearchingAlgorithm.Search(dataArray, data);
            Console.WriteLine($"IndexAfterSearch:\t{ind}");
        }

        public static void ChooseSortMode()
        {
            Console.WriteLine($"\t1.SortByOneKey" +
                                $"\n\t2.SortByTwoKeys" +
                                $"\n\t3.SortByThreeKeys");

            var consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.D1:
                    Mode = SortMode.SortByOneKey;
                    break;

                case ConsoleKey.D2:
                    Mode = SortMode.SortByTwoKeys;
                    break;


                case ConsoleKey.D3:
                    Mode = SortMode.SortByThreeKeys;
                    break;


                default:
                    Console.WriteLine("Incorrect Input!!!");
                    break;
            }
        }

        public static void ChooseSortAlgorithm()
        {
            Console.WriteLine("\n\t1.BubbleSort" +
                "\n\t2.SelectionSort" +
                "\n\t3.InsertionSort" +
                "\n\t4.QuickSort" +
                "\n\t5.BubbleSortWithCheckOfState");

            var consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.D1:
                    Algorithm = SortAlgorithm.BubbleSort;
                    break;

                case ConsoleKey.D2:
                    Algorithm = SortAlgorithm.SelectionSort;
                    break;


                case ConsoleKey.D3:
                    Algorithm = SortAlgorithm.InsertionSort;
                    break;

                case ConsoleKey.D4:
                    Algorithm = SortAlgorithm.QuickSort;
                    break;

                case ConsoleKey.D5:
                    Algorithm = SortAlgorithm.BubbleWithCheckOfState;
                    break;

                default:
                    Console.WriteLine("Incorrect Input!!!");
                    break;
            }

        }

    }
}
