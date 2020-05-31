using GPK.LabFour.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPK.LabFour.Services
{
    public static class DataGenerator
    {
        private static Random randomizer = new Random();


        public static Data[] Generate(int count)
        {
            Data[] array = new Data[count];

            for(int i = 0;i < count; i++)
            {
                array[i] = GenerateItem();
            }

            return array;
        }

        private static Data GenerateItem()
        {
            Data data = new Data();

            data.Date = GetRandomDate();
            data.Number = (randomizer.Next(50, 250) + randomizer.NextDouble());
            data.Pattern = GetRandomPattern(8);

            return data;
        }

        private static DateTime GetRandomDate()
        {
            DateTime dateTime = new DateTime();

            dateTime = dateTime.AddYears(randomizer.Next(1750, 2400));

            dateTime = dateTime.AddMonths(randomizer.Next(1, 13));

            if(dateTime.Month % 2 == 0)
            {
                int daysCount = (dateTime.Month != 2) ? randomizer.Next(1, 31) : randomizer.Next(1, 29);
                dateTime = dateTime.AddDays(daysCount);
            }
            else
            {
                dateTime.AddDays(randomizer.Next(1, 32));
            }


            return dateTime;
        }

        private static string GetRandomPattern(int count)
        {
            StringBuilder randomPatternBuilder = new StringBuilder();
            
            for(int i = 0;i < count; i++)
            {
                //Generate Letter
                if(randomizer.Next(0, 2) == 1)
                {
                    bool bigLetter = (randomizer.Next(0, 2) == 1);
                    char letter = (char)randomizer.Next(65, 91);

                    letter = bigLetter ? letter : char.ToLower(letter);
                    randomPatternBuilder.Append(letter);
                }
                else //Generate Number
                {
                    randomPatternBuilder.Append((char)(randomizer.Next(48, 58)));
                }
            }

            return randomPatternBuilder.ToString();
        }

    }
}
