using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class QuickSort : ISort<Data, SortingResult>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public QuickSort(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public SortingResult Sort(Data[] array)
        {
            SortingResult sortingResult = new SortingResult { ArrayOfData = array };

            var watch = Stopwatch.StartNew();

            QuickSortAlgorithm(array, 0, (array.Length - 1), sortingResult);

            watch.Stop();
            sortingResult.Time = watch.Elapsed;

            return sortingResult;
        }

        private void QuickSortAlgorithm(Data[] array, int start, int end, SortingResult sortingResult)
        {
            int left = start, right = end;
            Data pivot = array[(right + left) / 2];

            while(left <= right)
            {
                while (_compareMethod(array[left], pivot) == -1)
                {
                    left++;
                    sortingResult.CountOfCompares++;
                }

                while (_compareMethod(array[right], pivot) == 1)
                {
                    right--;
                    sortingResult.CountOfCompares++;
                }

                sortingResult.CountOfCompares += 2;// because ... 

                if(left <= right)
                {
                    Swapper.Swap(ref array[left++], ref array[right--]);
                    sortingResult.CountOfSwaps++;
                }
              
            }

            if (right > start)
                QuickSortAlgorithm(array, start, right, sortingResult);

            if (left < end)
                QuickSortAlgorithm(array, left, end, sortingResult);
        }

    }
}
