using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services.Interfaces
{
    public interface IOutputOfItem<T>
    {
        void View(T item);
    }
}
