using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class InterpolationSearch : ISearch<Data>
    {
        public int Search(Data[] array, Data item)
        {
            int left = 0, right = (array.Length - 1), mid = 0;

            while(array[left].GetHashCode() <= item.GetHashCode() && array[right].GetHashCode() >= item.GetHashCode())
            {
                mid = left +
                 ((item.GetHashCode() - array[left].GetHashCode()) * (right - left)) / (array[right].GetHashCode() - array[left].GetHashCode());

                if (array[mid].GetHashCode() < item.GetHashCode())
                    left = (mid + 1);
                else if (array[mid].GetHashCode() > item.GetHashCode())
                    right = (mid - 1);
                else
                    return mid;


            }        

            return (array[left].GetHashCode() == item.GetHashCode()) ? left : -1;
        }
    }
}
