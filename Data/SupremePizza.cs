using System.Drawing;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The definition of the SupremePizza class
    /// </summary>
    public class SupremePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public override string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public override string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// The price of this SupremePizza instance
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal total = 13.99m;
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
        /// A constructor that creates a supreme pizza and sets the proper toppings
        /// </summary>
        public SupremePizza() : base()
        {
            PossibleToppings.Clear();
            Topping[] t = { Topping.Sausage, Topping.Pepperoni, Topping.Olives, Topping.Onions, Topping.Mushrooms, Topping.Peppers };
            foreach (Topping tops in t)
            {
                PizzaTopping pt = new PizzaTopping(tops, true);
                PossibleToppings.Add(pt);
                pt.PropertyChanged += OnToppingPropertyChange;
            }
        }
    }
}