using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The class for the veggie pizza
    /// </summary>
    public class VeggiePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// Name of the pizza
        /// </summary>
        public override string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// Description of the pizza
        /// </summary>
        public override string Description { get; } = "All the veggies";

        /// <summary>
        /// Price of the pizza
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal total = 12.99m;
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
        /// A constructor that creates a veggie pizza with the proper toppings
        /// </summary>
        public VeggiePizza() : base()
        {
            PossibleToppings.Clear();
            Topping[] t = { Topping.Olives, Topping.Onions, Topping.Mushrooms, Topping.Peppers };
            foreach (Topping tops in t)
            {
                PizzaTopping pt = new PizzaTopping(tops, true);
                PossibleToppings.Add(pt);
                pt.PropertyChanged += OnToppingPropertyChange;
            }
        }
    }
}
