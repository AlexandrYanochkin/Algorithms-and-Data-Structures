using GPK.LabFour.Models.Algorithms;
using GPK.LabFour.Models.DTO;
using GPK.LabFour.Models.Factories;
using GPK.LabFour.Services;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GPK.LabFour
{
    public class Program
    {

        static void Main(string[] args)
        {
            Menu.Count = 10000;
            Menu.Algorithm = SortAlgorithm.BubbleSort;
            Menu.Mode = SortMode.SortByOneKey;
            Menu.SearchingAlgorithm = new BinarySearch(CompareMethodFactory.GetMethod(SortMode.SortByTwoKeys));

            Menu.MainMenu();

            Console.ReadKey();
        }

        public static void Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var dataArray = DataGenerator.Generate(100000);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            Console.ReadKey();


            stopwatch.Reset();
            stopwatch.Start();
            foreach (var data in dataArray)
            {
                Console.WriteLine($"{data.Date:dd.MM.yyyy};{data.Number:F2};{data.Pattern}");
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }

        public static void TestSecond()
        {
            ISort<Data, SortingResult> sortVariable =
            new SelectionSort((fData, sData) => fData.Number.CompareTo(sData.Number));

            var arrayOfData = DataGenerator.Generate(100);

            Array.ForEach(arrayOfData, data => Console.WriteLine($"{data.Date:dd.MM.yyyy};{data.Number:F2};{data.Pattern}"));

            var sortingResult = sortVariable.Sort(arrayOfData);

            Console.WriteLine("-------------------------------------");

            Array.ForEach(arrayOfData, data => Console.WriteLine($"{data.Date:dd.MM.yyyy};{data.Number:F2};{data.Pattern}"));

            Console.WriteLine($"\ncountOfCompares:\t{sortingResult.CountOfCompares}\t" +
                $"\ncountOfSwaps:\t{sortingResult.CountOfSwaps}" +
                $"\nTime:\t{sortingResult.Time.TotalSeconds} sec.");
        }

    }
}
