using System;

namespace GPK.FirstLab.Additional
{
    public interface ILinkedList<T>
    {
        void Add(T value);
        void Remove(int index);
        void View(ILinkedListViewer<T> linkedListViewer);
        int Count { get; }
        T this[int index] { get; }
        bool Contains(T value);
        void SortByAscending();
        void SortByDescending();
    }
}
