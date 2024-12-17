using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the CinnamonSticks class
    /// </summary>
    public class CinnamonSticksUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void NamePropertyTest()
        {
            CinnamonSticks c = new CinnamonSticks();
            Assert.Equal("Cinnamon Sticks", c.Name);
        }

        /// <summary>
        /// Verifies the default value of the Description property
        /// </summary>
        [Fact]
        public void DescriptionPropertyTest()
        {
            CinnamonSticks c = new CinnamonSticks();
            Assert.Equal("Like breadsticks but for dessert", c.Description);
        }

        /// <summary>
        /// Verifies the default value of the Count property
        /// </summary>
        [Fact]
        public void CountPropertyTest()
        {
            CinnamonSticks c = new CinnamonSticks();
            Assert.Equal((uint)8, c.SideCount);
        }

        /// <summary>
        /// Verifies the default value of the Frosting property
        /// </summary>
        [Fact]
        public void FrostingPropertyTest()
        {
            CinnamonSticks c = new CinnamonSticks();
            Assert.True(c.Frosting);
        }

        /// <summary>
        /// Verifies the bounds of the Count property
        /// </summary>
        [Fact]
        public void CountBoundsTest()
        {
            CinnamonSticks c = new CinnamonSticks();
            c.SideCount = 0;
            c.SideCount = 20;
            c.SideCount = 1000;
            c.SideCount = 10000;
            Assert.Equal((uint)8, c.SideCount);
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
            CinnamonSticks c = new CinnamonSticks();
            c.SideCount = a;
            Assert.Equal(expected, c.SideCount);
        }

        /// <summary>
        /// Verifies the price of the cinnamonsticks given frosting and count values
        /// </summary>
        /// <param name="frosting">a boolean if the cinnamonsticks have frosting</param>
        /// <param name="count">the number of cinnamonsticks</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, 8, 7.20)]
        [InlineData(false, 4, 3.00)]
        [InlineData(true, 5, 4.5)]
        [InlineData(false, 6, 4.50)]
        [InlineData(true, 7, 6.3)]
        [InlineData(false, 10, 7.50)]
        [InlineData(false, 12, 9.00)]
        [InlineData(true, 12, 10.8)]
        public void PriceTest(bool frosting, uint count, decimal expected)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.Frosting = frosting;
            c.SideCount = count;
            Assert.Equal(expected, c.Price);
        }

        /// <summary>
        /// Verifies the calories of each breadstick given cheese
        /// </summary>
        /// <param name="frosting">a boolean if the breadsticks have cheese</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, 190)]
        [InlineData(false, 160)]
        public void CaloriesPerEachTest(bool frosting, uint expected)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.Frosting = frosting;
            Assert.Equal(expected, c.CaloriesPerEach);
        }

        /// <summary>
        /// Verifies the calories of the cinnamonsticks given frosting and count values
        /// </summary>
        /// <param name="frosting">a boolean if the breadsticks have cheese</param>
        /// <param name="count">the number of breadsticks</param>
        /// <param name="expected">the expected calories</param>
        [Theory]
        [InlineData(true, 8, 1520)]
        [InlineData(false, 4, 640)]
        [InlineData(true, 5, 950)]
        [InlineData(false, 6, 960)]
        [InlineData(true, 7, 1330)]
        [InlineData(false, 10, 1600)]
        [InlineData(false, 12, 1920)]
        [InlineData(true, 12, 2280)]
        public void CaloriesTotalTest(bool frosting, uint count, decimal expected)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.Frosting = frosting;
            c.SideCount = count;
            Assert.Equal(expected, c.CaloriesTotal);
        }

        /// <summary>
        /// Insures correct special instructions
        /// </summary>
        /// <param name="count">the number of cinnamon sticks</param>
        /// <param name="frosting">if there is frosting or not</param>
        /// <param name="expected">the expected resulting string</param>
        [Theory]
        [InlineData(8, true, new string[] { "8 Cinnamon Sticks" })]
        [InlineData(12, true, new string[] { "12 Cinnamon Sticks" })]
        [InlineData(4, true, new string[] { "4 Cinnamon Sticks" })]
        [InlineData(6, true, new string[] { "6 Cinnamon Sticks" })]
        [InlineData(4, false, new string[] { "4 Cinnamon Sticks", "Hold Frosting" })]
        [InlineData(8, false, new string[] { "8 Cinnamon Sticks", "Hold Frosting" })]
        [InlineData(6, false, new string[] { "6 Cinnamon Sticks", "Hold Frosting" })]
        [InlineData(12, false, new string[] { "12 Cinnamon Sticks", "Hold Frosting" })]
        public void SpecialInstructionsTest(uint count, bool frosting, IEnumerable<string> expected)
        {
            CinnamonSticks c = new CinnamonSticks();
            c.SideCount = count;
            c.Frosting = frosting;
            Assert.Equal(expected, c.SpecialInstructions);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Side>(new CinnamonSticks());
            Assert.IsAssignableFrom<IMenuItem>(new CinnamonSticks());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CinnamonSticks b = new CinnamonSticks();
            Assert.Equal("Cinnamon Sticks", b.ToString());
        }

        /// <summary>
        /// Casting test for INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CinnamonSticks c = new CinnamonSticks();
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
            CinnamonSticks b = new CinnamonSticks();
            Assert.PropertyChanged(b, propertyName, () => {
                b.SideCount = count;
            });
        }

        /// <summary>
        /// Ensures the correct properties are notified when the cheese bool changes
        /// </summary>
        [Fact]
        public void ChangingFrostingBoolShouldNotifyPropertyChanges()
        {
            CinnamonSticks b = new CinnamonSticks();
            Assert.PropertyChanged(b, "Frosting", () => {
                b.Frosting = true;
            });
            Assert.PropertyChanged(b, "Frosting", () => {
                b.Frosting = false;
            });
            Assert.PropertyChanged(b, "Price", () => {
                b.Frosting = true;
            });
            Assert.PropertyChanged(b, "CaloriesPerEach", () => {
                b.Frosting = false;
            });
            Assert.PropertyChanged(b, "CaloriesTotal", () => {
                b.Frosting = true;
            });
            Assert.PropertyChanged(b, "SpecialInstructions", () => {
                b.Frosting = false;
            });
        }
    }
}