using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPK.LabFive.Models.Archivators
{
    public class LZW : IArchivator
    {
        private List<char> GetListOfSymbols(string line)
            => line.Distinct().ToList();

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
            var allCodes = lines.Last().Split(';')
                .Select(t => new Pair { Code = int.Parse(t) })
                .ToList();

            StringBuilder decodedString = new StringBuilder();

            for (int i = 0; i < alphabet.Count; i++)
            {
                allCodes.Where(t => t.Code == i).ToList()
                    .ForEach(t => t.Value = alphabet[i]);
            }

            int prevCode = allCodes.First().Code;
            string symb = allCodes.First().Value;
            decodedString.Append(symb);

            for (int i = 1; i < allCodes.Count; i++)
            {
                int currCode = allCodes[i].Code;
                string str = string.Empty;

                if (!alphabet.Contains(allCodes.Find(t => t.Code == currCode).Value))
                {
                    str = allCodes.Find(t => t.Code == prevCode).Value;
                    str = (str + symb);
                }
                else
                {
                    str = (allCodes.Find(t => t.Code == currCode).Value);
                }

                decodedString.Append(str);
                symb = str.First().ToString();
                alphabet.Add(allCodes.Find(t => t.Code == prevCode).Value + symb);

                allCodes.Where(t => t.Code == (alphabet.Count - 1))
                              .ToList()
                              .ForEach(t => t.Value = alphabet.Last());

                prevCode = currCode;
            }

            return decodedString.ToString();
        }

        private class Pair
        {
            public int Code { get; set; }

            public string Value { get; set; }
        }
        
    }
}
