using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class BubbleSortWithCheckOfState : ISort<Data, SortingResult>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public BubbleSortWithCheckOfState(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public SortingResult Sort(Data[] array)
        {
            SortingResult sortingResult = new SortingResult { ArrayOfData = array };
            var watch = Stopwatch.StartNew();
            bool isOrdered = false;

            for(int i = 0;i < array.Length && !isOrdered; i++)
            {
                for(int g = 0;g < (array.Length - 1); g++)
                {
                    sortingResult.CountOfCompares++;
                    if (_compareMethod(array[g], array[g + 1]) == 1)
                    {
                        Swapper.Swap(ref array[g], ref array[g + 1]);
                        sortingResult.CountOfSwaps++;
                    }
                }

                isOrdered = CheckState(array, sortingResult);
            }

            watch.Stop();
            sortingResult.Time = watch.Elapsed;

            return sortingResult;
        }
        
        private bool CheckState(Data[] array, SortingResult sortingResult)
        {
            bool isOrdered = true;
            for (int i = 0; i < (array.Length - 1) && isOrdered; i++)
            {
                sortingResult.CountOfCompares++;
                isOrdered = (_compareMethod(array[i], array[i + 1]) == 1);
            }

            return isOrdered;
        }

    }
}
