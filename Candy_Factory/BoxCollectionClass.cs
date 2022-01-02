using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Candy_Factory
{ 
    class BoxCollection<T> : ICollection<T> where T: Box
    {
        public delegate void BoxAdded(string mes);
        public event BoxAdded Added;

        private List<T> _items;

        public BoxCollection()
        {
            _items = new List<T>();
        }
        public T this[int index]
        {
            get { return (T)_items[index]; }
            set { _items[index] = value; }
        }

        protected BoxCollection(List<T> collection)
        {
            _items = collection;
        }

        public void Add(T item)
        {
            _items.Add(item);
            Added?.Invoke("Коробка добавлена в заказ");
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void Sort (Func<Box, Box, bool> func)
        {
            var len = this.Count;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (func(this[j],this[j + 1]))
                    {
                        var temp = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = temp;
                    }
                }
            }
        }
    }

}
