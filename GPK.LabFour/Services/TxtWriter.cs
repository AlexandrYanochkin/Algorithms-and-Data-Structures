using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPK.LabFour.Services
{
    public class TxtWriter : IWriter<SortingResult>
    {
        public void Write(string path, SortingResult item)
        {
            path.ValidateTxtPath();
            
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("------------------------------------------------");

                Array.ForEach(item.ArrayOfData, data =>
                {
                    streamWriter.WriteLine($"{data.Date:dd.MM.yyyy};{data.Number:F2};{data.Pattern}");
                });

                streamWriter.WriteLine("------------------------------------------------");

                streamWriter.WriteLine($"CountOfCompare:\t{item.CountOfCompares}" +
                    $"\nCountOfSwaps:\t{item.CountOfSwaps}" +
                    $"\nTime:\t{item.Time.TotalMilliseconds} ms");
            }
        }

    }
}
