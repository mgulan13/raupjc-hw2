using System.Collections;
using System.Collections.Generic;

namespace Zadatak2
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private int _index;
        private IGenericList<T> _genericList;

        public GenericListEnumerator(IGenericList<T> genericList)
        {
            _genericList = genericList;
            _index = -1;
        }


        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (++_index >= _genericList.Count)
            {
                return false;
            }

            Current = _genericList.GetElement(_index);
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;
    }
}
