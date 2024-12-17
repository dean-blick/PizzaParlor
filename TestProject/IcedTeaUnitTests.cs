using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the IcedTea class
    /// </summary>
    public class IcedTeaUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void NamePropertyTest()
        {
            IcedTea s = new IcedTea();
            Assert.Equal("Iced Tea", s.Name);
        }

        /// <summary>
        /// Verifies the default value of the Description property
        /// </summary>
        [Fact]
        public void DescriptionPropertyTest()
        {
            IcedTea s = new IcedTea();
            Assert.Equal("Freshly brewed sweet tea", s.Description);
        }

        /// <summary>
        /// Verifies the default value of the Ice property
        /// </summary>
        [Fact]
        public void IcePropertyTest()
        {
            IcedTea s = new IcedTea();
            Assert.True(s.Ice);
        }

        /// <summary>
        /// Verifies the default value of the DrinkSize property
        /// </summary>
        [Fact]
        public void DrinkSizePropertyTest()
        {
            IcedTea s = new IcedTea();
            Assert.Equal(Size.Medium, s.DrinkSize);
        }


        /// <summary>
        /// Verifies the value of the price property
        /// </summary>
        /// <param name="size">the size of the drink</param>
        /// <param name="expected">the expected price of the drink</param>
        [Theory]
        [InlineData(Size.Medium, 2.50)]
        [InlineData(Size.Small, 2.00)]
        [InlineData(Size.Large, 3.00)]
        public void PricePropertyTest(Size size, decimal expected)
        {
            IcedTea s = new IcedTea();
            s.DrinkSize = size;
            Assert.Equal(expected, s.Price);
        }

        /// <summary>
        /// Verifies the calories of the soda
        /// </summary>
        /// <param name="expected">The expected calories of the soda</param>
        /// <param name="flavor">The flavor of the given soda</param>
        /// <param name="size">The size of the soda</param>
        [Theory]
        [InlineData(Size.Small, 175)]
        [InlineData(Size.Medium, 220)]
        [InlineData(Size.Large, 275)]
        public void CaloriesTest(Size size, uint expected)
        {
            IcedTea s = new IcedTea();
            s.DrinkSize = size;
            Assert.Equal(expected, s.CaloriesTotal);
        }


        /// <summary>
        /// Ensures correct special instructions
        /// </summary>
        /// <param name="expected">the expected resulting string</param>
        /// <param name="ice">a bool if there is ice or not</param>
        /// <param name="size">the size of the drink</param>
        /// <param name="type">the flavor of the drink</param>
        [Theory]
        [InlineData(Size.Small, true, new string[] { "Small" })]
        [InlineData(Size.Medium, true, new string[] { "Medium" })]
        [InlineData(Size.Large, false, new string[] { "Large", "Hold Ice" })]
        [InlineData(Size.Medium, false, new string[] { "Medium", "Hold Ice" })]
        [InlineData(Size.Large, true, new string[] { "Large" })]
        [InlineData(Size.Small, false, new string[] { "Small", "Hold Ice" })]
        public void SpecialInstructionsTest(Size size, bool ice, IEnumerable<string> expected)
        {
            IcedTea s = new IcedTea();
            s.DrinkSize = size;
            s.Ice = ice;
            Assert.Equal(expected, s.SpecialInstructions);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Drink>(new IcedTea());
            Assert.IsAssignableFrom<IMenuItem>(new IcedTea());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            IcedTea b = new IcedTea();
            Assert.Equal("Iced Tea", b.ToString());
        }

        /// <summary>
        /// Ensures changing the size changes correct properties
        /// </summary>
        /// <param name="size">size to change to </param>
        /// <param name="propertyName">name of the property that should change</param>
        [Theory]
        [InlineData(Size.Small, "DrinkSize")]
        [InlineData(Size.Medium, "DrinkSize")]
        [InlineData(Size.Large, "DrinkSize")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Small, "CaloriesTotal")]
        [InlineData(Size.Medium, "CaloriesTotal")]
        [InlineData(Size.Large, "CaloriesTotal")]
        [InlineData(Size.Small, "CaloriesPerEach")]
        [InlineData(Size.Medium, "CaloriesPerEach")]
        [InlineData(Size.Large, "CaloriesPerEach")]
        [InlineData(Size.Small, "SpecialInstructions")]
        [InlineData(Size.Medium, "SpecialInstructions")]
        [InlineData(Size.Large, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            IcedTea tea = new IcedTea();
            Assert.PropertyChanged(tea, propertyName, () => {
                tea.DrinkSize = size;
            });
        }

        /// <summary>
        /// Ensures changing the ice bool changes other properties
        /// </summary>
        [Fact]
        public void ChangingIceShouldNotifyOfPropertyChanges()
        {
            IcedTea tea = new IcedTea();
            Assert.PropertyChanged(tea, nameof(tea.Ice), () => {
                tea.Ice = false;
            });
            Assert.PropertyChanged(tea, nameof(tea.Ice), () => {
                tea.Ice = true;
            });
            Assert.PropertyChanged(tea, nameof(tea.SpecialInstructions), () => {
                tea.Ice = false;
            });
            Assert.PropertyChanged(tea, nameof(tea.SpecialInstructions), () => {
                tea.Ice = true;
            });
        }

        /// <summary>
        /// Casting test
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            IcedTea tea = new IcedTea();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tea);
        }

    }
}