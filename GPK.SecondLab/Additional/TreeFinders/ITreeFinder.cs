using GPK.FirstLab.Additional;
using System;

namespace GPK.SecondLab.Additional.TreeFinders
{
    public interface ITreeFinder<T>
        where T : IComparable<T>,new()
    {
        ILinkedList<T> FindLongestRightBranch();
    }
}
