using GPK.LabFive.Models.Archivators;
using System;
using System.IO;

namespace GPK.LabFive
{
    class Program
    {
        static void Main(string[] args)
        {
            LWZ lwz = new LWZ();

            string allText = string.Empty;

            using (StreamReader streamReader = new StreamReader(@"..\..\..\Files\InputFile.txt"))
                allText = streamReader.ReadToEnd();

            Console.WriteLine(allText);
            

            string encodedLine = lwz.Encode(allText);

            Console.WriteLine(encodedLine);

            using (StreamWriter streamWriter = new StreamWriter(@"..\..\..\Files\OutputFile.txt"))
                streamWriter.Write(encodedLine);


            Console.WriteLine($"\n\n\n");

            string decodedLine = lwz.Decode(encodedLine);

            Console.WriteLine(decodedLine);


            Console.ReadKey();
        }
    }
}
