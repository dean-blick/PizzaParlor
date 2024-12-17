using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Tests the pizza class
    /// </summary>
    public class PizzaUnitTests

    {
        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            Pizza p = new Pizza();
            Assert.Equal("Build-Your-Own-Pizza", p.Name);
            Assert.Equal("A pizza you get to build", p.Description);
            Assert.Equal(Size.Medium, p.PizzaSize);
            Assert.Equal(Crust.Original, p.PizzaCrust);
            Assert.Equal((uint)8, p.Slices);
            Assert.Equal(9, p.PossibleToppings.Count);
            foreach (PizzaTopping t in p.PossibleToppings)
            {
                Assert.False(t.OnPizza);
            }
        }


        /// <summary>
        /// Ensures correct pricing depending on size and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="toppings">a bool[] of toppings </param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, new bool[] { false, false, false, false, false, false, false, false, false }, 9.99)]
        [InlineData(Size.Small, Crust.Original, new bool[] { true, false, false, false, false, false, false, false, false }, 8.99)]
        [InlineData(Size.Large, Crust.Original, new bool[] { true, true, false, false, false, false, false, false, false }, 13.99)]
        [InlineData(Size.Small, Crust.DeepDish, new bool[] { true, true, true, false, false, false, false, false, false }, 11.99)]
        [InlineData(Size.Medium, Crust.DeepDish, new bool[] { true, false, true, false, true, false, true, false, true }, 15.99)]
        [InlineData(Size.Large, Crust.DeepDish, new bool[] { false, true, false, true, false, true, false, true, false }, 16.99)]
        [InlineData(Size.Medium, Crust.Thin, new bool[] { false, false, false, false, false, true, true, true, true }, 13.99)]
        [InlineData(Size.Large, Crust.Thin, new bool[] { true, true, true, true, true, true, true, true, true }, 20.99)]
        public void PriceTest(Size s, Crust c, bool[] toppings, decimal expected)
        {
            Pizza p = new Pizza();
            p.PizzaSize = s;
            p.PizzaCrust = c;
            p.SetTopping(Topping.Sausage, toppings[0]);
            p.SetTopping(Topping.Pepperoni, toppings[1]);
            p.SetTopping(Topping.Ham, toppings[2]);
            p.SetTopping(Topping.Bacon, toppings[3]);
            p.SetTopping(Topping.Olives, toppings[4]);
            p.SetTopping(Topping.Onions, toppings[5]);
            p.SetTopping(Topping.Mushrooms, toppings[6]);
            p.SetTopping(Topping.Peppers, toppings[7]);
            p.SetTopping(Topping.Pineapple, toppings[8]);
            Assert.Equal(expected, p.Price);
        }

        /// <summary>
        /// Ensures correct CaloriesPerEach value depending on size, toppings, and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="toppings">a bool[] of toppings </param>
        /// <param name="expected">the expected caloriespereach value</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, new bool[] { false, false, false, false, false, false, false, false, false }, 250)]
        [InlineData(Size.Small, Crust.Original, new bool[] { true, false, false, false, false, false, false, false, false }, (250 + 30) * .75)]
        [InlineData(Size.Large, Crust.Original, new bool[] { true, true, false, false, false, false, false, false, false }, (250 + 30 + 20) * 1.3)]
        [InlineData(Size.Small, Crust.DeepDish, new bool[] { true, true, true, false, false, false, false, false, false }, ((uint)(300 + 30 + 20 + 20) * .75) -.5)]
        [InlineData(Size.Medium, Crust.DeepDish, new bool[] { true, false, true, false, true, false, true, false, true }, 300 + 30 + 20 + 5 + 5 + 5)]
        [InlineData(Size.Large, Crust.DeepDish, new bool[] { false, true, false, true, false, true, false, true, false }, (300 + 20 + 20 + 5 + 5) * 1.3)]
        [InlineData(Size.Medium, Crust.Thin, new bool[] { false, false, false, false, false, true, true, true, true }, 150 + 5 + 5 + 5 + 5)]
        [InlineData(Size.Large, Crust.Thin, new bool[] { true, true, true, true, true, true, true, true, true }, (uint)((150 + 30 + 20 + 20 + 20 + 5 + 5 + 5 + 5 + 5) * 1.3))]
        public void CaloriesPerEachTest(Size s, Crust c, bool[] toppings, uint expected)
        {
            Pizza p = new Pizza();
            p.PizzaSize = s;
            p.PizzaCrust = c;
            p.SetTopping(Topping.Sausage, toppings[0]);
            p.SetTopping(Topping.Pepperoni, toppings[1]);
            p.SetTopping(Topping.Ham, toppings[2]);
            p.SetTopping(Topping.Bacon, toppings[3]);
            p.SetTopping(Topping.Olives, toppings[4]);
            p.SetTopping(Topping.Onions, toppings[5]);
            p.SetTopping(Topping.Mushrooms, toppings[6]);
            p.SetTopping(Topping.Peppers, toppings[7]);
            p.SetTopping(Topping.Pineapple, toppings[8]);
            Assert.Equal(expected, p.CaloriesPerEach);
        }

        /// <summary>
        /// Ensures correct CaloriesTotal value depending on size, toppings, and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="toppings">a bool[] of toppings </param>
        /// <param name="expected">the expected caloriestotal value</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, new bool[] { false, false, false, false, false, false, false, false, false }, 250 * 8)]
        [InlineData(Size.Small, Crust.Original, new bool[] { true, false, false, false, false, false, false, false, false }, (250 + 30) * .75 * 8)]
        [InlineData(Size.Large, Crust.Original, new bool[] { true, true, false, false, false, false, false, false, false }, (250 + 30 + 20) * 1.3 * 8)]
        [InlineData(Size.Small, Crust.DeepDish, new bool[] { true, true, true, false, false, false, false, false, false }, (uint)(((300 + 30 + 20 + 20) * 8) * .75) - 4)]
        [InlineData(Size.Medium, Crust.DeepDish, new bool[] { true, false, true, false, true, false, true, false, true }, (300 + 30 + 20 + 5 + 5 + 5) * 8)]
        [InlineData(Size.Large, Crust.DeepDish, new bool[] { false, true, false, true, false, true, false, true, false }, (300 + 20 + 20 + 5 + 5) * 1.3 * 8)]
        [InlineData(Size.Medium, Crust.Thin, new bool[] { false, false, false, false, false, true, true, true, true }, (150 + 5 + 5 + 5 + 5) * 8)]
        [InlineData(Size.Large, Crust.Thin, new bool[] { true, true, true, true, true, true, true, true, true }, (uint)(((150 + 30 + 20 + 20 + 20 + 5 + 5 + 5 + 5 + 5) * 8) * 1.3) - 4)]
        public void CaloriesTotalTest(Size s, Crust c, bool[] toppings, uint expected)
        {
            Pizza p = new Pizza();
            p.PizzaSize = s;
            p.PizzaCrust = c;
            p.SetTopping(Topping.Sausage, toppings[0]);
            p.SetTopping(Topping.Pepperoni, toppings[1]);
            p.SetTopping(Topping.Ham, toppings[2]);
            p.SetTopping(Topping.Bacon, toppings[3]);
            p.SetTopping(Topping.Olives, toppings[4]);
            p.SetTopping(Topping.Onions, toppings[5]);
            p.SetTopping(Topping.Mushrooms, toppings[6]);
            p.SetTopping(Topping.Peppers, toppings[7]);
            p.SetTopping(Topping.Pineapple, toppings[8]);
            Assert.Equal(expected, p.CaloriesTotal);
        }

        /// <summary>
        /// Ensures proper calories per slice
        /// </summary>
        /// <param name="c">crust type</param>
        /// <param name="s">size</param>
        /// <param name="toppings">a bool[] storing the presence of toppings on the pizza</param>
        /// <param name="expected">The expected values</param>
        [Theory]
        [InlineData(Crust.Original, Size.Medium,
            new bool[] { false, false, false, false, false, false, false, false, false },
            new String[] { "Medium", "Original Crust" })]
        [InlineData(Crust.Thin, Size.Medium,
            new bool[] { false, false, false, false, false, false, false, false, false }, new String[] { "Medium", "Thin Crust" })]
        [InlineData(Crust.DeepDish, Size.Medium,
            new bool[] { false, false, false, false, false, false, false, false, false }, new String[] { "Medium", "Deep Dish" })]
        [InlineData(Crust.Original, Size.Large,
            new bool[] { true, true, false, false, false, false, true, true, true }, new String[] { "Large", "Original Crust",
                "Sausage", "Pepperoni", "Mushrooms", "Peppers", "Pineapple" })]
        [InlineData(Crust.Original, Size.Small,
            new bool[] { false, false, false, false, false, false, false, false, false }, new String[] { "Small", "Original Crust" })]
        [InlineData(Crust.Original, Size.Medium,
            new bool[] { false, false, true, true, true, true, true, true, true }, new String[] { "Medium", "Original Crust",
                "Ham", "Bacon", "Olives", "Onions", "Mushrooms", "Peppers", "Pineapple" })]
        [InlineData(Crust.Original, Size.Medium,
            new bool[] { true, false, false, true, false, true, true, true, true }, new String[] { "Medium", "Original Crust",
                "Sausage", "Bacon", "Onions", "Mushrooms", "Peppers", "Pineapple"})]
        [InlineData(Crust.Original, Size.Large,
            new bool[] { true, true, true, true, true, true, true, true, true }, new String[] { "Large", "Original Crust",
                "Sausage", "Pepperoni", "Ham", "Bacon", "Olives", "Onions", "Mushrooms", "Peppers", "Pineapple"})]
        public void SpecialInstructionsTest(Crust c, Size s,
            bool[] toppings, IEnumerable<string> expected)
        {
            Pizza p = new Pizza();
            p.PizzaCrust = c;
            p.PizzaSize = s;
            p.SetTopping(Topping.Sausage, toppings[0]);
            p.SetTopping(Topping.Pepperoni, toppings[1]);
            p.SetTopping(Topping.Ham, toppings[2]);
            p.SetTopping(Topping.Bacon, toppings[3]);
            p.SetTopping(Topping.Olives, toppings[4]);
            p.SetTopping(Topping.Onions, toppings[5]);
            p.SetTopping(Topping.Mushrooms, toppings[6]);
            p.SetTopping(Topping.Peppers, toppings[7]);
            p.SetTopping(Topping.Pineapple, toppings[8]);
            Assert.Equal(expected, p.SpecialInstructions);
        }

        /// <summary>
        /// Ensures that the HasTopping function works properly
        /// </summary>
        [Fact]
        public void HasToppingTest()
        {
            Pizza p = new Pizza();
            p.SetTopping(Topping.Bacon, true);
            p.SetTopping(Topping.Pepperoni, true);
            Assert.True(p.PossibleToppings[3].OnPizza);
            Assert.True(p.PossibleToppings[1].OnPizza);
        }

        /// <summary>
        /// Ensures that the SetTopping function works properly
        /// </summary>
        [Fact]
        public void SetToppingTest()
        {
            Pizza p = new Pizza();
            p.SetTopping(Topping.Bacon, true);
            p.SetTopping(Topping.Pepperoni, true);
            Assert.True(p.PossibleToppings[3].OnPizza);
            Assert.True(p.PossibleToppings[1].OnPizza);
            p.SetTopping(Topping.Bacon, false);
            p.SetTopping(Topping.Pepperoni, false);
            Assert.False(p.PossibleToppings[3].OnPizza);
            Assert.False(p.PossibleToppings[1].OnPizza);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<IMenuItem>(new Pizza());
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


        
        /// <summary>
        /// Verifies that changing the sauce property notifies the correct property changes
        /// </summary>
        /// <param name="c">the sauce to set to</param>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData(Crust.Original, "PizzaCrust")]
        [InlineData(Crust.Thin, "PizzaCrust")]
        [InlineData(Crust.DeepDish, "PizzaCrust")]
        [InlineData(Crust.Original, "Price")]
        [InlineData(Crust.Thin, "Price")]
        [InlineData(Crust.DeepDish, "Price")]
        [InlineData(Crust.Original, "CaloriesPerEach")]
        [InlineData(Crust.Thin, "CaloriesPerEach")]
        [InlineData(Crust.DeepDish, "CaloriesTotal")]
        [InlineData(Crust.Original, "CaloriesTotal")]
        [InlineData(Crust.Thin, "SpecialInstructions")]
        [InlineData(Crust.DeepDish, "SpecialInstructions")]
        public void ChangingCrustShouldNotifyPropertyChanges(Crust c, string propertyName)
        {
            Pizza b = new Pizza();
            Assert.PropertyChanged(b, propertyName, () => {
                b.PizzaCrust = c;
            });
        }

        /// <summary>
        /// Verifies that changing the sauce property notifies the correct property changes
        /// </summary>
        /// <param name="s">the sauce to set to</param>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData(Size.Small, "PizzaSize")]
        [InlineData(Size.Medium, "PizzaSize")]
        [InlineData(Size.Large, "PizzaSize")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Small, "CaloriesPerEach")]
        [InlineData(Size.Medium, "CaloriesPerEach")]
        [InlineData(Size.Large, "CaloriesTotal")]
        [InlineData(Size.Small, "CaloriesTotal")]
        [InlineData(Size.Medium, "SpecialInstructions")]
        [InlineData(Size.Large, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyPropertyChanges(Size s, string propertyName)
        {
            Pizza b = new Pizza();
            Assert.PropertyChanged(b, propertyName, () => {
                b.PizzaSize = s;
            });
        }

        
    }
}
