using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the GarlicKnots class
    /// </summary>
    public class GarlicKnotsUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void NamePropertyTest()
        {
            GarlicKnots g = new GarlicKnots();
            Assert.Equal("Garlic Knots", g.Name);
        }

        /// <summary>
        /// Verifies the default value of the Description property
        /// </summary>
        [Fact]
        public void DescriptionPropertyTest()
        {
            GarlicKnots g = new GarlicKnots();
            Assert.Equal("Twisted rolls with garlic and butter", g.Description);
        }

        /// <summary>
        /// Verifies the default value of the Count property
        /// </summary>
        [Fact]
        public void CountPropertyTest()
        {
            GarlicKnots b = new GarlicKnots();
            Assert.Equal((uint)8, b.SideCount);
        }

        /// <summary>
        /// Verifies the bounds of the Count property
        /// </summary>
        [Fact]
        public void CountBoundsTest()
        {
            GarlicKnots b = new GarlicKnots();
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
            GarlicKnots g = new GarlicKnots();
            g.SideCount = a;
            Assert.Equal(expected, g.SideCount);
        }

        /// <summary>
        /// Verifies the default value of the price property
        /// </summary>
        [Fact]
        public void PricePropertyTest()
        {
            GarlicKnots g = new GarlicKnots();
            Assert.Equal(0.75m * g.SideCount, g.Price);
        }

        /// <summary>
        /// Verifies the calories of each garlic knot
        /// </summary>
        [Fact]
        public void CaloriesPerEachTest()
        {
            GarlicKnots g = new GarlicKnots();
            Assert.Equal(175m, g.CaloriesPerEach);
        }

        /// <summary>
        /// Verifies the calories of the garlic knots given the count value
        /// </summary>
        /// <param name="count">the number of garlic knots</param>
        /// <param name="expected">the expected calories</param>
        [Theory]
        [InlineData(4, 700)]
        [InlineData(5, 875)]
        [InlineData(6, 1050)]
        [InlineData(7, 1225)]
        [InlineData(8, 1400)]
        [InlineData(10, 1750)]
        [InlineData(11, 1925)]
        [InlineData(12, 2100)]
        public void CaloriesTotalTest(uint count, uint expected)
        {
            GarlicKnots g = new GarlicKnots();
            g.SideCount = count;
            Assert.Equal(expected, g.CaloriesTotal);
        }

        /// <summary>
        /// Insures correct special instructions
        /// </summary>
        /// <param name="count">the number of garlic knots</param>
        /// <param name="expected">the expected resulting string</param>
        [Theory]
        [InlineData(4, new string[] { "4 Garlic Knots" })]
        [InlineData(5, new string[] { "5 Garlic Knots" })]
        [InlineData(6, new string[] { "6 Garlic Knots" })]
        [InlineData(7, new string[] { "7 Garlic Knots" })]
        [InlineData(8, new string[] { "8 Garlic Knots" })]
        [InlineData(10, new string[] { "10 Garlic Knots" })]
        [InlineData(11, new string[] { "11 Garlic Knots" })]
        [InlineData(12, new string[] { "12 Garlic Knots" })]
        public void SpecialInstructionsTest(uint count, IEnumerable<string> expected)
        {
            GarlicKnots g = new GarlicKnots();
            g.SideCount = count;
            Assert.Equal(expected, g.SpecialInstructions);
        }


        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Side>(new GarlicKnots());
            Assert.IsAssignableFrom<IMenuItem>(new GarlicKnots());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            GarlicKnots b = new GarlicKnots();
            Assert.Equal("Garlic Knots", b.ToString());
        }
        
        /// <summary>
        /// Casting test for INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GarlicKnots c = new GarlicKnots();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(c);
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
            GarlicKnots b = new GarlicKnots();
            Assert.PropertyChanged(b, propertyName, () => {
                b.SideCount = count;
            });
        }
    }
}