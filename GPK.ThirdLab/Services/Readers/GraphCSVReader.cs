using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Interfaces;
using GPK.ThirdLab.Services.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPK.ThirdLab.Services.Readers
{
    public class GraphCSVReader : IReader<Graph>
    {
        public Graph Read(string path)
        {
            path.ValidateCsvPath();
            path.CheckFileExistance();

            Graph graph = null;

            using (StreamReader streamReader = new StreamReader(path))
            {
                List<string> lines = new List<string>();

                while (!streamReader.EndOfStream)
                    lines.Add(streamReader.ReadLine());

                graph = lines.ParseToGraph();

            }

            return graph;
        }
    }
}
