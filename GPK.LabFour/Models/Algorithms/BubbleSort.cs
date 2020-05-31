using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class BubbleSort : ISort<Data, SortingResult>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public BubbleSort(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public SortingResult Sort(Data[] array)
        {
            SortingResult sortingResult = new SortingResult { ArrayOfData = array };
            var watch = Stopwatch.StartNew();

            for(int i = 0;i < array.Length; i++)
            {
                for(int g = 0;g < (array.Length - 1); g++)
                {
                    sortingResult.CountOfCompares++;
                    if(_compareMethod.Invoke(array[g], array[g + 1]) == 1)
                    {
                        Swapper.Swap(ref array[g], ref array[g + 1]);
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
