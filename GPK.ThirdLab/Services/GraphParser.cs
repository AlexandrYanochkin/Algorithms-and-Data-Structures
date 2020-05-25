using GPK.ThirdLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPK.ThirdLab.Services
{
    public static class GraphParser
    {
        public static Graph ParseToGraph(this IEnumerable<string> lines)
        {
            var linesList = lines.ToList();


            Rib[,] ribs = new Rib[linesList.Count, linesList.Count];

            for(int i = 0;i < linesList.Count; i++)
            {
                var itemsList = linesList[i].Split(';').ToList();

                if (itemsList.Count != (linesList.Count * 2))
                    throw new ArgumentException("Incorrect values for parsing!!!");

                var weights = itemsList.Where(t => t.All(symb => char.IsDigit(symb))).ToList();

                var ribsExistance = itemsList.Where(t => (t == "True" || t == "False")).ToList();

                var ribsResult = ribsExistance.Zip(weights, (ribExistance, weight) => new Rib {
                    Exist = bool.Parse(ribExistance) ,
                    Weight = int.Parse(weight)
                }).ToList();

                for(int g = 0;g < ribsResult.Count;g++)
                {
                    ribs[i, g] = ribsResult[g];
                }

            }

            return new Graph(ribs);
        } 

    }
}
