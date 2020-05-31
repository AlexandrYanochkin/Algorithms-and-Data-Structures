using GPK.LabFour.Models.DTO;
using GPK.LabFour.Services;
using GPK.LabFour.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Models
{
    public class Facade
    {
        public ISort<Data, SortingResult> SortAlgorithm { get; set; }

        public IWriter<SortingResult> ResultPrinter { get; set; }

        public int CountOfElements { get; set; }

        public string PathToFile { get; set; }

        public void StartMethod()
        {          
            var fArr = DataGenerator.Generate(CountOfElements);

            var sortingResult = SortAlgorithm.Sort(fArr);

            ResultPrinter.Write(PathToFile, sortingResult);
        }

    }

}
