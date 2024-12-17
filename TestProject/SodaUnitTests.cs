using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the Soda class
    /// </summary>
    public class SodaUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void NamePropertyTest()
        {
            Soda s = new Soda();
            Assert.Equal("Soda", s.Name);
        }

        /// <summary>
        /// Verifies the default value of the Description property
        /// </summary>
        [Fact]
        public void DescriptionPropertyTest()
        {
            Soda s = new Soda();
            Assert.Equal("Standard fountain drink", s.Description);
        }

        /// <summary>
        /// Verifies the default value of the Ice property
        /// </summary>
        [Fact]
        public void IcePropertyTest()
        {
            Soda s = new Soda();
            Assert.True(s.Ice);
        }

        /// <summary>
        /// Verifies the default value of the DrinkSize property
        /// </summary>
        [Fact]
        public void DrinkSizePropertyTest()
        {
            Soda s = new Soda();
            Assert.Equal(Size.Medium, s.DrinkSize);
        }

        /// <summary>
        /// Verifies the default value of the DrinkType property
        /// </summary>
        [Fact]
        public void DrinkTypePropertyTest()
        {
            Soda s = new Soda();
            Assert.Equal(SodaFlavor.Coke, s.DrinkType);
        }


        /// <summary>
        /// Verifies the value of the price property
        /// </summary>
        /// <param name="size">the size of the drink</param>
        /// <param name="expected">the expected price of the drink</param>
        [Theory]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Large, 2.50)]
        public void PricePropertyTest(Size size, decimal expected)
        {
            Soda s = new Soda();
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
        [InlineData(Size.Small, SodaFlavor.Coke, 150)]
        [InlineData(Size.Medium, SodaFlavor.DrPepper, 200)]
        [InlineData(Size.Large, SodaFlavor.Sprite, 250)]
        [InlineData(Size.Small, SodaFlavor.DietCoke, 0)]
        public void CaloriesPerEachTest(Size size, SodaFlavor flavor, uint expected)
        {
            Soda s = new Soda();
            s.DrinkSize = size;
            s.DrinkType = flavor;
            Assert.Equal(expected, s.CaloriesPerEach);
        }

        /// <summary>
        /// Verifies the calories of the soda
        /// </summary>
        /// <param name="expected">The expected calories of the soda</param>
        /// <param name="flavor">The flavor of the given soda</param>
        /// <param name="size">The size of the soda</param>
        [Theory]
        [InlineData(Size.Small, SodaFlavor.Coke, 150)]
        [InlineData(Size.Medium, SodaFlavor.DrPepper, 200)]
        [InlineData(Size.Large, SodaFlavor.Sprite, 250)]
        [InlineData(Size.Small, SodaFlavor.DietCoke, 0)]
        public void CaloriesTotalTest(Size size, SodaFlavor flavor, uint expected)
        {
            Soda s = new Soda();
            s.DrinkSize = size;
            s.DrinkType = flavor;
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
        [InlineData(Size.Small, SodaFlavor.Coke, true, new string[] { "Small", "Coke" })]
        [InlineData(Size.Medium, SodaFlavor.Sprite, true, new string[] { "Medium", "Sprite" })]
        [InlineData(Size.Large, SodaFlavor.Coke, false, new string[] { "Large", "Coke", "Hold Ice" })]
        [InlineData(Size.Medium, SodaFlavor.DrPepper, true, new string[] { "Medium", "DrPepper" })]
        [InlineData(Size.Large, SodaFlavor.Coke, true, new string[] { "Large", "Coke" })]
        [InlineData(Size.Small, SodaFlavor.Coke, false, new string[] { "Small", "Coke", "Hold Ice" })]
        [InlineData(Size.Medium, SodaFlavor.RootBeer, true, new string[] { "Medium", "Root Beer" })]
        [InlineData(Size.Large, SodaFlavor.DietCoke, true, new string[] { "Large", "Diet Coke" })]
        public void SpecialInstructionsTest(Size size, SodaFlavor type, bool ice, IEnumerable<string> expected)
        {
            Soda s = new Soda();
            s.DrinkSize = size;
            s.DrinkType = type;
            s.Ice = ice;
            Assert.Equal(expected, s.SpecialInstructions);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Drink>(new Soda());
            Assert.IsAssignableFrom<IMenuItem>(new Soda());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Soda b = new Soda();
            Assert.Equal("Soda", b.ToString());
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
            Soda soda = new Soda();
            Assert.PropertyChanged(soda, propertyName, () => {
                soda.DrinkSize = size;
            });
        }

        /// <summary>
        /// Ensures changing the flavor changes correct properties
        /// </summary>
        /// <param name="s">flavor to change to </param>
        /// <param name="propertyName">name of the property that should change</param>
        [Theory]
        [InlineData(SodaFlavor.Coke, "DrinkType")]
        [InlineData(SodaFlavor.DietCoke, "DrinkType")]
        [InlineData(SodaFlavor.RootBeer, "DrinkType")]
        [InlineData(SodaFlavor.Sprite, "Price")]
        [InlineData(SodaFlavor.DrPepper, "Price")]
        [InlineData(SodaFlavor.Coke, "Price")]
        [InlineData(SodaFlavor.DietCoke, "CaloriesTotal")]
        [InlineData(SodaFlavor.RootBeer, "CaloriesTotal")]
        [InlineData(SodaFlavor.Sprite, "CaloriesTotal")]
        [InlineData(SodaFlavor.DrPepper, "CaloriesPerEach")]
        [InlineData(SodaFlavor.Coke, "CaloriesPerEach")]
        [InlineData(SodaFlavor.DietCoke, "CaloriesPerEach")]
        [InlineData(SodaFlavor.RootBeer, "SpecialInstructions")]
        [InlineData(SodaFlavor.Sprite, "SpecialInstructions")]
        [InlineData(SodaFlavor.DrPepper, "SpecialInstructions")]
        public void ChangingFlavorShouldNotifyOfPropertyChanges(SodaFlavor s, string propertyName)
        {
            Soda soda = new Soda();
            Assert.PropertyChanged(soda, propertyName, () => {
                soda.DrinkType = s;
            });
        }

        /// <summary>
        /// Ensures changing the ice bool changes other properties
        /// </summary>
        [Fact]
        public void ChangingIceShouldNotifyOfPropertyChanges()
        {
            Soda soda = new Soda();
            Assert.PropertyChanged(soda, nameof(soda.Ice), () => {
                soda.Ice = false;
            });
            Assert.PropertyChanged(soda, nameof(soda.Ice), () => {
                soda.Ice = true;
            });
            Assert.PropertyChanged(soda, nameof(soda.SpecialInstructions), () => {
                soda.Ice = false;
            });
            Assert.PropertyChanged(soda, nameof(soda.SpecialInstructions), () => {
                soda.Ice = true;
            });
        }

        /// <summary>
        /// Casting test
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Soda soda = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(soda);
        }

    }
}