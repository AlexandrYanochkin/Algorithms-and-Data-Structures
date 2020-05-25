using System;
using System.Collections.Generic;
using System.Text;
using GPK.ThirdLab.Models;
using GPK.ThirdLab.Services.Readers;
using GPK.ThirdLab.Services.Writers;

namespace GPK.ThirdLab.Services
{
    public static class FacadeFactory
    {
        public static Facade GetFacade()
        {
            Facade facade = new Facade(new GraphConsoleInput(),
                new GraphConsoleView(),
                new GraphCSVReader(),
                new GraphCSVWriter());

            return facade;
        }

    }
}
