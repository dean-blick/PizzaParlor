using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// An interface to build all of the possible menu items
    /// </summary>
    public interface IMenuItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the name of the menu item
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Stores the description of the menu item
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Stores the price of the menu item
        /// </summary>
        public decimal Price {  get; }
        /// <summary>
        /// Stores the calories per each of this item
        /// </summary>
        public uint CaloriesPerEach { get; }
        /// <summary>
        /// Stores the total calories for the entire menu item object
        /// </summary>
        public uint CaloriesTotal { get; }
        /// <summary>
        /// Stores the special instructions for the menu item
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; }




    }
}
