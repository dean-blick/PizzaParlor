using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// The class for the cinnamonsticks menu item
    /// </summary>
    public class CinnamonSticks : Side
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// Description of the item
        /// </summary>
        public override string Description { get; } = "Like breadsticks but for dessert";

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
        /// Private backing field for the frosting property
        /// </summary>
        private bool _frosting = true;

        /// <summary>
        /// Stores if the cinnamon sticks have frosting
        /// </summary>
        public bool Frosting
        {
            get
            {
                return _frosting;
            }
            set
            {
                _frosting = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Frosting));
            }
        }

        /// <summary>
        /// Calculates the price of the cinnamon sticks
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal cost = 0;
                if (Frosting) cost = SideCount * 0.90m;
                else cost = SideCount * 0.75m;
                return cost;
            }
        }

        /// <summary>
        /// Calculates calories per cinnamon stick
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                if (Frosting) return 190;
                else return 160;
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
                instructions.Add($"{SideCount} Cinnamon Sticks");
                if (!Frosting) instructions.Add("Hold Frosting");
                return instructions;
            }
        }
    }
}
