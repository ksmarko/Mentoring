using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public interface ILinkedList<T> : IEnumerator<T>, IEnumerable<T>
    {
        bool InsertAfter(T item, T data);
        bool InsertBefore(T item, T data);
        void AddFirts(T item);
        void AddLast(T item);
        bool AddAt(int index, T item);
        bool Remove(T item);
        bool RemoveAt(int index);
        T ElementAt(int index);
        void Clear();

        int Length { get; }
    }
}
