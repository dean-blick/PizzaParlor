using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Meats Pizza
    /// </summary>
    public class MeatsPizza : Pizza, IMenuItem
    {
        /// <summary>
        /// Name of the pizza
        /// </summary>
        public override string Name { get; } = "Meats Pizza";

        /// <summary>
        /// Description of the pizza
        /// </summary>
        public override string Description { get; } = "All the meats";

        /// <summary>
        /// Price of the pizza
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal total = 15.99m;
                if (PizzaSize == Size.Small) total -= 2;
                if (PizzaSize == Size.Large) total += 2;
                if (PizzaCrust == Crust.DeepDish) total += 1;
                return total;
            }
        }

        /// <summary>
        /// returns the special instructions for this pizza
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                switch (PizzaSize)
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
                switch (PizzaCrust)
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
                return instructions;
            }
        }

        /// <summary>
        /// A constructor for the meats pizza that sets the proper toppings
        /// </summary>
        public MeatsPizza() : base()
        {
            PossibleToppings.Clear();
            Topping[] t = { Topping.Sausage, Topping.Pepperoni, Topping.Ham, Topping.Bacon };
            foreach (Topping tops in t)
            {
                PizzaTopping pt = new PizzaTopping(tops, true);
                PossibleToppings.Add(pt);
                pt.PropertyChanged += OnToppingPropertyChange;
            }
        }
    }
}
