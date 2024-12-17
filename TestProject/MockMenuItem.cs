using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Mock menu item for testing
    /// </summary>
    public class MockMenuItem : IMenuItem
    {
        /// <summary>
        /// Assignable name
        /// </summary>
        public string Name { get; set; } = "test item";
        /// <summary>
        /// Assignable description
        /// </summary>
        public string Description { get; set; } = "test item description";
        /// <summary>
        /// Assignable price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Assignable caloriespereach
        /// </summary>
        public uint CaloriesPerEach { get; set; }
        /// <summary>
        /// Assignable caloriestotal
        /// </summary>
        public uint CaloriesTotal { get; set; }
        /// <summary>
        /// Assignable specialinstructions
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; set; } = Enumerable.Empty<string>();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
