using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadatak2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        private int _size;

        public GenericList() : this(4)
        {
        }

        public GenericList(int initialSize)
        {
            Count = 0;
            _size = initialSize;
            _internalStorage = new X[initialSize];
        }

        public void Add(X item)
        {
            if (Count == _size)
            {
                _size *= 2;

                var tempArray = new X[_size];
                _internalStorage.CopyTo(tempArray, 0);
                _internalStorage = tempArray;
            }

            _internalStorage[Count++] = item;
        }

        public bool Remove(X item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _internalStorage.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index > Count)
            {
                return false;
            }

            for (var i = index; i < Count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            Count--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count { get; private set; }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(X item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
