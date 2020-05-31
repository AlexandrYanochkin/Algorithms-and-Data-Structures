using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Services.Interfaces
{
    public interface ISearch<T>
    {
        int Search(T[] array, T item);
    }
}
