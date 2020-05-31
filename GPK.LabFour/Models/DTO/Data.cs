using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models.DTO
{
    public class Data
    {
        public DateTime Date { get; set; }
        public double Number { get; set; }
        public string Pattern { get; set; }


        public override bool Equals(object obj)
            => obj is Data data && (GetHashCode() == data.GetHashCode());

        public override int GetHashCode() 
            => HashCode.Combine(Date, Number, Pattern);

        public override string ToString()
            => ($"{Date:dd.MM.yyyy};{Number:F2};{Pattern}");
    }
}
