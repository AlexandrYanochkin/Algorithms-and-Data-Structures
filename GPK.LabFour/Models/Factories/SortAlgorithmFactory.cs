using GPK.LabFour.Models.Algorithms;
using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.Factories
{
    public static class SortAlgorithmFactory
    {
        public static ISort<Data, SortingResult> GetAlgorithm(SortAlgorithm sortAlgorithm, SortMode sortMode)
        {
            Func<Data, Data, int> compareFunc = CompareMethodFactory.GetMethod(sortMode);
            ISort<Data, SortingResult> sortVariable = null;

            switch (sortAlgorithm)
            {
                case SortAlgorithm.BubbleSort:
                    sortVariable = new BubbleSort(compareFunc);
                    break;

                case SortAlgorithm.SelectionSort:
                    sortVariable = new SelectionSort(compareFunc);
                    break;


                case SortAlgorithm.InsertionSort:
                    sortVariable = new InsertionSort(compareFunc);
                    break;

                case SortAlgorithm.QuickSort:
                    sortVariable = new QuickSort(compareFunc);
                    break;

                case SortAlgorithm.BubbleWithCheckOfState:
                    sortVariable = new BubbleSortWithCheckOfState(compareFunc);
                    break;

                default:
                    throw new ArgumentException("Algorithm not found!!!");
            }

            return sortVariable;
        }
    }
}
