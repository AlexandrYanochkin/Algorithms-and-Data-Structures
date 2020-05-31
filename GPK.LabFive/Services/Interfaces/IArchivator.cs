using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFive.Services.Interfaces
{
    public interface IArchivator
    {
        string Encode(string line);
        string Decode(string line);
    }
}
