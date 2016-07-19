using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM.Collections
{
    public enum Priority { High,Normal,Low};
    public class PriorityItem<T>
    {
        public T Item { get; private set; }
        public Priority Priority { get; private set; }

       public PriorityItem(T item, Priority priority)
        {
            Item = item;
            Priority = priority;
        }
    }
    public class PriorityQueue<T>
    {

       
        public int Count
        {
            get { return items.Count; }
        }

        private List<PriorityItem<T>> items = new List<PriorityItem<T>>();

        public void Enqueue(T p)
        {
            Enqueue(p, Priority.Normal);
        }

        public void Enqueue(T p,Priority priority)
        {
            items.Add(new PriorityItem<T>(p, priority));

        }

        public T Dequeue()
        {
            if (Count == 0) { throw new InvalidOperationException(); } 
            int? itemToReturnIndex = null; 
            int? firstNormalPriorityIndex = null;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Priority == Priority.High)
                {
                    itemToReturnIndex = i;
                    break;
                }
                if (firstNormalPriorityIndex == null && items[i].Priority == Priority.Normal)
                {
                    firstNormalPriorityIndex = i;
                }
            }

            if (itemToReturnIndex == null)
            {
                itemToReturnIndex = firstNormalPriorityIndex ?? 0;
            }
            PriorityItem<T> itemToReturn = items[(int)itemToReturnIndex];
            items.RemoveAt((int)itemToReturnIndex);
            
            return itemToReturn.Item;
        }
    }
}
