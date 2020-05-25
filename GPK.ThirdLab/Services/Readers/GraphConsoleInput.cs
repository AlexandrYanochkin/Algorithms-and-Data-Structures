using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.ThirdLab.Services.Readers
{
    public class GraphConsoleInput : IInputOfItem<Graph>
    {
        public void Input(out Graph item)
        {
            Console.WriteLine("Input size of matrix");
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            Rib[,] ribs = new Rib[sizeOfMatrix, sizeOfMatrix];

            for(int i = 0;i < sizeOfMatrix; i++)
            {
                for (int g = 0; g < sizeOfMatrix; g++)
                {
                    Console.WriteLine($"Input existance of Rib[{i},{g}]:");

                    int ribValue = int.Parse(Console.ReadLine());

                    if (ribValue != 0 && ribValue != 1)
                        throw new ArgumentException("Invalid value!!!");

                    ribs[i, g].Exist = (ribValue != 0);

                    if(ribs[i, g].Exist)
                    {
                        Console.WriteLine($"Input weight of Rib[{i},{g}]:");
                        ribs[i, g].Weight = int.Parse(Console.ReadLine());
                    }             
                }
            }

            item = new Graph(ribs);
        }
    }
}
