using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFive.Services.Interfaces
{
    public interface IReader<T>
    {
        T Read(string path);
    }
}
