using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services.Writers
{
    public class GraphConsoleView : IOutputOfItem<Graph>
    {
        public void View(Graph item)
        {
            Console.WriteLine();
            for (int i = 0;i < item.CountOfVertices; i++)
            {
                for(int g = 0;g < item.CountOfVertices; g++)
                {
                    Console.Write($"{item.Ribs[i,g]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
