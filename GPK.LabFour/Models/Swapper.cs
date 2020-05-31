using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models
{
    public static class Swapper
    {
        public static void Swap<T>(ref T arg1, ref T arg2)
        {
            T glass = arg1;
            arg1 = arg2;
            arg2 = glass;
        }

    }
}
