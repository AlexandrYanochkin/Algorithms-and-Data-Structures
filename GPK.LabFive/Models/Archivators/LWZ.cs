using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPK.LabFive.Models.Archivators
{
    public class LWZ : IArchivator
    {
        private List<char> GetListOfSymbols(string line)
            => line.Select(t => t).Distinct().ToList();

        public string Encode(string line)
        {            
            List<string> list = GetListOfSymbols(line).Select(t => t.ToString()).ToList();
            StringBuilder encodedString = new StringBuilder(list.Aggregate((fStr, sStr) => $"{fStr};{sStr}"));
            encodedString.Append(Environment.NewLine);

            string fLine = string.Empty, sLine = string.Empty;

            for(int i = 0;i < line.Length; i++)
            {
                sLine = line[i].ToString();
                string resultLine = (fLine + sLine);


                if (list.Contains(resultLine))
                    fLine = resultLine;
                else
                {
                    list.Add(resultLine);

                    if (!string.IsNullOrEmpty(fLine))
                        encodedString.Append($"{list.IndexOf(fLine)};");

                    fLine = sLine;
                }
            }

            if (!string.IsNullOrEmpty(fLine))
                encodedString.Append($"{list.IndexOf(fLine)}");


            return encodedString.ToString();
        }

        public string Decode(string line)
        {
            var lines = line.Split(Environment.NewLine);
            var alphabet = lines.First().Split(';').ToList();
            var allText = lines.Last();
            StringBuilder decodedString = new StringBuilder();


            var allCodes = allText.Split(';')
                .Select(t => new Pair { Code = int.Parse(t) }).ToList();

            for(int i = 0;i < alphabet.Count; i++)
            {
                allCodes.Where(t => t.Code == i).ToList()
                    .ForEach(t => t.Value = alphabet[i]);
            }


            string fLine = string.Empty, sLine = string.Empty, resultLine = string.Empty;
          
            for (int i = 0; i < allCodes.Count; i++)
            {
                sLine = allCodes[i].Value;
                resultLine = (fLine + sLine);

                if (alphabet.Contains(resultLine))
                    fLine = resultLine;
                else
                {
                    alphabet.Add(resultLine);

                    allCodes.Where(t => t.Code == (alphabet.Count - 1))
                        .ToList()
                        .ForEach(t => t.Value = resultLine);

                    fLine = sLine;
                }
            }

            for (int i = 0; i < allCodes.Count; i++)
                decodedString.Append(allCodes[i].Value);
          

            return decodedString.ToString();
        }

        private class Pair
        {
            public int Code { get; set; }

            public string Value { get; set; }
        }
        
    }
}
