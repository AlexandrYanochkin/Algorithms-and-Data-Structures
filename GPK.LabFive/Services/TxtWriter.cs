using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPK.LabFive.Services
{
    public class TxtWriter : IWriter<string>
    {
        public void Write(string path, string item)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
                streamWriter.Write(item);
        }  
    }
}
