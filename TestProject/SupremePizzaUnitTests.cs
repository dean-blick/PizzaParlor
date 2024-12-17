namespace PizzaParlor.DataTests
{
    /// <summary>
    /// A class to test the SupremePizza class
    /// </summary>
    public class SupremePizzaUnitTests
    {

        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            SupremePizza p = new SupremePizza();
            Assert.Equal("Supreme Pizza", p.Name);
            Assert.Equal("Your standard supreme with meats and veggies", p.Description);
            Assert.True(p.HasTopping(Topping.Sausage));
            Assert.True(p.HasTopping(Topping.Pepperoni));
            Assert.True(p.HasTopping(Topping.Olives));
            Assert.True(p.HasTopping(Topping.Peppers));
            Assert.True(p.HasTopping(Topping.Onions));
            Assert.True(p.HasTopping(Topping.Mushrooms));
            Assert.False(p.HasTopping(Topping.Pineapple));
        }

        /// <summary>
        /// Ensures correct pricing depending on size and crust
        /// Ensures the class can be casted
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
            SupremePizza p = new SupremePizza();
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
            Assert.IsAssignableFrom<Pizza>(new SupremePizza());
            Assert.IsAssignableFrom<IMenuItem>(new SupremePizza());
        }

        /// <summary>
        /// Asserts the tostring method returns the name
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            SupremePizza b = new SupremePizza();
            Assert.Equal("Supreme Pizza", b.ToString());
        }

        //All settable properties inherited by Pizza.cs which is tested for.
    }
}
