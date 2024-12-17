using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Class for Garlic Knots
    /// </summary>
    public class GarlicKnots : Side
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Garlic Knots";

        /// <summary>
        /// Description of the item
        /// </summary>
        public override string Description { get; } = "Twisted rolls with garlic and butter";

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
        /// Calculates the price of the Garlic Knots
        /// </summary>
        public override decimal Price
        {
            get
            {
                return 0.75m * SideCount;
            }
        }

        /// <summary>
        /// Calculates calories per Garlic Knot
        /// </summary>
        public override uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// returns a list of instructions
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                instructions.Add($"{SideCount} Garlic Knots");
                return instructions;
            }
        }
    }
}
