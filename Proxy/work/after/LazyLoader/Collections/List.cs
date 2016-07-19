using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DM.Collections
{
    public abstract class List<T> : IList<T> ,  IEnumerable<T> , IEnumerable , ICollection<T> 
    {

        #region IList<T> Members

        public abstract int IndexOf(T item);
        public abstract void Insert(int index, T item);
        public abstract void RemoveAt(int index);


        public abstract T this[int index]
        {
            get;
            set;
        }

        #endregion

        #region ICollection<T> Members

        public abstract void Add(T item);
       
        public abstract void Clear();
     
        public abstract bool Contains(T item);

        public abstract void CopyTo(T[] array, int arrayIndex);
        

        public abstract int Count
        {
            get;
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        public abstract bool Remove(T item);
        
        #endregion

        #region IEnumerable<T> Members

        public abstract  IEnumerator<T> GetEnumerator();
       
        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        
    }
}
