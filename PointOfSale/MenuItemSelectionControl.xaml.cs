using PizzaParlor.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {

        public event EventHandler<ItemEditEventArgs>? ItemEdit;

        /// <summary>
        /// Constructor for the usercontrol
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddBuildYourOwnPizzaClick(object sender, RoutedEventArgs e)
        {
            if(DataContext is Order list)
            {
                Pizza p = new Pizza();
                list.Add(p);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(p));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddBreadsticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                Breadsticks b = new Breadsticks();
                list.Add(b);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(b));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddSodaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                Soda s = new Soda();
                list.Add(s);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(s));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddSupremeClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                SupremePizza p = new SupremePizza();
                list.Add(p);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(p));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddGarlicKnotsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                GarlicKnots g = new GarlicKnots();
                list.Add(g);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(g));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddIcedTeaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                IcedTea i = new IcedTea();
                list.Add(i);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(i));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddMeatsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                MeatsPizza p = new MeatsPizza();
                list.Add(p);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(p));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddCinnamonSticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                CinnamonSticks c = new CinnamonSticks();
                list.Add(c);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(c));
            }
        }

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddVeggieClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                VeggiePizza p = new VeggiePizza();
                list.Add(p);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(p));
            }
        }

        
        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddWingsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                Wings w = new Wings();
                list.Add(w);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(w));
            }
        }
        

        /// <summary>
        /// Adds the given menu item to the order list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public void AddHawaiianClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
            {
                HawaiianPizza p = new HawaiianPizza();
                list.Add(p);
                ItemEdit?.Invoke(this, new ItemEditEventArgs(p));
            }
        }
    }
}
