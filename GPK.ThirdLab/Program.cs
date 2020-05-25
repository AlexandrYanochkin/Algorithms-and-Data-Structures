using GPK.ThirdLab.Services;
using System;

namespace GPK.ThirdLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Facade facade = FacadeFactory.GetFacade();

            facade.PathToFile = @"..\..\..\Files\graph.csv";

            GraphMenu graphMenu = new GraphMenu(facade);

            graphMenu.Menu();

        }
    }
}
