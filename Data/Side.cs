using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Abstract class for side items
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the side
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the side
        /// </summary>
        public abstract string Description {  get; }

        /// <summary>
        /// Gets the price of the item
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Gets the calories per each of the item
        /// </summary>
        public abstract uint CaloriesPerEach { get; }

        /// <summary>
        /// Stores the count for the side
        /// </summary>
        public abstract uint SideCount { get; set; }

        /// <summary>
        /// Calculates the total calories
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return CaloriesPerEach * SideCount;
            }
        }

        /// <summary>
        /// Gets the special instructions for the item
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions {  get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Helper class for inherited classes to invoke PropertyChanged event
        /// </summary>
        /// <param name="propertyName">name of the property to invoke</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns the name of the menu item
        /// </summary>
        /// <returns>a string giving the name</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
