using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.DTO
{
    public class SortingResult
    {
        public TimeSpan Time { get; set; }
        public int CountOfCompares { get; set; }
        public int CountOfSwaps { get; set; }
        public Data[] ArrayOfData { get; set; }
    }
}
