using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class SelectionSort : ISort<Data, SortingResult>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public SelectionSort(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public SortingResult Sort(Data[] array)
        {
            SortingResult sortingResult = new SortingResult { ArrayOfData = array };
            var watch = Stopwatch.StartNew();

            for(int i = 0;i < array.Length; i++)
            {
                int ind = GetItem(array, i, sortingResult);

                Swapper.Swap(ref array[i], ref array[ind]);
                sortingResult.CountOfSwaps++;
            }

            watch.Stop();
            sortingResult.Time = watch.Elapsed;

            return sortingResult;
        }

        private int GetItem(Data[] array, int ind, SortingResult sortingResult)
        {
            Data data = array[ind];
            int indOfEl = ind;

            for(int i = (ind + 1); i < array.Length; i++)
            {
                sortingResult.CountOfCompares++;
                if (_compareMethod(array[i], data) == -1)
                {
                    data = array[i];
                    indOfEl = i;
                }
            }

            return indOfEl;
        }

    }
}
