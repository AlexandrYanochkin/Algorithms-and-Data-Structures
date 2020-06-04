using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFive.Services.Interfaces
{
    public interface IWriter<T>
    {
        void Write(string path, T item);
    }
}
