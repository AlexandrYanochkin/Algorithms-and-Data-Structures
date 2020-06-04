using GPK.LabFive.Models.Archivators;
using GPK.LabFive.Services;
using GPK.LabFive.Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace GPK.LabFive
{
    class Program
    {
        public static IArchivator Archivator { get; set; }

        public static IWriter<string> Writer { get; set; } = new TxtWriter();

        public static IReader<string> Reader { get; set; } = new TxtReader();



        static void Main(string[] args)
        {
            Menu();

            Console.ReadKey();
        }

        public static void Menu()
        {
            bool mode = false;

            Console.WriteLine("Choose Archivation Algorithm\n" +
                "\n\t1.LZW" +
                "\n\t2.Arifmethic Compression");

            var keyInfo = Console.ReadKey();

            Console.WriteLine();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Archivator = new LZW();
                    break;

                case ConsoleKey.D2:
                    Archivator = new ArifmethicCompression();
                    break;
            }

            if (Archivator == null)
                return;

            Console.WriteLine("Choose mode\n" +
                "\n\t1.Without password" +
                "\n\t2.With password");

            keyInfo = Console.ReadKey();

            Console.WriteLine();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    mode = false;
                    break;

                case ConsoleKey.D2:
                    mode = true;
                    break;
            }

            ConsoleFacade consoleFacade = new ConsoleFacade(Archivator, Writer, Reader,
                           @"..\..\..\Files\InputFile.txt",
                           @"..\..\..\Files\OutputFile.txt",
                           @"..\..\..\Files\ResultsFile.txt");

            if (mode)
                consoleFacade.ProcessWithPassword();
            else
                consoleFacade.Process();
        }

    }
}


