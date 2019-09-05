using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Length { get; private set; }

        public bool AddAt(int index, T item)
        {
            if (IsEmpty() && index == 0)
            {
                AddLast(item);
                return true;
            }

            if (index >= 0 && index < Length && !IsEmpty())
            {
                if (index == 0)
                {
                    AddFirts(item);
                }
                else
                {
                    var node = new Node<T>(item);
                    var current = _head;
                    Node<T> previous = null;
                    var currentIndex = 0;

                    while (currentIndex < index)
                    {
                        previous = current;
                        current = current.Next;
                        currentIndex++;
                    }

                    node.Next = current;
                    current.Previous = node;
                    previous.Next = node;
                    node.Previous = previous;
                }

                Length++;
                return true;
            }

            return false;
        }

        private bool IsEmpty() => _head == null && _tail == null;

        public void AddFirts(T item)
        {
            var node = new Node<T>(item);

            if (IsEmpty())
            {
                _head = _tail = node;
            }
            else
            {
                node.Next = _head;
                _head.Previous = node;
                _head = node;
            }

            Length++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            if (IsEmpty())
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }

            Length++;
        }

        public void Clear()
        {
            _head = _tail = null;
            Length = 0;
        }

        public T ElementAt(int index)
        {
            if (index >= 0 && index < Length && !IsEmpty())
            {
                if (index == 0)
                    return _head.Data;
                else
                {
                    var current = _head;
                    Node<T> previous = null;
                    var currentIndex = 0;

                    while (currentIndex < index)
                    {
                        previous = current;
                        current = current.Next;
                        currentIndex++;
                    }

                    return current.Data;
                }
            }

            throw new IndexOutOfRangeException();
        }

        public bool InsertAfter(T item, T data)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    var node = new Node<T>(data);

                    node.Next = current.Next;
                    current.Next.Previous = node;
                    current.Next = node;
                    node.Previous = current;

                    Length++;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool InsertBefore(T item, T data)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    var node = new Node<T>(data);

                    current.Previous.Next = node;
                    node.Previous = current.Previous;
                    node.Next = current;
                    current.Previous = node;

                    Length++;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        current.Previous = previous;

                        if (current.Next == null)
                            _tail = previous;
                    }
                    else
                    {
                        _head = _head.Next;

                        if (_head == null)
                            _tail = null;
                    }

                    Length--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Length && !IsEmpty())
            {
                if (index == 0)
                    _head = _head.Next;
                else
                {
                    var current = _head;
                    Node<T> previous = null;
                    var currentIndex = 0;

                    while (currentIndex < index)
                    {
                        previous = current;
                        current = current.Next;
                        currentIndex++;
                    }

                    previous.Next = current.Next;
                    current.Next.Previous = previous;
                }

                Length--;
                return true;
            }

            return false;
        }

        #region Enumerator
        int pointer = -1;
        public T Current
        {
            get
            {
                if (pointer != -1)
                    return ElementAt(pointer);
                else
                    throw new InvalidOperationException();
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (pointer < Length - 1)
            {
                pointer++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            pointer = -1;
        }

        public void Dispose()
        {
            Reset();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        class Node<T>
        {
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public T Data { get; }

            public Node(T data)
            {
                Data = data;
            }

            public bool HasNext() => Next != null;

            public bool HasPrevious() => Previous != null;
        }
    }
}
