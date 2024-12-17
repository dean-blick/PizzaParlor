using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
	/// <summary>
	/// Class for the menu
	/// </summary>
	public static class Menu
	{
		/// <summary>
		/// Returns the pizzas on the menu
		/// </summary>
		public static IEnumerable<IMenuItem> Pizzas
		{
			get
			{
                List<IMenuItem> pizzas = new List<IMenuItem>();
                foreach (Size s in Enum.GetValues(typeof(Size)))
                {
                    foreach (Crust c in Enum.GetValues(typeof(Crust)))
                    {
                        Pizza p = new Pizza();
                        SupremePizza supreme = new SupremePizza();
                        MeatsPizza meats = new MeatsPizza();
                        HawaiianPizza hawaiian = new HawaiianPizza();
                        VeggiePizza veggie = new VeggiePizza();
                        p.PizzaSize = s;
                        p.PizzaCrust = c;
                        supreme.PizzaSize = s;
                        supreme.PizzaCrust = c;
                        meats.PizzaSize = s;
                        meats.PizzaCrust = c;
                        hawaiian.PizzaSize = s;
                        hawaiian.PizzaCrust = c;
                        veggie.PizzaSize = s;
                        veggie.PizzaCrust = c;
                        pizzas.Add(p);
                        pizzas.Add(supreme);
                        pizzas.Add(meats);
                        pizzas.Add(hawaiian);
                        pizzas.Add(veggie);
                    }
                }
				return pizzas;
            }
		}

		/// <summary>
		/// Returns the sides for the menu
		/// </summary>
		public static IEnumerable<IMenuItem> Sides
		{
			get
			{
                List<IMenuItem> sides = new List<IMenuItem>();
                Breadsticks b = new Breadsticks();
                Breadsticks bc = new Breadsticks();
                bc.Cheese = true;
                sides.Add(b);
                sides.Add(bc);

                CinnamonSticks cinnamon = new CinnamonSticks();
                CinnamonSticks cinnamonNoFrosting = new CinnamonSticks();
                cinnamonNoFrosting.Frosting = false;
                sides.Add(cinnamon);
                sides.Add(cinnamonNoFrosting);

                sides.Add(new GarlicKnots());

                foreach (WingSauce sauce in Enum.GetValues(typeof(WingSauce)))
                {
                    Wings w = new Wings();
                    Wings wBone = new Wings();
                    w.Sauce = sauce;
                    wBone.Sauce = sauce;
                    wBone.BoneIn = false;
                    sides.Add(w);
                    sides.Add(wBone);
                }
                return sides;
            }
		}
		
		/// <summary>
		/// Returns the available drinks
		/// </summary>
		public static IEnumerable<IMenuItem> Drinks
		{
			get
			{
                List<IMenuItem> drinks = new List<IMenuItem>();
                foreach (SodaFlavor f in Enum.GetValues(typeof(SodaFlavor)))
                {
                    foreach (Size size in Enum.GetValues(typeof(Size)))
                    {
                        Soda s = new Soda();
                        s.DrinkType = f;
                        s.DrinkSize = size;
                        drinks.Add(s);
                    }
                }

                drinks.Add(new IcedTea());
                return drinks;
            }
		}

		/// <summary>
		/// returns the full list of menu items
		/// </summary>
		public static IEnumerable<IMenuItem> FullMenu
		{
			get
			{
				List<IMenuItem> fullmenu = new List<IMenuItem>();
				foreach(IMenuItem item in Pizzas) fullmenu.Add(item);
				foreach(IMenuItem item in Sides) fullmenu.Add(item);
				foreach(IMenuItem item in Drinks) fullmenu.Add(item);
				return fullmenu;
			}
		}

        /// <summary>
        /// Gets all of the items where the name or special instructions contains the words in the given string
        /// </summary>
        /// <param name="terms">the string to check against</param>
        /// <returns> an IEnumerable IMenuItem containing the items </returns>
        public static IEnumerable<IMenuItem> Search(string? terms)
        {
            if (terms == null) return FullMenu;
            string[] words = terms.Split(' ');
            return FullMenu.Where(item => words.All(word => item.SpecialInstructions.Any(instruction => instruction.Contains(word, StringComparison.CurrentCultureIgnoreCase)) || item.Name.Contains(word, StringComparison.CurrentCultureIgnoreCase)));
        }

        /// <summary>
        /// Filters the items by the calories
        /// </summary>
        /// <param name="items">the items</param>
        /// <param name="min">the min</param>
        /// <param name="max">the max</param>
        /// <returns>the filtered items</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> items, uint? min, uint? max)
        {
            // TODO: Filter items
            // Both minimum and maximum specified
            if (min == null && max == null) return items;
            if(max == null)
            {
                return FullMenu.Where(item => item.CaloriesTotal >= min);
            }
            if (min == null)
            {
                return FullMenu.Where(item => item.CaloriesTotal <= max);
            }
            return FullMenu.Where(item => item.CaloriesTotal >= min && item.CaloriesTotal <= max);
        }

        /// <summary>
        /// Filters the items by the given min and max price
        /// </summary>
        /// <param name="items">the items to search from </param>
        /// <param name="min">the min</param>
        /// <param name="max">the max</param>
        /// <returns>the filtered items</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> items, decimal? min, decimal? max)
        {
            // TODO: Filter items
            // Both minimum and maximum specified
            if (min == null && max == null) return items;
            if (max == null)
            {
                return FullMenu.Where(item => item.Price >= min);
            }
            if (min == null)
            {
                return FullMenu.Where(item => item.Price <= max);
            }
            return FullMenu.Where(item => item.Price >= min && item.Price <= max);
        }
    }
}
