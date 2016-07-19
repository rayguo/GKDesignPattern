using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Collections
{
    /// <summary>
    /// Adapter class, make use of the framework supplied list whilst
    /// making it part of a a DM.Collections type hierarchy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FrameworkList<T> : List<T>
    {
        private global::System.Collections.Generic.List<T> list;

        public FrameworkList()
        {
            list = new System.Collections.Generic.List<T>();
        }

        public override int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public override void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public override void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public override T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public override void Add(T item)
        {
            list.Add(item);
        }

        public override void Clear()
        {
            list.Clear();
        }

        public override bool Contains(T item)
        {
            return list.Contains(item);
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public override int Count
        {
            get { return list.Count; }
        }

       
        public override bool Remove(T item)
        {
            return list.Remove(item);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
