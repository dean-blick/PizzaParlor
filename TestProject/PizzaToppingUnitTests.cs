using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Tests the PizzaTopping class
    /// </summary>
    public class PizzaToppingUnitTests
    {
        /// <summary>
        /// Verifies that changing the topping bools updates properties on pizzas
        /// </summary>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData("Price")]
        [InlineData("CaloriesPerEach")]
        [InlineData("CaloriesTotal")]
        [InlineData("SpecialInstructions")]
        public void SettingToppingBoolShouldNotifyPizzaPropertyChanges(string propertyName)
        {
            Order o = new Order();
            Pizza b = new Pizza();
            o.Add(b);
            Assert.PropertyChanged(b, propertyName, () => {
                b.SetTopping(Topping.Pepperoni, true);
            });
        }

        /// <summary>
        /// Verifies that changing the topping bools updates properties on pizzas
        /// </summary>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Tax")]
        [InlineData("Total")]
        public void SettingToppingBoolShouldNotifyOrderPropertyChanges(string propertyName)
        {
            Order o = new Order();
            Pizza b = new Pizza();
            o.Add(b);
            Assert.PropertyChanged(o, propertyName, () => {
                b.SetTopping(Topping.Pepperoni, true);
            });
        }

        /// <summary>
        /// Casting test for INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Pizza b = new Pizza();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(b);
        }
    }
}
