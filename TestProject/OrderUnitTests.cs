using Newtonsoft.Json.Bson;
using PizzaParlor.Data;
using System.ComponentModel;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Unit tests for the order class
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// Verifies the default value of all properties
        /// </summary>
        [Fact]
        public void DefaultsTest()
        {
            Order o = new Order();
            Assert.Equal(new List<IMenuItem> { }, o.menuItems); //menuItems property
            Assert.Empty(o); //Count property
            Assert.False(o.IsReadOnly); //Isreadonly property
        }

        /// <summary>
        /// Ensures items can be added to the order with the Add function
        /// </summary>
        [Fact]
        public void AddTest()
        {
            Order o = new Order();
            MockMenuItem menuItem = new MockMenuItem();
            o.Add(menuItem);
            o.Add(new MockMenuItem());
            Assert.Equal(2, o.Count);
            Assert.Contains(menuItem, o);
        }

        /// <summary>
        /// Ensures the order can be cleared
        /// </summary>
        [Fact]
        public void ClearTest()
        {
            Order o = new Order();
            o.Add(new MockMenuItem());
            o.Add(new MockMenuItem());
            o.Clear();
            Assert.Empty(o);
            Assert.Equal(new List<IMenuItem> { }, o.menuItems);
        }

        /// <summary>
        /// Ensures the contains function works properly
        /// </summary>
        [Fact]
        public void ContainsTest()
        {
            Order o = new Order();
            MockMenuItem i = new MockMenuItem();
            i.CaloriesTotal = 1000;
            i.Price = 10000;
            i.Description = "Test test test test";
            o.Add(new MockMenuItem());
            o.Add(new MockMenuItem());
            o.Add(new MockMenuItem());
            o.Add(i);
            o.Add(new MockMenuItem());
            Assert.True(o.Contains(i));
        }

        /// <summary>
        /// Ensures the copyto function works properly
        /// </summary>
        [Fact]
        public void CopyToTest()
        {
            Order o = new Order();
            IMenuItem[] arr = new IMenuItem[4];
            MockMenuItem a = new MockMenuItem();
            MockMenuItem b = new MockMenuItem();
            MockMenuItem c = new MockMenuItem();
            MockMenuItem d = new MockMenuItem();
            o.Add(a);
            o.Add(b);
            o.Add(c);
            o.Add(d);
            o.CopyTo(arr, 0);
            Assert.Equal(new IMenuItem[] { a, b, c, d }, arr);
        }

        /// <summary>
        /// Ensures the get enumerator function works properly
        /// </summary>
        [Fact]
        public void GetEnumeratorTest()
        {
            Order o = new Order();
            MockMenuItem a = new MockMenuItem();
            MockMenuItem b = new MockMenuItem();
            o.Add(a);
            o.Add(b);
            int i = 0;
            foreach (IMenuItem item in o)
            {
                if (i == 0) Assert.Equal(a, item);
                if (i == 1) Assert.Equal(b, item);
                i++;
            }
            Assert.Equal(2, i);
        }

        /// <summary>
        /// Ensures the Remove function works properly
        /// </summary>
        [Fact]
        public void RemoveTest()
        {
            Order o = new Order();
            MockMenuItem m = new MockMenuItem();
            o.Add(m);
            o.Remove(m);
            Assert.Empty(o);
        }

        /// <summary>
        /// Ensures that the subtotal function works properly
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// Ensures the taxrate property works as intended
        /// </summary>
        [Fact]
        public void TaxRateTest()
        {
            Order order = new Order();
            Assert.Equal(0.0915m, order.TaxRate);
            order.TaxRate = 0.01m;
            Assert.Equal(0.01m, order.TaxRate);
        }

        /// <summary>
        /// Ensures that the total property works properly
        /// </summary>
        [Fact]
        public void TaxShouldReflectItemPricesAndTaxRate()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            order.TaxRate = 0.1m;
            Assert.Equal(6.50m * 0.1m, order.Tax);
        }

        /// <summary>
        /// Ensures the total property works properly
        /// </summary>
        [Fact]
        public void TotalShouldReflectItemPricesAndTaxRate()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            order.TaxRate = 0.1m;
            Assert.Equal(6.50m + (6.50m * 0.1m), order.Total);
        }

        #region PropertyEventTests

        /// <summary>
        /// Ensures the PropertyChanged event works properly for the tax rate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () =>
            {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event works properly for the tax rate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfTaxPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event works properly for the tax rate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfTotalPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event for the total works properly when adding and removing items
        /// </summary>
        [Fact]
        public void AddAndRemoveItemShouldNotifyTotalPropertyChange()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Add(p);
            });
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Remove(p);
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event for the total works properly when clearing the order
        /// </summary>
        [Fact]
        public void ClearShouldNotifyTotalPropertyChange()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Add(p);
            });
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Clear();
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event for the subtotal works properly when adding and removing items
        /// </summary>
        [Fact]
        public void AddAndRemoveItemShouldNotifySubTotalPropertyChange()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Add(p);
            });
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Remove(p);
            });
        }

        /// <summary>
        /// Ensures the PropertyChanged event for the subtotal works properly when clearing the order
        /// </summary>
        [Fact]
        public void ClearShouldNotifySubTotalPropertyChange()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Add(p);
            });
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Clear();
            });
        }

        /// <summary>
        /// Ensures that Order implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        #endregion


        /// <summary>
        /// Asserts changing pizza size invokes change in correct properties
        /// </summary>
        /// <param name="size">size to test for</param>
        /// <param name="propertyName">property to test for</param>
        [Theory]
        [InlineData(Size.Small, "Total")]
        [InlineData(Size.Medium, "Total")]
        [InlineData(Size.Large, "Total")]
        [InlineData(Size.Small, "Subtotal")]
        [InlineData(Size.Medium, "Subtotal")]
        [InlineData(Size.Large, "Subtotal")]
        [InlineData(Size.Small, "Tax")]
        [InlineData(Size.Medium, "Tax")]
        [InlineData(Size.Large, "Tax")]
        public void PizzaSizeChangeShouldNotifyOrderPropertyChanges(Size size, string propertyName)
        {
            Order o = new Order();
            Pizza p = new Pizza();
            o.Add(p);
            Assert.PropertyChanged(o, propertyName, () =>
            {
                p.PizzaSize = size;
            });
        }

        /// <summary>
        /// Asserts changing pizza size invokes change in correct properties
        /// </summary>
        /// <param name="crust">crust to test for</param>
        /// <param name="propertyName">property to test for</param>
        [Theory]
        [InlineData(Crust.Original, "Total")]
        [InlineData(Crust.Thin, "Total")]
        [InlineData(Crust.DeepDish, "Total")]
        [InlineData(Crust.Original, "Subtotal")]
        [InlineData(Crust.Thin, "Subtotal")]
        [InlineData(Crust.DeepDish, "Subtotal")]
        [InlineData(Crust.Original, "Tax")]
        [InlineData(Crust.Thin, "Tax")]
        [InlineData(Crust.DeepDish, "Tax")]
        public void PizzaCrustChangeShouldNotifyOrderPropertyChanges(Crust crust, string propertyName)
        {
            Order o = new Order();
            Pizza p = new Pizza();
            o.Add(p);
            Assert.PropertyChanged(o, propertyName, () =>
            {
                p.PizzaCrust = crust;
            });
        }

        /// <summary>
        /// Changing soda size should notify correct properties
        /// </summary>
        /// <param name="size">size to change to</param>
        /// <param name="propertyName">property that should change</param>
        [Theory]
        [InlineData(Size.Small, "Total")]
        [InlineData(Size.Medium, "Total")]
        [InlineData(Size.Large, "Total")]
        [InlineData(Size.Small, "Subtotal")]
        [InlineData(Size.Medium, "Subtotal")]
        [InlineData(Size.Large, "Subtotal")]
        [InlineData(Size.Small, "Tax")]
        [InlineData(Size.Medium, "Tax")]
        [InlineData(Size.Large, "Tax")]
        public void ChangingSodaSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            Order o = new Order();
            Soda soda = new();
            o.Add(soda);
            Assert.PropertyChanged(o, propertyName, () => {
                soda.DrinkSize = size;
            });
        }
        /// <summary>
        /// Changing soda flavor should notify correct properties
        /// </summary>
        /// <param name="f">flavor to change to</param>
        /// <param name="propertyName">property that should change</param>
        [Theory]
        [InlineData(SodaFlavor.DietCoke, "Total")]
        [InlineData(SodaFlavor.RootBeer, "Total")]
        [InlineData(SodaFlavor.Sprite, "Total")]
        [InlineData(SodaFlavor.DrPepper, "Subtotal")]
        [InlineData(SodaFlavor.DietCoke, "Subtotal")]
        [InlineData(SodaFlavor.Coke, "Subtotal")]
        [InlineData(SodaFlavor.RootBeer, "Tax")]
        [InlineData(SodaFlavor.Sprite, "Tax")]
        [InlineData(SodaFlavor.DietCoke, "Tax")]
        public void ChangingSodaFlavorShouldNotifyOfPropertyChanges(SodaFlavor f, string propertyName)
        {
            Order o = new Order();
            Soda soda = new();
            o.Add(soda);
            Assert.PropertyChanged(o, propertyName, () => {
                soda.DrinkType = f;
            });
        }

        /// <summary>
        /// Changing side count should notify correct properties
        /// </summary>
        /// <param name="c">count to change to</param>
        /// <param name="propertyName">property that should change</param>
        [Theory]
        [InlineData(10, "Total")]
        [InlineData(12, "Total")]
        [InlineData(8, "Total")]
        [InlineData(9, "Subtotal")]
        [InlineData(4, "Subtotal")]
        [InlineData(5, "Subtotal")]
        [InlineData(6, "Tax")]
        [InlineData(7, "Tax")]
        [InlineData(11, "Tax")]
        public void ChangingSideCountShouldNotifyOfPropertyChanges(uint c, string propertyName)
        {
            Order o = new Order();
            Breadsticks b = new Breadsticks();
            o.Add(b);
            Assert.PropertyChanged(o, propertyName, () => {
                b.SideCount = c;
            });
            Wings w = new Wings();
            o.Add(w);
            Assert.PropertyChanged(o, propertyName, () => {
                w.SideCount = c;
            });
            CinnamonSticks cin = new CinnamonSticks();
            o.Add(cin);
            Assert.PropertyChanged(o, propertyName, () => {
                cin.SideCount = c;
            });
            GarlicKnots g = new GarlicKnots();
            o.Add(g);
            Assert.PropertyChanged(o, propertyName, () => {
                g.SideCount = c;
            });
        }

        /// <summary>
        /// Changing side booleans should notify correct properties
        /// </summary>
        /// <param name="boo">boolean to test</param>
        /// <param name="propertyName">property that should change</param>
        [Theory]
        [InlineData(true, "Total")]
        [InlineData(false, "Total")]
        [InlineData(true, "Subtotal")]
        [InlineData(false, "Subtotal")]
        [InlineData(true, "Tax")]
        [InlineData(false, "Tax")]
        public void ChangingSideBoolShouldNotifyOfPropertyChanges(bool boo, string propertyName)
        {
            Order o = new Order();
            Breadsticks b = new Breadsticks();
            o.Add(b);
            Assert.PropertyChanged(o, propertyName, () => {
                b.Cheese = boo;
            });
            Wings w = new Wings();
            o.Add(w);
            Assert.PropertyChanged(o, propertyName, () => {
                w.BoneIn = boo;
            });
            CinnamonSticks cin = new CinnamonSticks();
            o.Add(cin);
            Assert.PropertyChanged(o, propertyName, () => {
                cin.Frosting = boo;
            });
        }

    }
}
