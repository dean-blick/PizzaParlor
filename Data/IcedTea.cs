using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The class for the IcedTea Item
    /// </summary>
    public class IcedTea : Drink
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Iced Tea";

        /// <summary>
        /// The description of the item
        /// </summary>
        public override string Description { get; } = "Freshly brewed sweet tea";
    
        /// <summary>
        /// Gives the price of the drink
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (DrinkSize == Size.Small) { return 2.00m; }
                if (DrinkSize == Size.Medium) { return 2.50m; }
                return 3.00m;
            }
        }

        /// <summary>
        /// Calculates the calories per each item
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                if (DrinkSize == Size.Small) { return 175; }
                if (DrinkSize == Size.Medium) { return 220; }
                return 275;
            }
        }

        /// <summary>
        /// Calculates the total calories
        /// </summary>
        public override uint CaloriesTotal
        {
            get
            {
                if (DrinkSize == Size.Small) { return 175; }
                if (DrinkSize == Size.Medium) { return 220; }
                return 275;
            }
        }

        /// <summary>
        /// Returns an enumerator with special instructions
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> values = new List<string>();
                if (DrinkSize == Size.Small) values.Add("Small");
                else if (DrinkSize == Size.Medium) values.Add("Medium");
                else values.Add("Large");
                if (!Ice) values.Add($"Hold Ice");
                return values;
            }
        }
    }
}
