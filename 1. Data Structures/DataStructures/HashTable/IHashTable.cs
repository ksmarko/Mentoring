namespace DataStructures.HashTable
{
    interface IHashTable<TKey, TValue>
    {
        bool Contains(TKey key);
        void Add(TKey key, TValue value);
        TValue this[TKey key] { get; set; }
        bool TryGet(TKey key, out TValue value);
    }
}
