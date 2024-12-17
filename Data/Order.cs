using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class to create and store orders
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// CollectionChanged event
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// PropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handles when the property of an item in the order changes
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">propertychangedeventargs object</param>
        private void HandleItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
        }

        /// <summary>
        /// The list that stores all of the menu items in the order (collection)
        /// </summary>
        public List<IMenuItem> menuItems = new List<IMenuItem>();

        /// <summary>
        /// Returns the number of items in the order (collection)
        /// </summary>
        public int Count { get { return menuItems.Count; } }

        /// <summary>
        /// Returns if the collection is read only
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Adds the given menu item to the order (collection)
        /// </summary>
        /// <param name="item">the menu item to add</param>
        public void Add(IMenuItem item)
        {
            menuItems.Add(item);
            item.PropertyChanged += HandleItemPropertyChanged;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        /// <summary>
        /// Clears the order/collection
        /// </summary>
        public void Clear()
        {
            menuItems = new List<IMenuItem>();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Returns bool if the menu item is on the order
        /// </summary>
        /// <param name="item">the item to check for</param>
        /// <returns>a bool if the item is on the order or not</returns>
        public bool Contains(IMenuItem item)
        {
            return menuItems.Contains(item);
        }

        /// <summary>
        /// Copies the order to the given array at the given index
        /// </summary>
        /// <param name="array">the array to copy into</param>
        /// <param name="arrayIndex">the index to start at</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            menuItems.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Enumerates through the menu items
        /// </summary>
        /// <returns>an enumerator giving the menu items </returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            foreach (IMenuItem item in menuItems) { yield return item; }
        }

        /// <summary>
        /// Removes the item from the collection
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>a bool if the item was removed</returns>
        public bool Remove(IMenuItem item)
        {
            int index = menuItems.IndexOf(item);
            if (index > -1)
            {
                menuItems.Remove(item);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));

                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Old version of enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Totals all of the prices of the items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal p = 0;
                foreach (IMenuItem item in this)
                {
                    p += item.Price;
                }
                return p;
            }
        }

        /// <summary>
        /// private backing field for TaxRate property
        /// </summary>
        private decimal _taxRate = 0.0915m;

        /// <summary>
        /// The tax rate for the order
        /// </summary>
        public decimal TaxRate
        {
            get
            {
                return _taxRate;
            }
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
            }
        }

        /// <summary>
        /// Finds the tax amount to add to the order
        /// </summary>
        public decimal Tax
        {
            get
            {
                return Subtotal * TaxRate;
            }
        }

        /// <summary>
        /// Returns the total price for the order
        /// </summary>
        public decimal Total
        {
            get
            {
                return Subtotal + Tax;
            }
        }

        /// <summary>
        /// The number for the order
        /// </summary>
        public static int Number { get; set; } = 0;

        /// <summary>
        /// The date and time the order was placed
        /// </summary>
        public DateTime PlacedAt { get; init; }

        /// <summary>
        /// Makes a new order
        /// </summary>
        public Order()
        {
            PlacedAt = DateTime.Now;
            Number++;
        }

    }
}
