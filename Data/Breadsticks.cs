using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Class for the breadsticks item
    /// </summary>
    public class Breadsticks : Side
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Breadsticks";

        /// <summary>
        /// Description of the item
        /// </summary>
        public override string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// Private container for the count property
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// Stores the number of items in the side
        /// </summary>
        public override uint SideCount
        {
            get { return _count; }
            set
            {
                if (value >= 4 && value <= 12) _count = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(SideCount));
                OnPropertyChanged(nameof(CaloriesTotal));
            }
        }

        /// <summary>
        /// Private backing field for the Cheese property
        /// </summary>
        private bool _cheese = false;

        /// <summary>
        /// Stores if the breadsticks have cheese
        /// </summary>
        public bool Cheese
        {
            get
            {
                return _cheese;
            }
            set
            {
                _cheese = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Cheese));
            }
        }

        /// <summary>
        /// Calculates the price of the breadsticks
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 0;
                if (Cheese) cost = SideCount * 1.00m;
                else cost = SideCount * 0.75m;
                return cost;
            }
        }

        /// <summary>
        /// Calculates calories per breadstick
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                if (Cheese) return 200;
                else return 150;
            }
        }

        /// <summary>
        /// returns a list of instructions
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Cheese) instructions.Add($"{SideCount} Cheesesticks");
                else instructions.Add($"{SideCount} Breadsticks");
                return instructions;
            }
        }
    }
}
