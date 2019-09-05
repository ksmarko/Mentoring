using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.HashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>, IEnumerable
    {
        private const int DafaultSize = 3;
        private const float MaxLoadFactor = 0.72f;

        private int _hashLoad;
        private HashTableNode<TKey, TValue>[] _items;
        private bool IsResizeNeeded => (float)_hashLoad / Size > MaxLoadFactor;

        public int Size { get; private set; }
        public int Count { get; private set; }
        
        public HashTable() : this(DafaultSize) { }

        public HashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number");

            _items = new HashTableNode<TKey, TValue>[size];
            Size = size;
            Count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!Contains(key))
                    throw new ArgumentException();

                int position = GetArrayPosition(key);

                return _items[position].Value;
            }
            set
            {
                if (!Contains(key))
                    throw new ArgumentException();

                int position = GetArrayPosition(key);

                if (value == null)
                {
                    _items[position] = null;
                }
                else
                {
                    _items[position] = new HashTableNode<TKey, TValue>(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (Contains(key))
                throw new ArgumentException();

            int position = GetArrayPosition(key);

            _items[position] = new HashTableNode<TKey, TValue>(key, value);
            _hashLoad++;
            Count++;

            if (IsResizeNeeded)
            {
                Resize();
            }
        }

        public bool Contains(TKey key)
        {
            int position = GetArrayPosition(key);
            return _items[position] != null;
        }

        public bool TryGet(TKey key, out TValue value)
        {
            int position = GetArrayPosition(key);

            if (!Contains(key))
            {
                value = default(TValue);
                return false;
            }

            value = _items[position].Value;
            return true;
        }

        public void Remove(TKey key)
        {
            if (!Contains(key))
                throw new ArgumentException();

            int position = GetArrayPosition(key);

            _items[position] = null;
            Count--;
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        private void Resize()
        {
            Size *= 2;
            var temp = new HashTableNode<TKey, TValue>[Size];

            foreach (var el in _items)
            {
                var index = GetArrayPosition(el.Key);
                temp[index] = new HashTableNode<TKey, TValue>(el.Key, el.Value);
            }

            _items = temp;
        }

        public void Clear()
        {
            Count = 0;

            for (int i = 0; i < Size; i++)
            {
                _items[i] = null;
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            var index = 0;

            while (index < Size)
            {
                var item = _items[index++];

                if (item != null)
                    yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        class HashTableNode<TKey, TValue>
        {
            public HashTableNode(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }
            public TValue Value { get; }
        }
    }
}
