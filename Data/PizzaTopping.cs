using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class to store a pizza topping
    /// </summary>
    public class PizzaTopping : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the type of this topping
        /// </summary>
        public Topping ToppingType { get; init; }
        /// <summary>
        /// Private backing field for the OnPizza property
        /// </summary>
        private bool _onPizza = true;
        /// <summary>
        /// A bool to store if the topping is on the pizza
        /// </summary>
        public bool OnPizza
        {
            get
            {
                return _onPizza;
            }
            set
            {
                _onPizza = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnPizza)));
            }
        }
        
        /// <summary>
        /// returns the name of the topping
        /// </summary>
        public string Name
        {
            get
            {
                switch (ToppingType)
                {
                    case Topping.Sausage:
                        return "Sausage";
                    case Topping.Pepperoni:
                        return "Pepperoni";
                    case Topping.Ham:
                        return "Ham";
                    case Topping.Bacon:
                        return "Bacon";
                    case Topping.Olives:
                        return "Olives";
                    case Topping.Onions:
                        return "Onions";
                    case Topping.Mushrooms:
                        return "Mushrooms";
                    case Topping.Peppers:
                        return "Peppers";
                    case Topping.Pineapple:
                        return "Pineapple";
                    default:
                        return "Topping Error";
                }
            }
        }

        /// <summary>
        /// returns the base calories for the topping
        /// </summary>
        public uint BaseCalories
        {
            get
            {
                if (ToppingType == Topping.Sausage) return 30;
                else if ((ToppingType == Topping.Pepperoni) || (ToppingType == Topping.Ham) || (ToppingType == Topping.Bacon)) return 20;
                return 5;
            }
        }

        /// <summary>
        /// PizzaTopping constructor
        /// </summary>
        /// <param name="toppingType">the kind of topping from the Topping enum</param>
        /// <param name="onPizza">a bool if the topping is on the pizza</param>
        public PizzaTopping(Topping toppingType, bool onPizza)
        {
            ToppingType = toppingType;
            OnPizza = onPizza;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
