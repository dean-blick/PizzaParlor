using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The general pizza class
    /// </summary>
    public class Pizza : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the pizza
        /// </summary>
        public virtual string Name { get; } = "Build-Your-Own-Pizza";
        /// <summary>
        /// The description of the pizza
        /// </summary>
        public virtual string Description { get; } = "A pizza you get to build";
        /// <summary>
        /// The number of slices the pizza has
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// Private backing field for the PizzaSize property
        /// </summary>
        private Size _pizzaSize = Size.Medium;

        /// <summary>
        /// The size of the pizza
        /// </summary>
        public Size PizzaSize
        {
            get { return _pizzaSize; }
            set
            {
                _pizzaSize = value;
                OnPropertyChanged(nameof(PizzaSize));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Private backing field for the PizzaCrust property
        /// </summary>
        private Crust _pizzaCrust = Crust.Original;
        
        /// <summary>
        /// The crust of the pizza
        /// </summary>
        public Crust PizzaCrust
        {
            get => _pizzaCrust;
            set
            {
                _pizzaCrust = value;
                OnPropertyChanged(nameof(PizzaCrust));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }
        /// <summary>
        /// Lists the possible toppings on the pizza
        /// </summary>
        public List<PizzaTopping> PossibleToppings { get; } = new List<PizzaTopping>();

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Helper class for inherited classes to invoke PropertyChanged event
        /// </summary>
        /// <param name="propertyName">name of the property to invoke</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// returns the price of the pizza
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                decimal p = 9.99m;
                if (PizzaSize == Size.Small) p -= 2;
                if (PizzaSize == Size.Large) p += 2;
                if (PizzaCrust == Crust.DeepDish) p += 1;
                foreach (PizzaTopping topping in PossibleToppings)
                {
                    if (topping.OnPizza == true) p += 1;
                }
                return p;
            }
        }


        /// <summary>
        /// returns the calories per each slice of pizza
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                decimal cals = 250;
                if (PizzaCrust == Crust.Thin) cals -= 100;
                if (PizzaCrust == Crust.DeepDish) cals += 50;
                foreach (PizzaTopping topping in PossibleToppings)
                {
                    if(topping.OnPizza) cals += topping.BaseCalories;
                }
                if (PizzaSize == Size.Small) cals *= .75m;
                if (PizzaSize == Size.Large) cals *= 1.3m;
                return (uint)cals;
            }
        }

        /// <summary>
        /// Returns total calories for the pizza
        /// </summary>
        public uint CaloriesTotal
        {
            get
            {
                return Slices * CaloriesPerEach;
            }
        }
        /// <summary>
        /// returns the special instructions for this pizza
        /// </summary>
        public virtual IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                switch(PizzaSize)
                {
                    case Size.Small:
                        instructions.Add("Small");
                        break;
                    case Size.Medium:
                        instructions.Add("Medium");
                        break;
                    case Size.Large:
                        instructions.Add("Large");
                        break;
                }
                switch(PizzaCrust)
                {
                    case Crust.Thin:
                        instructions.Add("Thin Crust");
                        break;
                    case Crust.DeepDish:
                        instructions.Add("Deep Dish");
                        break;
                    case Crust.Original:
                        instructions.Add("Original Crust");
                        break;
                }
                foreach (PizzaTopping topping in PossibleToppings)
                {
                    if(topping.OnPizza) instructions.Add(topping.Name);
                }
                return instructions;
            }
        }

        public Pizza()
        {

            Topping[] t = { Topping.Sausage, Topping.Pepperoni, Topping.Ham, Topping.Bacon, Topping.Olives, Topping.Onions, Topping.Mushrooms, Topping.Peppers, Topping.Pineapple };
            foreach (Topping tops in t)
            {
                PizzaTopping pt = new PizzaTopping(tops, false);
                PossibleToppings.Add(pt);
                pt.PropertyChanged += OnToppingPropertyChange;
            }
        }

        /// <summary>
        /// Returns if the given topping is on the pizza or not
        /// </summary>
        /// <param name="t">the topping to check for</param>
        /// <returns>a bool if the topping is on the pizza</returns>
        public bool HasTopping(Topping t)
        {
            foreach (PizzaTopping top in PossibleToppings)
            {
                if (top.ToppingType == t) return top.OnPizza;
            }
            return false;
        }

        /// <summary>
        /// Finds and sets the given topping value to the given bool
        /// </summary>
        /// <param name="t">the topping to set on the pizza</param>
        /// <param name="b">the bool to set the topping to</param>
        public void SetTopping(Topping t, bool b)
        {
            foreach (PizzaTopping top in PossibleToppings)
            {
                if (top.ToppingType == t) top.OnPizza = b;
            }
        }

        /// <summary>
        /// Returns the name of the menu item
        /// </summary>
        /// <returns>a string giving the name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Handles topping property changes
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the propertychangedeventargs</param>
        protected virtual void OnToppingPropertyChange(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CaloriesPerEach)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CaloriesTotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
        }
    }
}
