namespace PizzaParlor.DataTests
{
    /// <summary>
    /// A class to test the MeatsPizza class
    /// </summary>
    public class MeatsPizzaUnitTests
    {

        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            MeatsPizza p = new MeatsPizza();
            Assert.Equal("Meats Pizza", p.Name);
            Assert.Equal("All the meats", p.Description);
            Assert.True(p.HasTopping(Topping.Sausage));
            Assert.True(p.HasTopping(Topping.Pepperoni));
            Assert.True(p.HasTopping(Topping.Ham));
            Assert.True(p.HasTopping(Topping.Bacon));
        }

        /// <summary>
        /// Ensures correct pricing depending on size and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, 15.99)]
        [InlineData(Size.Small, Crust.Original, 13.99)]
        [InlineData(Size.Large, Crust.Original, 17.99)]
        [InlineData(Size.Small, Crust.DeepDish, 14.99)]
        [InlineData(Size.Medium, Crust.DeepDish, 16.99)]
        [InlineData(Size.Large, Crust.DeepDish, 18.99)]
        [InlineData(Size.Medium, Crust.Thin, 15.99)]
        [InlineData(Size.Large, Crust.Thin, 17.99)]
        public void PriceTest(Size s, Crust c, decimal expected)
        {
            MeatsPizza p = new MeatsPizza();
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
            Assert.IsAssignableFrom<Pizza>(new MeatsPizza());
            Assert.IsAssignableFrom<IMenuItem>(new MeatsPizza());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            MeatsPizza b = new MeatsPizza();
            Assert.Equal("Meats Pizza", b.ToString());
        }

        //All settable properties inherited by Pizza.cs which is tested for.
    }
}
