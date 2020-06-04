using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFive.Models
{
    public class Letter
    {
        public char Symbol { get; set; }
        public double Probability { get; set; }
        public override string ToString()
        {
            return $"{Symbol}:{Probability}";
        }
    }
}
