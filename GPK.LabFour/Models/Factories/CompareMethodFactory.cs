using GPK.LabFour.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GPK.LabFour.Models.Factories
{
    public static class CompareMethodFactory
    {
        public static Func<Data,Data, int> GetMethod(SortMode sortMode)
        {
            Func<Data, Data, int> compareFunc = null;

            switch (sortMode)
            {
                case SortMode.SortByOneKey:
                    compareFunc = (fData, sData) => (-1)*fData.Date.CompareTo(sData.Date);
                    break;


                case SortMode.SortByTwoKeys:
                    compareFunc = (fData, sData) =>
                    {
                        int firstCompare = fData.Date.CompareTo(sData.Date);

                        return (firstCompare == 0) ? ((-1) * (fData.Number.CompareTo(sData.Number))) : firstCompare;
                    };
                    break;

                case SortMode.SortByThreeKeys:
                    compareFunc = (fData, sData) =>
                    {
                        int firstCompare = fData.Date.CompareTo(sData.Date);
                        int secCompare = (firstCompare == 0) ? ((-1) * (fData.Number.CompareTo(sData.Number))) : firstCompare;

                        return (secCompare == 0) ? ((-1) * fData.Pattern.CompareTo(sData.Pattern)) : secCompare;
                    };
                    break;

                default:
                    throw new ArgumentException("Key for sort isn't found!!!");
            }


            return compareFunc;
        }

    }
}
