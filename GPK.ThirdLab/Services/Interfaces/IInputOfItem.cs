using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services.Interfaces
{
    public interface IInputOfItem<T>
    {
        void Input(out T item);
    }
}
