using GPK.FirstLab.LinkList;
using System;
using System.Linq;

namespace GPK.FirstLab.Additional
{
    public static class AdditionalAlgorithms
    {
        public static void Swap<T>(ref T firstValue,ref T secValue)
        {
            T glass = firstValue;
            firstValue = secValue;
            secValue = glass;
        }

        public static T GetMin<T>(this ILinkedList<T> linkedList) where T : IComparable<T>
            => GetValue(linkedList, -1);

        public static T GetMax<T>(this ILinkedList<T> linkedList) where T : IComparable<T>
            => GetValue(linkedList, 1);

        private static T GetValue<T>(ILinkedList<T> linkedList,int valueOfCompare) where T : IComparable<T>
        {
            T value = linkedList[0];

            for (int i = 0; i < linkedList.Count; i++)
                if (linkedList[i].CompareTo(value) == valueOfCompare)
                    value = linkedList[i];


            return value;
        }

        public static int IndexOf<T>(this ILinkedList<T> linkedList,T value) where T : IComparable<T>
        {
            int indexOfElement = -1;

            for (int i = 0; i < linkedList.Count && (indexOfElement == -1); i++)
                if (linkedList[i].CompareTo(value) == 0)
                    indexOfElement = i;

            return indexOfElement;
        }

        public static int LastIndexOf<T>(this ILinkedList<T> linkedList,T value) where T : IComparable<T>
        {
            int indexOfElement = -1;

            for (int i = 0; i < linkedList.Count; i++)
                if (linkedList[i].CompareTo(value) == 0)
                    indexOfElement = i;

            return indexOfElement;
        }

        public static void DeleteAllBeforeVal<T>(this ILinkedList<T> linkedList,T value = default(T))
        {
            if (!linkedList.Contains(value))
                return;

            while (!linkedList[0].Equals(value))
                linkedList.Remove(0);
        }

    }
}
