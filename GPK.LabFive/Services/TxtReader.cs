using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPK.LabFive.Services
{
    public class TxtReader : IReader<string>
    {
        public string Read(string path)
        {
            string pattern = string.Empty;
            using (StreamReader streamReader = new StreamReader(path))
                pattern = streamReader.ReadToEnd();

            return pattern;
        }
    }
}
