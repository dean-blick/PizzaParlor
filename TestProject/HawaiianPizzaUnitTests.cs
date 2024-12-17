namespace PizzaParlor.DataTests
{
    /// <summary>
    /// A class to test the HawaiianPizza class
    /// </summary>
    public class HawaiianPizzaUnitTests
    {

        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            HawaiianPizza p = new HawaiianPizza();
            Assert.Equal("Hawaiian Pizza", p.Name);
            Assert.Equal("The pizza with pineapple", p.Description);
            Assert.True(p.HasTopping(Topping.Ham));
            Assert.True(p.HasTopping(Topping.Pineapple));
            Assert.True(p.HasTopping(Topping.Onions));
        }

        /// <summary>
        /// Ensures correct pricing depending on size and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, 13.99)]
        [InlineData(Size.Small, Crust.Original, 11.99)]
        [InlineData(Size.Large, Crust.Original, 15.99)]
        [InlineData(Size.Small, Crust.DeepDish, 12.99)]
        [InlineData(Size.Medium, Crust.DeepDish, 14.99)]
        [InlineData(Size.Large, Crust.DeepDish, 16.99)]
        [InlineData(Size.Medium, Crust.Thin, 13.99)]
        [InlineData(Size.Large, Crust.Thin, 15.99)]
        public void PriceTest(Size s, Crust c, decimal expected)
        {
            HawaiianPizza p = new HawaiianPizza();
            p.PizzaSize = s;
            p.PizzaCrust = c;
            Assert.Equal(expected, p.Price);
        }


        /// <summary>
        /// Ensures the class can be casted
        /// </summary>
        [Fact]
        public void CastingTest()
        {
            Assert.IsAssignableFrom<Pizza>(new HawaiianPizza());
            Assert.IsAssignableFrom<IMenuItem>(new HawaiianPizza());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            HawaiianPizza b = new HawaiianPizza();
            Assert.Equal("Hawaiian Pizza", b.ToString());
        }

        //All settable properties inherited by Pizza.cs which is tested for.
    }
}
