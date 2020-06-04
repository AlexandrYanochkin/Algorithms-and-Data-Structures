using GPK.LabFive.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPK.LabFive.Models.Archivators
{
    public class ArifmethicCompression : IArchivator
    {
        public string Encode(string line)
        {
            var symbols = line.Distinct().ToList();
            var letters = new List<Letter>();
            StringBuilder encodedString = new StringBuilder();


            foreach (var symb in symbols)
            {
                letters.Add(new Letter { Symbol = symb, Probability = ((double)line.Where(t => t == symb).Count() / line.Length) });
            }

            encodedString.Append(letters.Select(t => t.ToString()).Aggregate((fStr, sStr) => $"{fStr};{sStr}"));
            encodedString.Append(Environment.NewLine);

            double result = ArithmethicCoding(letters, line);

            encodedString.Append($"{line.Length};{result}");

            return encodedString.ToString();
        }

        private double ArithmethicCoding(List<Letter> letters, string line)
        {
            List<Segment> segments = DefineSegments(letters);
            double left = 0;
            double right = 1;

            for (int i = 0; i < line.Length; i++)
            {
                double newRight = left + (right - left) * segments.First(p => p.Symbol == line[i]).Right;
                double newLeft = left + (right - left) * segments.First(p => p.Symbol == line[i]).Left;

                left = newLeft;
                right = newRight;
            }
            return (left + right) / 2;
        }

        public string Decode(string line)
        {
            var lines = line.Split(Environment.NewLine);
            var letters = lines.First().Split(';').Select(t =>
            {
                var pair = t.Split(':');
                return new Letter { Symbol = pair.First().Single(), Probability = double.Parse(pair.Last()) };
            }).ToList();
            var numAndLength = lines.Last().Split(';');

            double code = double.Parse(numAndLength.Last());
            int lengthOfText = int.Parse(numAndLength.First());

            return ArithmethicDecoding(letters, code, lengthOfText);
        }
      
        private string ArithmethicDecoding(List<Letter> letters, double code, int textLength)
        {
            StringBuilder line = new StringBuilder();
            List<Segment> segments = DefineSegments(letters);

            for (int i = 0; i < textLength; i++)
            {
                for (int j = 0; j < letters.Count; j++)
                {
                    if (code >= segments[j].Left && code < segments[j].Right)
                    {
                        line.Append(segments[j].Symbol);
                        code = (code - segments[j].Left) / (segments[j].Right - segments[j].Left);
                        break;
                    }
                }
            }
            return line.ToString();
        }

        private List<Segment> DefineSegments(List<Letter> letters)
        {
            List<Segment> segments = new List<Segment>();
            double leftPart = 0;

            for (int i = 0; i < letters.Count; i++)
            {
                Segment segment = new Segment
                {
                    Left = leftPart,
                    Right = leftPart + letters[i].Probability,
                    Symbol = letters[i].Symbol
                };

                segments.Add(segment);

                leftPart = segment.Right;
            }

            return segments;
        }

    }
}
