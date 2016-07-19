using System;
using DM.Collections;
using System.Text;

namespace DM.Collections
{
    public delegate List<T> CreateAndPopulateList<T>();

    public class VirtualList<T> : List<T>
    {
        private List<T> list;
        private CreateAndPopulateList<T> populateMethod;

        public VirtualList(CreateAndPopulateList<T> populateMethod)
        {
            this.populateMethod = populateMethod;    
        }

        public override int IndexOf(T item)
        {
            EnsureListLoaded();

            return list.IndexOf(item);
        }
             

        public override void Insert(int index, T item)
        {
            EnsureListLoaded();

            list.Insert(index, item);
        }

        public override void RemoveAt(int index)
        {
            EnsureListLoaded();

            list.RemoveAt(index);
        }

        public override T this[int index]
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

        public override void Add(T item)
        {
            EnsureListLoaded();

            list.Add(item);
        }

        public override void Clear()
        {
            EnsureListLoaded();

            list.Clear();
        }

        public override bool Contains(T item)
        {
            EnsureListLoaded();

            return list.Contains(item);

        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            EnsureListLoaded();

            list.CopyTo(array, arrayIndex);
        }

        public override int Count
        {
            get
            {
                EnsureListLoaded();

                return list.Count;
            }
        }

        public override bool Remove(T item)
        {
            EnsureListLoaded();

            return list.Remove(item);
        }

        public override System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
           EnsureListLoaded();

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
