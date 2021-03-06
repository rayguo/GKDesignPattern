//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AcmeCorpEntities
{
    public partial class PurchaseOrder
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual decimal MaxValue
        {
            get;
            set;
        }
    
        public virtual int SupplierId
        {
            get { return _supplierId; }
            set
            {
                if (_supplierId != value)
                {
                    if (Supplier != null && Supplier.Id != value)
                    {
                        Supplier = null;
                    }
                    _supplierId = value;
                }
            }
        }
        private int _supplierId;
    
        public virtual string Status
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        private ICollection<PurchaseOrderLineItem> LineItems
        {
            get
            {
                if (_lineItems == null)
                {
                    var newCollection = new FixupCollection<PurchaseOrderLineItem>();
                    newCollection.CollectionChanged += FixupLineItems;
                    _lineItems = newCollection;
                }
                return _lineItems;
            }
            set
            {
                if (!ReferenceEquals(_lineItems, value))
                {
                    var previousValue = _lineItems as FixupCollection<PurchaseOrderLineItem>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLineItems;
                    }
                    _lineItems = value;
                    var newValue = value as FixupCollection<PurchaseOrderLineItem>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLineItems;
                    }
                }
            }
        }
        private ICollection<PurchaseOrderLineItem> _lineItems;
    
        public virtual Supplier Supplier
        {
            get { return _supplier; }
            set
            {
                if (!ReferenceEquals(_supplier, value))
                {
                    var previousValue = _supplier;
                    _supplier = value;
                    FixupSupplier(previousValue);
                }
            }
        }
        private Supplier _supplier;

        #endregion
        #region Association Fixup
    
        private void FixupSupplier(Supplier previousValue)
        {
            if (previousValue != null && previousValue.PurchaseOrders.Contains(this))
            {
                previousValue.PurchaseOrders.Remove(this);
            }
    
            if (Supplier != null)
            {
                if (!Supplier.PurchaseOrders.Contains(this))
                {
                    Supplier.PurchaseOrders.Add(this);
                }
                if (SupplierId != Supplier.Id)
                {
                    SupplierId = Supplier.Id;
                }
            }
        }
    
        private void FixupLineItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PurchaseOrderLineItem item in e.NewItems)
                {
                    item.PurchaseOrder = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PurchaseOrderLineItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.PurchaseOrder, this))
                    {
                        item.PurchaseOrder = null;
                    }
                }
            }
        }

        #endregion
    }
}
