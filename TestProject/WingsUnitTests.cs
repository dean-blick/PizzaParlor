using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Class for testing the Wings class
    /// </summary>
    public class WingsUnitTests
    {
        /// <summary>
        /// Verifies the default value of the Name property
        /// </summary>
        [Fact]
        public void NamePropertyTest()
        {
            Wings w = new Wings();
            Assert.Equal("Wings", w.Name);
        }

        /// <summary>
        /// Verifies the default value of the Description property
        /// </summary>
        [Fact]
        public void DescriptionPropertyTest()
        {
            Wings w = new Wings();
            Assert.Equal("Chicken wings tossed in sauce", w.Description);
        }

        /// <summary>
        /// Verifies the default value of the Count property
        /// </summary>
        [Fact]
        public void CountPropertyTest()
        {
            Wings w = new Wings();
            Assert.Equal((uint)5, w.SideCount);
        }

        /// <summary>
        /// Verifies the default value of the Sauce property
        /// </summary>
        [Fact]
        public void SauceDefaultPropertyTest()
        {
            Wings w = new Wings();
            Assert.Equal(WingSauce.Medium, w.Sauce);
        }

        /// <summary>
        /// Verifies setting the value of the Sauce property
        /// </summary>
        /// <param name="expected">the expected value of w.Sauce</param>
        /// <param name="s">The sauce to set to</param>
        [Theory]
        [InlineData(WingSauce.Medium, WingSauce.Medium)]
        [InlineData(WingSauce.HoneyBBQ, WingSauce.HoneyBBQ)]
        [InlineData(WingSauce.Hot, WingSauce.Hot)]
        [InlineData(WingSauce.Mild, WingSauce.Mild)]
        public void SauceSetPropertyTest(WingSauce s, WingSauce expected)
        {
            Wings w = new Wings();
            w.Sauce = s;
            Assert.Equal(expected, w.Sauce);
        }

        /// <summary>
        /// Verifies the default value of the BoneIn property
        /// </summary>
        [Fact]
        public void BoneInPropertyTest()
        {
            Wings w = new Wings();
            Assert.True(w.BoneIn);
        }

        /// <summary>
        /// Verifies the bounds of the Count property
        /// </summary>
        [Fact]
        public void CountBoundsTest()
        {
            Wings w = new Wings();
            w.SideCount = 0;
            w.SideCount = 20;
            w.SideCount = 1000;
            w.SideCount = 10000;
            Assert.Equal((uint)5, w.SideCount);
        }

        /// <summary>
        /// Verifies the count property works as intended
        /// </summary>
        /// <param name="a">the uint to set</param>
        /// <param name="expected">the expected uint Count should be after <paramref name="a"/> is set</param>
        [Theory]
        [InlineData(0, 5)]
        [InlineData(6, 6)]
        [InlineData(4, 4)]
        [InlineData(20, 5)]
        [InlineData(100, 5)]
        [InlineData(10, 10)]
        [InlineData(12, 12)]
        [InlineData(1, 5)]
        public void CountSetTest(uint a, uint expected)
        {
            Wings w = new Wings();
            w.SideCount = a;
            Assert.Equal(expected, w.SideCount);
        }

        /// <summary>
        /// Verifies the price of the Wings given bonein and count values
        /// </summary>
        /// <param name="bonein">a boolean if the Wings have cheese</param>
        /// <param name="count">the number of Wings</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, 8, 12.00)]
        [InlineData(false, 4, 7.00)]
        [InlineData(true, 5, 7.50)]
        [InlineData(false, 6, 10.50)]
        [InlineData(true, 7, 10.50)]
        [InlineData(false, 10, 17.50)]
        [InlineData(false, 12, 21.0)]
        [InlineData(true, 12, 18.00)]
        public void PriceTest(bool bonein, uint count, decimal expected)
        {
            Wings w = new Wings();
            w.BoneIn = bonein;
            w.SideCount = count;
            Assert.Equal(expected, w.Price);
        }

        /// <summary>
        /// Verifies the calories of each wing given BoneIn and Sauce values
        /// </summary>
        /// <param name="bonein">a boolean if the Wings are bonein</param>
        /// <param name="s">the sauce of the wings</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(true, WingSauce.Mild, 125)]
        [InlineData(true, WingSauce.Hot, 125)]
        [InlineData(true, WingSauce.HoneyBBQ, 145)]
        [InlineData(false, WingSauce.Mild, 175)]
        [InlineData(false, WingSauce.HoneyBBQ, 195)]
        [InlineData(false, WingSauce.Medium, 175)]
        [InlineData(true, WingSauce.Medium, 125)]
        [InlineData(false, WingSauce.Hot, 175)]
        public void CaloriesPerEachTest(bool bonein, WingSauce s, uint expected)
        {
            Wings w = new Wings();
            w.BoneIn = bonein;
            w.Sauce = s;
            Assert.Equal(expected, w.CaloriesPerEach);
        }

        /// <summary>
        /// Verifies the calories of the Wings given bonein, sauce, and count values
        /// </summary>
        /// <param name="bonein">a boolean if the Wings are bone in</param>
        /// <param name="count">the number of Wings</param>
        /// <param name="s">the sauce of the wings</param>
        /// <param name="expected">the expected calories</param>
        [Theory]
        [InlineData(true, 8, WingSauce.Mild, 1000)]
        [InlineData(true, 5, WingSauce.Hot, 625)]
        [InlineData(true, 10, WingSauce.HoneyBBQ, 1450)]
        [InlineData(false, 12, WingSauce.Mild, 2100)]
        [InlineData(false, 7, WingSauce.HoneyBBQ, 1365)]
        [InlineData(false, 10, WingSauce.Medium, 1750)]
        [InlineData(true, 10, WingSauce.Medium, 1250)]
        [InlineData(false, 10, WingSauce.Hot, 1750)]
        public void CaloriesTotalTest(bool bonein, uint count, WingSauce s, decimal expected)
        {
            Wings w = new Wings();
            w.BoneIn = bonein;
            w.SideCount = count;
            w.Sauce = s;
            Assert.Equal(expected, w.CaloriesTotal);
        }

        /// <summary>
        /// Insures correct special instructions
        /// </summary>
        /// <param name="count">the number of Wings</param>
        /// <param name="bonein">if the wings are bone-in or not</param>
        /// <param name="s">the sauce of the wings</param>
        /// <param name="expected">the expected resulting string</param>
        [Theory]
        [InlineData(8, false, WingSauce.Hot, new string[] { "8 Boneless Wings", "Hot" })]
        [InlineData(12, false, WingSauce.Medium, new string[] { "12 Boneless Wings", "Medium" })]
        [InlineData(4, false, WingSauce.Mild, new string[] { "4 Boneless Wings", "Mild" })]
        [InlineData(6, false, WingSauce.HoneyBBQ, new string[] { "6 Boneless Wings", "HoneyBBQ" })]
        [InlineData(4, true, WingSauce.Hot, new string[] { "4 Bone-In Wings", "Hot" })]
        [InlineData(8, true, WingSauce.Medium, new string[] { "8 Bone-In Wings", "Medium" })]
        [InlineData(6, true, WingSauce.Mild, new string[] { "6 Bone-In Wings", "Mild" })]
        [InlineData(12, true, WingSauce.HoneyBBQ, new string[] { "12 Bone-In Wings", "HoneyBBQ" })]
        public void SpecialInstructionsTest(uint count, bool bonein, WingSauce s, IEnumerable<string> expected)
        {
            Wings w = new Wings();
            w.SideCount = count;
            w.BoneIn = bonein;
            w.Sauce = s;
            Assert.Equal(expected, w.SpecialInstructions);
        }

        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Side>(new Wings());
            Assert.IsAssignableFrom<IMenuItem>(new Wings());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Wings b = new Wings();
            Assert.Equal("Wings", b.ToString());
        }

        /// <summary>
        /// Casting test for INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Wings b = new Wings();
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
            Wings b = new Wings();
            Assert.PropertyChanged(b, propertyName, () => {
                b.SideCount = count;
            });
        }

        /// <summary>
        /// Ensures the correct properties are notified when the cheese bool changes
        /// </summary>
        [Fact]
        public void ChangingBoneInBoolShouldNotifyPropertyChanges()
        {
            Wings b = new Wings();
            Assert.PropertyChanged(b, "BoneIn", () => {
                b.BoneIn = true;
            });
            Assert.PropertyChanged(b, "BoneIn", () => {
                b.BoneIn = false;
            });
            Assert.PropertyChanged(b, "Price", () => {
                b.BoneIn = true;
            });
            Assert.PropertyChanged(b, "CaloriesPerEach", () => {
                b.BoneIn = false;
            });
            Assert.PropertyChanged(b, "CaloriesTotal", () => {
                b.BoneIn = true;
            });
            Assert.PropertyChanged(b, "SpecialInstructions", () => {
                b.BoneIn = false;
            });
        }

        /// <summary>
        /// Verifies that changing the sauce property notifies the correct property changes
        /// </summary>
        /// <param name="s">the sauce to set to</param>
        /// <param name="propertyName">the name of the property that should be changing</param>
        [Theory]
        [InlineData(WingSauce.Medium, "Sauce")]
        [InlineData(WingSauce.HoneyBBQ, "Sauce")]
        [InlineData(WingSauce.Hot, "Sauce")]
        [InlineData(WingSauce.Medium, "CaloriesPerEach")]
        [InlineData(WingSauce.HoneyBBQ, "CaloriesPerEach")]
        [InlineData(WingSauce.Hot, "CaloriesTotal")]
        [InlineData(WingSauce.Medium, "CaloriesTotal")]
        [InlineData(WingSauce.HoneyBBQ, "SpecialInstructions")]
        [InlineData(WingSauce.Hot, "SpecialInstructions")]
        public void ChangingSauceShouldNotifyPropertyChanges(WingSauce s, string propertyName)
        {
            Wings b = new Wings();
            Assert.PropertyChanged(b, propertyName, () => {
                b.Sauce = s;
            });
        }
    }
}