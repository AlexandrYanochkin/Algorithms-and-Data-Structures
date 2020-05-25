using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Models
{
    public struct Rib
    {
        public bool Exist { get; set; }
        public int Weight { get; set; }

        public Rib(bool exist, int weight)
        {
            Exist = exist;
            Weight = weight;
        }


        public override string ToString() => ($"{Exist};{Weight}");
    }
}
