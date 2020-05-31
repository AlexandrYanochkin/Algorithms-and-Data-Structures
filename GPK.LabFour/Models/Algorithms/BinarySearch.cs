using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class BinarySearch : ISearch<Data>
    {
        private readonly Func<Data, Data, int> _compareMethod;

        public BinarySearch(Func<Data, Data, int> compareMethod)
        {
            _compareMethod = compareMethod;
        }

        public int Search(Data[] array, Data item)
        {
            return BinarySearchMethod(0, array.Length, array, item);    
        }

        private int BinarySearchMethod(int startIndex, int endIndex, Data[] array, Data item)
        {
            int middleIndex = (startIndex + endIndex) / 2;
            Data middleElement = array[middleIndex];

            if (_compareMethod(item, middleElement) == 1)
                return BinarySearchMethod(middleIndex, endIndex, array, item);
            else if (_compareMethod(item, middleElement) == -1)
                return BinarySearchMethod(startIndex, middleIndex, array, item);
            else
                return middleIndex;
        }

    }
}
