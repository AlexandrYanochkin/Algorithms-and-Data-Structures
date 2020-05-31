using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.Algorithms
{
    public class LinearSearch : ISearch<Data>
    {
        public int Search(Data[] array, Data item)
        {
            int indexOfElement = -1;
            for(int i = 0;i < array.Length && (indexOfElement == -1); i++)
            {
                if (array[i].Equals(item))
                    indexOfElement = i;
            }

            return indexOfElement;
        }
    }
}
