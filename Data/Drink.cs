using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// An abstract class for the drink menu items
    /// </summary>
    public abstract class Drink : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Private backing field for the ice variable
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// Stores if the drink has ice or not
        /// </summary>
        public bool Ice
        {
            get { return _ice; }
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Ice));
            }
        }

        /// <summary>
        /// private backing field for the DrinkSize property
        /// </summary>
        private Size _drinkSize = Size.Medium;

        /// <summary>
        /// Contains the size of the drink
        /// </summary>
        public Size DrinkSize
        {
            get => _drinkSize;
            set
            {
                _drinkSize = value;
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(DrinkSize));
            }
        }

        /// <summary>
        /// The price of the drink
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// The calories per each drink
        /// </summary>
        public abstract uint CaloriesPerEach { get; }

        /// <summary>
        /// The total calories per each drink
        /// </summary>
        public abstract uint CaloriesTotal { get; }

        /// <summary>
        /// The special instructions for the drink
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

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
