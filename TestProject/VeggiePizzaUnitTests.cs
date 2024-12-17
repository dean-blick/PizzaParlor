namespace PizzaParlor.DataTests
{
    /// <summary>
    /// A class to test the VeggiePizza class
    /// </summary>
    public class VeggiePizzaUnitTests
    {

        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            VeggiePizza p = new VeggiePizza();
            Assert.Equal("Veggie Pizza", p.Name);
            Assert.Equal("All the veggies", p.Description);
            Assert.True(p.HasTopping(Topping.Olives));
            Assert.True(p.HasTopping(Topping.Peppers));
            Assert.True(p.HasTopping(Topping.Onions));
            Assert.True(p.HasTopping(Topping.Mushrooms));
        }

        /// <summary>
        /// Ensures correct pricing depending on size and crust
        /// </summary>
        /// <param name="s">the size of the pizza</param>
        /// <param name="c">the crust of the pizza</param>
        /// <param name="expected">the expected price</param>
        [Theory]
        [InlineData(Size.Medium, Crust.Original, 12.99)]
        [InlineData(Size.Small, Crust.Original, 10.99)]
        [InlineData(Size.Large, Crust.Original, 14.99)]
        [InlineData(Size.Small, Crust.DeepDish, 11.99)]
        [InlineData(Size.Medium, Crust.DeepDish, 13.99)]
        [InlineData(Size.Large, Crust.DeepDish, 15.99)]
        [InlineData(Size.Medium, Crust.Thin, 12.99)]
        [InlineData(Size.Large, Crust.Thin, 14.99)]
        public void PriceTest(Size s, Crust c, decimal expected)
        {
            VeggiePizza p = new VeggiePizza();
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
            Assert.IsAssignableFrom<Pizza>(new VeggiePizza());
            Assert.IsAssignableFrom<IMenuItem>(new VeggiePizza());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            VeggiePizza b = new VeggiePizza();
            Assert.Equal("Veggie Pizza", b.ToString());
        }

        //All settable properties inherited by Pizza.cs which is tested for.
    }
}
