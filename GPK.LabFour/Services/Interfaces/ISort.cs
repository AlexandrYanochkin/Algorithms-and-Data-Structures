using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Services.Interfaces
{
    public interface ISort<T, TOut>
    {
        TOut Sort(T[] array);
    }
}
