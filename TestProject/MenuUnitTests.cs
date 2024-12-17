using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Tests the menu class
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// Ensures correct number of items for each category
        /// </summary>
        [Fact]
        public void MenuUnitTest()
        {
            List<string> types = new List<string>();
            List<Crust> crusts = new List<Crust>();
            List<Size> sizes = new List<Size>();
            foreach(Pizza item in Menu.Pizzas)
            {
                if(!types.Contains(item.Name)) types.Add(item.Name);
                if(!crusts.Contains(item.PizzaCrust)) crusts.Add(item.PizzaCrust);
                if(!sizes.Contains(item.PizzaSize)) sizes.Add(item.PizzaSize);
            }
            Assert.Equal(45, types.Count * sizes.Count * crusts.Count);

            int numItems = 0;
            List<Breadsticks> breadsticks = new List<Breadsticks>();
            List<CinnamonSticks> cinnamonSticks = new List<CinnamonSticks>();
            List<GarlicKnots> garlicknots = new List<GarlicKnots>();
            List<Wings> wings = new List<Wings>();
            foreach(IMenuItem item in Menu.Sides)
            {
                numItems++;
                if(item.Name == "Breadsticks")
                {
                    breadsticks.Add((Breadsticks)item);
                }
                if(item.Name == "Cinnamon Sticks")
                {
                    cinnamonSticks.Add((CinnamonSticks)item);
                }
                if(item.Name == "Garlic Knots")
                {
                    garlicknots.Add((GarlicKnots)item);
                }
                if(item.Name == "Wings")
                {
                    wings.Add((Wings)item);
                }
            }
            Assert.Equal(2, breadsticks.Count);
            Assert.Equal(2, cinnamonSticks.Count);  
            Assert.Equal(1, garlicknots.Count);
            Assert.Equal(8, wings.Count);

            List<Drink> drinks = new List<Drink>();
            foreach(Drink d in Menu.Drinks)
            {
                drinks.Add(d);
            }
            Assert.Equal(16, drinks.Count);
        }

        /// <summary>
        /// Ensures Full Menu When All Searches are null
        /// </summary>
        [Fact]
        public void EnsureFullMenuWhenAllSearchNullTest()
        {
            IEnumerable<IMenuItem> items = new List<IMenuItem>();
            items = Menu.Search(null);
            items = Menu.FilterByPrice(items, null, null);
            items = Menu.FilterByCalories(items, null, null);
            Assert.Equal(Menu.FullMenu.Count(), items.Count());
        }

        /// <summary>
        /// EnsureCorrectNumberOfItemsWhenFilteringByPrice
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <param name="expected">number</param>
        [Theory]
        [InlineData(1.00d, 10.00d, 34)]
        [InlineData(4.00d, 5.00d, 0)]
        [InlineData(null, 10.00d, 34)]
        [InlineData(1.00d, null, 74)]
        [InlineData(7.00d, 1.00d, 0)]
        [InlineData(10.00d, 20.00d, 40)]
        public void EnsureCorrectNumberOfItemsWhenFilteringByPrice(double? min, double? max, int expected)
        {
            IEnumerable<IMenuItem> items = Menu.FullMenu;
            items = Menu.FilterByPrice(items, (decimal?)min, (decimal?)max);
            Assert.Equal(expected, items.Count());
        }


        /// <summary>
        /// EnsureCorrectNumberOfItemsWhenFilteringByCalories
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <param name="expected">number</param>
        [Theory]
        [InlineData(0, 0, 3)]
        [InlineData(300, 1000, 9)]
        [InlineData(null, 100, 3)]
        [InlineData(1000, null, 49)]
        [InlineData(500, 800, 4)]
        [InlineData(1000, 0, 0)]
        public void EnsureCorrectNumberOfItemsWhenFilteringByCalories(int? min, int? max, int expected)
        {
            IEnumerable<IMenuItem> items = Menu.FullMenu;
            items = Menu.FilterByCalories(items, (uint?)min, (uint?)max);
            Assert.Equal(expected, items.Count());
        }
    }
}
