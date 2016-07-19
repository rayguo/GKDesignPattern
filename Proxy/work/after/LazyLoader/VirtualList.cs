using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LazyLoader
{
    public delegate IList<T> CreateAndPopulateList<T>();

    public class VirtualList<T> : IList<T>
    {
        private IList<T> list;
        private CreateAndPopulateList<T> populateMethod;

        public VirtualList(CreateAndPopulateList<T> populateMethod)
        {
            this.populateMethod = populateMethod;    
        }

        public  int IndexOf(T item)
        {
            EnsureListLoaded();

            return list.IndexOf(item);
        }
             

        public  void Insert(int index, T item)
        {
            EnsureListLoaded();

            list.Insert(index, item);
        }

        public  void RemoveAt(int index)
        {
            EnsureListLoaded();

            list.RemoveAt(index);
        }

        public  T this[int index]
        {
            get
            {
                EnsureListLoaded();

                return list[index];
            }
            set
            {
                EnsureListLoaded();

                list[index] = value;
            }
        }

        public  void Add(T item)
        {
            EnsureListLoaded();

            list.Add(item);
        }

        public  void Clear()
        {
            EnsureListLoaded();

            list.Clear();
        }

        public  bool Contains(T item)
        {
            EnsureListLoaded();

            return list.Contains(item);

        }

        public  void CopyTo(T[] array, int arrayIndex)
        {
            EnsureListLoaded();

            list.CopyTo(array, arrayIndex);
        }

        public  int Count
        {
            get
            {
                EnsureListLoaded();

                return list.Count;
            }
        }

        public  bool Remove(T item)
        {
            EnsureListLoaded();

            return list.Remove(item);
        }

        public bool IsReadOnly
        {
            get
            {
                EnsureListLoaded();

                return list.IsReadOnly;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            EnsureListLoaded();

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }


        private void EnsureListLoaded()
        {
            if (list == null)
            {
                list = populateMethod();
            }
        }

        
    }
}
