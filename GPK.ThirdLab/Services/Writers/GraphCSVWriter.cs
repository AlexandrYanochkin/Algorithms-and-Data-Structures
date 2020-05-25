using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Interfaces;
using GPK.ThirdLab.Services.Validators;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace GPK.ThirdLab.Services.Writers
{
    public class GraphCSVWriter : IWriter<Graph>
    {
        public void Write(string path, Graph item)
        {
            path.ValidateCsvPath();
            
            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                for (int i = 0; i < item.Ribs.GetLength(0); i++)
                {           
                    for (int g = 0; g < item.Ribs.GetLength(1); g++)
                        streamWriter.Write(g == (item.Ribs.GetLength(1) - 1) ? item.Ribs[i,g].ToString() : $"{item.Ribs[i,g]};");

                    if(i != (item.Ribs.GetLength(0) - 1))
                        streamWriter.WriteLine();
                }
            }

        }
    }
}
