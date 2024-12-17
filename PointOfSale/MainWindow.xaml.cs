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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDataContextToNewOrder();
            MenuItemSelectionDisplay.ItemEdit += MainWindowDisplay.OnItemEdit;
            OrderSummaryDisplay.ItemEdit += MainWindowDisplay.OnItemEdit;
            ActiveWindow = MenuItemSelectionDisplay;
            PaymentDisplay.ButtonClicked += MainWindowDisplay.FinalizeOrder;
        }

        /// <summary>
        /// Holds the active window
        /// </summary>
        public UserControl ActiveWindow { get; set; }

        /// <summary>
        /// Sets the main menu to be the active window
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Routedeventargs object</param>
        public void BackToMenu(object? sender, RoutedEventArgs e)
        {
            ActiveWindow.Visibility = Visibility.Hidden;
            MenuItemSelectionDisplay.Visibility = Visibility.Visible;
            ActiveWindow = MenuItemSelectionDisplay;
            CompleteOrderButton.IsEnabled = true;
            CancelOrderButton.IsEnabled = true;
            OrderSummaryDisplay.IsEnabled = true;
        }
        /// <summary>
        /// Finalizes order
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">routedeventargs</param>
        public void FinalizeOrder(object? sender, RoutedEventArgs e)
        {
            ActiveWindow.Visibility = Visibility.Hidden;
            MenuItemSelectionDisplay.Visibility = Visibility.Visible;
            ActiveWindow = MenuItemSelectionDisplay;
            CompleteOrderButton.IsEnabled = true;
            CancelOrderButton.IsEnabled = true;
            OrderSummaryDisplay.IsEnabled = true;
            SetDataContextToNewOrder();

        }

        /// <summary>
        /// Runs when a button is clicked to edit an item or add a new item
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event argument for the ItemEdit event</param>
        public void OnItemEdit(object? sender, ItemEditEventArgs e)
        {
            
            if (e.SelectedMenuItem == null)
            {
                ActiveWindow.Visibility = Visibility.Hidden;
                ActiveWindow = MenuItemSelectionDisplay;
                ActiveWindow.Visibility = Visibility.Visible;
                return;
            }
            ActiveWindow.Visibility = Visibility.Hidden;
            switch (e.SelectedMenuItem?.ToString())
            {

                case "Breadsticks":
                    BreadsticksDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = BreadsticksDisplay;
                    BreadsticksDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Cinnamon Sticks":
                    CinnamonsticksDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = CinnamonsticksDisplay;
                    CinnamonsticksDisplay.DataContext= e.SelectedMenuItem;
                    break;
                case "Garlic Knots":
                    GarlicKnotsDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = GarlicKnotsDisplay;
                    GarlicKnotsDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Wings":
                    WingsDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = WingsDisplay;
                    WingsDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Build-Your-Own-Pizza":
                    PizzaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = PizzaDisplay;
                    PizzaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Hawaiian Pizza":
                    HawaiianPizzaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = HawaiianPizzaDisplay;
                    HawaiianPizzaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Supreme Pizza":
                    SupremePizzaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = SupremePizzaDisplay;
                    SupremePizzaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Meats Pizza":
                    MeatsPizzaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = MeatsPizzaDisplay;
                    MeatsPizzaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Veggie Pizza":
                    VeggiePizzaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = VeggiePizzaDisplay;
                    VeggiePizzaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Soda":
                    SodaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = SodaDisplay;
                    SodaDisplay.DataContext = e.SelectedMenuItem;
                    break;
                case "Iced Tea":
                    IcedTeaDisplay.Visibility = Visibility.Visible;
                    ActiveWindow = IcedTeaDisplay;
                    IcedTeaDisplay.DataContext = e.SelectedMenuItem;
                    break;
            }
        }

        /// <summary>
        /// Cancels the current order
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">RoutedEventArgs</param>
        public void OnCancelOrderButtonClick(object sender, RoutedEventArgs e)
        {
            SetDataContextToNewOrder();
        }

        /// <summary>
        /// Sets the data context to a new order and sets the current order of the summary display
        /// </summary>
        public void SetDataContextToNewOrder()
        {
            Order o = new Order();
            DataContext = o;
            OrderSummaryDisplay.currentOrder = o;
        }

        /// <summary>
        /// Changes to the payment display, disables certain controls, sets data context
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">routedeventargs</param>
        public void OnCompleteOrderButtonClick(object sender, RoutedEventArgs e)
        {
            PaymentDisplay.DataContext = new PaymentViewModel((Order)DataContext);
            ActiveWindow.Visibility = Visibility.Hidden;
            ActiveWindow = PaymentDisplay;
            ActiveWindow.Visibility = Visibility.Visible;
            CancelOrderButton.IsEnabled = false;
            CompleteOrderButton.IsEnabled = false;
            OrderSummaryDisplay.IsEnabled = false;
        }
    }
}
