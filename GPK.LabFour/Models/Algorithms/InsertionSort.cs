using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class InsertionSort : ISort<Data, SortingResult>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public InsertionSort(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public SortingResult Sort(Data[] array)
        {
            SortingResult sortingResult = new SortingResult { ArrayOfData = array };
            var watch = Stopwatch.StartNew();

            for(int i = 1; i < array.Length; i++)
            {
                bool continueComparing = true;
                for (int g = i; g > 0 && continueComparing; g--)
                {
                    continueComparing = (_compareMethod(array[g - 1], array[g]) == 1);
                    sortingResult.CountOfCompares++;

                    if (continueComparing)
                    {
                        Swapper.Swap(ref array[g], ref array[g - 1]);
                        sortingResult.CountOfSwaps++;
                    }
                }                      
            }


            watch.Stop();
            sortingResult.Time = watch.Elapsed;

            return sortingResult;
        }
    }
}
