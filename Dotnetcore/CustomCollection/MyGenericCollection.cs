using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratingCustomCollection
{
    public class MyGenericCollection<T> : IEnumerable<T>
    {
        private T[] _myList;
        public MyGenericCollection(T[] pArray)
        {
            _myList = new T[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _myList[i] = pArray[i];
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("IEnumerator<T> GetEnumerator() -- generic return");
            return new MyGenericEnumerator<T>(_myList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("IEnumerator GetEnumerator()    -- non-generic return");
            return new MyGenericEnumerator<T>(_myList);
        }
    }

    public class MyGenericEnumerator<T> : IEnumerator<T>
    {
        public T[] list;
        int position = -1;

        public MyGenericEnumerator(T[] _list)
        {
            list = _list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }

        public T Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

    }
}
