using PizzaParlor.Data;
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the breadsticks class
    /// </summary>
    public class BreadsticksUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void DefaultPropertyTest()
        {
            Breadsticks b = new Breadsticks();
            Assert.Equal("Breadsticks", b.Name);
            Assert.Equal("Soft buttery breadsticks", b.Description);
            Assert.Equal((uint)8, b.SideCount);
            Assert.False(b.Cheese);
        }

        /// <summary>
        /// Verifies the bounds of the Count property
        /// </summary>
        [Fact]
        public void CountBoundsTest()
        {
            Breadsticks b = new Breadsticks();
            b.SideCount = 0;
            b.SideCount = 20;
            b.SideCount = 1000;
            b.SideCount = 10000;
            Assert.Equal((uint)8, b.SideCount);
        }

        /// <summary>
        /// Verifies the count property works as intended
        /// </summary>
        /// <param name="a">the uint to set</param>
        /// <param name="expected">the expected uint Count should be after <paramref name="a"/> is set</param>
        [Theory]
        [InlineData(0, 8)]
        [InlineData(6, 6)]
        [InlineData(4, 4)]
        [InlineData(20, 8)]
        [InlineData(100, 8)]
        [InlineData(10, 10)]
        [InlineData(12, 12)]
        [InlineData(1, 8)]
        public void CountSetTest(uint a, uint expected)
        {
            Breadsticks b = new Breadsticks();
            b.SideCount = a;
            Assert.Equal(expected, b.SideCount);
        }

        /// <summary>
        /// Verifies the price of the breadsticks given cheese and count values
        /// </summary>
        /// <param name="cheese">a boolean if the breadsticks have cheese</param>
        /// <param name="count">the number of breadsticks</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, 8, 8.00)]
        [InlineData(false, 4, 3.00)]
        [InlineData(true, 5, 5.00)]
        [InlineData(false, 6, 4.50)]
        [InlineData(true, 7, 7.00)]
        [InlineData(false, 10, 7.50)]
        [InlineData(false, 12, 9.00)]
        [InlineData(true, 12, 12.00)]
        public void PriceTest(bool cheese, uint count, decimal expected)
        {
            Breadsticks b = new Breadsticks();
            b.Cheese = cheese;
            b.SideCount = count;
            Assert.Equal(expected, b.Price);
        }

        /// <summary>
        /// Verifies the calories of each breadstick given cheese
        /// </summary>
        /// <param name="cheese">a boolean if the breadsticks have cheese</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, 200)]
        [InlineData(false, 150)]
        public void CaloriesPerEachTest(bool cheese, uint expected)
        {
            Breadsticks b = new Breadsticks();
            b.Cheese = cheese;
            Assert.Equal(expected, b.CaloriesPerEach);
        }

        /// <summary>
        /// Verifies the calories of the breadsticks given cheese and count values
        /// </summary>
        /// <param name="cheese">a boolean if the breadsticks have cheese</param>
        /// <param name="count">the number of breadsticks</param>
        /// <param name="expected">the expected calories</param>
        [Theory]
        [InlineData(true, 8, 1600)]
        [InlineData(false, 4, 600)]
        [InlineData(true, 5, 1000)]
        [InlineData(false, 6, 900)]
        [InlineData(true, 7, 1400)]
        [InlineData(false, 10, 1500)]
        [InlineData(false, 12, 1800)]
        [InlineData(true, 12, 2400)]
        public void CaloriesTotalTest(bool cheese, uint count, decimal expected)
        {
            Breadsticks b = new Breadsticks();
            b.Cheese = cheese;
            b.SideCount = count;
            Assert.Equal(expected, b.CaloriesTotal);
        }

        /// <summary>
        /// Insures correct special instructions
        /// </summary>
        /// <param name="count">the number of breadsticks</param>
        /// <param name="cheese">if there is cheese or not</param>
        /// <param name="expected">the expected resulting string</param>
        [Theory]
        [InlineData(8, true, new string[] { "8 Cheesesticks" })]
        [InlineData(12, true, new string[] { "12 Cheesesticks" })]
        [InlineData(4, true, new string[] { "4 Cheesesticks" })]
        [InlineData(6, true, new string[] { "6 Cheesesticks" })]
        [InlineData(4, false, new string[] { "4 Breadsticks" })]
        [InlineData(8, false, new string[] { "8 Breadsticks" })]
        [InlineData(6, false, new string[] { "6 Breadsticks" })]
        [InlineData(12, false, new string[] { "12 Breadsticks" })]
        public void SpecialInstructionsTest(uint count, bool cheese, IEnumerable<string> expected)
        {
            Breadsticks b = new Breadsticks();
            b.SideCount = count;
            b.Cheese = cheese;
            Assert.Equal(expected, b.SpecialInstructions);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Side>(new Breadsticks());
            Assert.IsAssignableFrom<IMenuItem>(new Breadsticks());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Breadsticks b = new Breadsticks();
            Assert.Equal("Breadsticks", b.ToString());
        }

        /// <summary>
        /// Casting test for INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Breadsticks b = new Breadsticks();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(b);
        }

        /// <summary>
        /// Verifies that changing the count property notifies the correct property changes
        /// </summary>
        /// <param name="count">the count to set to</param>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData(4, "SideCount")]
        [InlineData(6, "SideCount")]
        [InlineData(10, "SideCount")]
        [InlineData(4, "CaloriesTotal")]
        [InlineData(12, "CaloriesTotal")]
        [InlineData(9, "CaloriesTotal")]
        [InlineData(9, "Price")]
        [InlineData(4, "Price")]
        [InlineData(12, "Price")]
        public void ChangingCountShouldNotifyPropertyChanges(uint count, string propertyName)
        {
            Breadsticks b = new Breadsticks();
            Assert.PropertyChanged(b, propertyName, () => {
                b.SideCount = count;
            });
        }

        /// <summary>
        /// Ensures the correct properties are notified when the cheese bool changes
        /// </summary>
        [Fact]
        public void ChangingCheeseBoolShouldNotifyPropertyChanges()
        {
            Breadsticks b = new Breadsticks();
            Assert.PropertyChanged(b, "Cheese", () => {
                b.Cheese = true;
            });
            Assert.PropertyChanged(b, "Cheese", () => {
                b.Cheese = false;
            });
            Assert.PropertyChanged(b, "Price", () => {
                b.Cheese = true;
            });
            Assert.PropertyChanged(b, "CaloriesPerEach", () => {
                b.Cheese = false;
            });
            Assert.PropertyChanged(b, "CaloriesTotal", () => {
                b.Cheese = true;
            });
            Assert.PropertyChanged(b, "SpecialInstructions", () => {
                b.Cheese = false;
            });
        }
    }
}