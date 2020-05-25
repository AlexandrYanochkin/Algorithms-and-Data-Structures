using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services.Interfaces
{
    public interface IReader<T>
    {
        T Read(string path);
    }
}
