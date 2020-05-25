using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPK.ThirdLab.Services.Validators
{
    public static class PathValidator
    {
        public static void ValidateCsvPath(this string path)
            => ValidatePath(path, ".csv");

        private static void ValidatePath(string path, string format)
        {
            if (!path.EndsWith(format))
                throw new ArgumentException($"Incorrect path!!! Path should be in {format} format!!!");
        }

        public static void CheckFileExistance(this string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!!!");
        }

    }
}
