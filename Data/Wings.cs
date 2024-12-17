using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Class for the wings item
    /// </summary>
    public class Wings : Side
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public override string Name { get; } = "Wings";

        /// <summary>
        /// The description of the item
        /// </summary>
        public override string Description { get; } = "Chicken wings tossed in sauce";

        /// <summary>
        /// Private container for the count property
        /// </summary>
        private uint _count = 5;

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
        /// Private backing field for the BoneIn property
        /// </summary>
        private bool _boneIn = true;

        /// <summary>
        /// Stores if the wings are bone in or not
        /// </summary>
        public bool BoneIn
        {
            get
            {
                return _boneIn;
            }
            set
            {
                _boneIn = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(BoneIn));
            }
        }

        /// <summary>
        /// Private backing field for the Sauce property
        /// </summary>
        private WingSauce _sauce = WingSauce.Medium;

        /// <summary>
        /// Contains the sauce for the wings
        /// </summary>
        public WingSauce Sauce
        {
            get => _sauce;
            set
            {
                _sauce = value;
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
                OnPropertyChanged(nameof(Sauce));
            }
        }

        /// <summary>
        /// Gives the total price of the wings
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (BoneIn) return 1.50m * SideCount;
                else return 1.75m * SideCount;
            }
        }

        /// <summary>
        /// Calculates the calories per each wing
        /// </summary>
        public override uint CaloriesPerEach
        {
            get
            {
                uint total = 125;
                if (!BoneIn) total += 50;
                if (Sauce == WingSauce.HoneyBBQ) total += 20;
                return total;
            }
        }


        /// <summary>
        /// Returns an enumerator with special instructions
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> values= new List<string>();
                if (BoneIn) values.Add($"{SideCount} Bone-In Wings");
                else values.Add($"{SideCount} Boneless Wings");
                values.Add($"{Sauce}");
                return values;
            }
        }
    }
}
