using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
   public struct OrderItem
    {
        private string productCode;
        private int quantity;
        private decimal unitCost;
        private decimal unitWeight;

        public OrderItem(string productCode , int quantity , decimal unitCost , decimal unitWeight)
        {
            this.productCode = productCode;
            this.quantity = quantity;
            this.unitCost = unitCost;
            this.unitWeight = unitWeight;
        }

        public string ProductCode { get { return productCode; } }
        public int Quantity { get { return quantity; } }
        public decimal UnitCost { get { return unitCost; } }
        public decimal Cost { get { return unitCost * quantity; } }

        public decimal UnitWeight { get { return unitWeight; } }
        public decimal Weight { get { return unitWeight * quantity; } }

        
    }

    public abstract class Order
    {
        public abstract void AddItem(string productCode, int quantity, decimal cost, decimal weight);

        public abstract void PrintOrderItems();
        public abstract IEnumerable<OrderItem> Items { get; }
            
        public abstract decimal TotalCost { get; }
      
    }
}
