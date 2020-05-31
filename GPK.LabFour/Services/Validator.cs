using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GPK.LabFour.Services
{
    public static class Validator
    {
        public static void ValidateTxtPath(this string path)
            => ValidatePath(path, ".txt");

        private static void ValidatePath(string path, string format)
        {
            if (string.IsNullOrEmpty(path) || !path.EndsWith(format))
                throw new ArgumentException("Incorrect path!!!");
        }

    }
}
