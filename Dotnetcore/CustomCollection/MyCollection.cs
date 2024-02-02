using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratingCustomCollection
{

    public class Item
    {
        public Item(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id;
        public string Name;
    }

    public class ItemCollection : IEnumerable
    {
        private Item[] _myList;
        public ItemCollection(Item[] pArray)
        {
            _myList = new Item[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _myList[i] = pArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ItemEnumerator(_myList);
        }

    }

    public class ItemEnumerator : IEnumerator
    {
        public Item[] list;
        int position = -1;

        public ItemEnumerator(Item[] _list)
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

        public Item Current
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
