using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GPK.LabFive.Services
{
    public class ConsoleFacade
    {
        private readonly IWriter<string> _writer;

        private readonly IReader<string> _reader;

        private readonly string _inputPath, _outputPath, _resultPath;

        private readonly IArchivator _archivator;

        public ConsoleFacade(IArchivator archivator, IWriter<string> writer, IReader<string> reader,
            string inputPath, string outputPath, string resultPath)
        {
            _archivator = archivator;
            _writer = writer;
            _reader = reader;
            _inputPath = inputPath;
            _outputPath = outputPath;
            _resultPath = resultPath;
        }

        public void Process()
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                string line = _reader.Read(_inputPath);

                string encodedLine = _archivator.Encode(line);

                _writer.Write(_outputPath, encodedLine);

                string decodedLine = _archivator.Decode(encodedLine);

                _writer.Write(_resultPath, decodedLine);

                stopwatch.Stop();
                Console.WriteLine($"timeForAll:\t{stopwatch.Elapsed.TotalMilliseconds} ms");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void ProcessWithPassword()
        {
            try
            {
                Console.WriteLine("Input password:");
                string password = Console.ReadLine();

                Stopwatch stopwatch = Stopwatch.StartNew();

                string line = _reader.Read(_inputPath);

                line = password + line;

                string encodedLine = _archivator.Encode(line);

                _writer.Write(_outputPath, encodedLine);

                string decodedLine = _archivator.Decode(encodedLine);

                Console.WriteLine("Input password for check:");
                string passwordForCheck = Console.ReadLine();

                string passwordSec = decodedLine.Substring(0, password.Length);

                if (passwordForCheck != passwordSec)   
                    Console.WriteLine("Incorrect password!!!");             
                else
                    Console.WriteLine("Done!!!");

                _writer.Write(_resultPath, decodedLine);

                stopwatch.Stop();
                Console.WriteLine($"timeForAll:\t{stopwatch.Elapsed.TotalMilliseconds} ms");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
