using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The class for the soda item
    /// </summary>
    public class Soda : Drink
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Soda";

        /// <summary>
        /// The description of the item
        /// </summary>
        public override string Description { get; } = "Standard fountain drink";

        /// <summary>
        /// Private backing field for the DrinkType property
        /// </summary>
        private SodaFlavor _drinkType = SodaFlavor.Coke;

        /// <summary>
        /// Stores the drink type
        /// </summary>
        public SodaFlavor DrinkType
        {
            get { return _drinkType; }
            set
            {
                _drinkType = value;
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(DrinkType));
                OnPropertyChanged(nameof(Price));
            }
        }

        /// <summary>
        /// Gives the price of the drink
        /// </summary>
        public override decimal Price
        {
            get
            {
                if(DrinkSize == Size.Small) { return 1.50m ; }
                if(DrinkSize == Size.Medium) { return 2.00m; }
                return 2.50m;
            }
        }

        /// <summary>
        /// Calculates the calories per each item
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                if(DrinkType == SodaFlavor.DietCoke) { return 0; }
                if (DrinkSize == Size.Small) { return 150; }
                if (DrinkSize == Size.Medium) { return 200; }
                return 250;
            }
        }

        /// <summary>
        /// Calculates the total calories
        /// </summary>
        public override uint CaloriesTotal
        {
            get
            {
                if (DrinkType == SodaFlavor.DietCoke) { return 0; }
                if (DrinkSize == Size.Small) { return 150; }
                if (DrinkSize == Size.Medium) { return 200; }
                return 250;
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
                switch (DrinkType)
                {
                    case SodaFlavor.DietCoke:
                        values.Add("Diet Coke");
                        break;
                    case SodaFlavor.Coke:
                        values.Add("Coke");
                        break;
                    case SodaFlavor.DrPepper:
                        values.Add("DrPepper");
                        break;
                    case SodaFlavor.Sprite:
                        values.Add("Sprite");
                        break;
                    case SodaFlavor.RootBeer:
                        values.Add("Root Beer");
                        break;
                }
                if (!Ice) values.Add($"Hold Ice");
                return values;
            }
        }
    }
}
