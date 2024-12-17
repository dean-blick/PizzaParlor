using System;
using System.Collections.Generic;
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
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public event EventHandler<ItemEditEventArgs>? ItemEdit;

        /// <summary>
        /// the current order
        /// </summary>
        public Order? currentOrder;

        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the event when the item is selected in the listview
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">selectionchangedeventargs object</param>
        private void ListView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            IMenuItem item = (IMenuItem)OrderListView.SelectedItem;
            ItemEdit?.Invoke(this, new ItemEditEventArgs(item));
        }

        /// <summary>
        /// Removes the given item from the order
        /// </summary>
        /// <param name="sender">the button that is clicked</param>
        /// <param name="e">routedeventargs</param>
        public void OnRemoveItemFromOrder(object? sender, RoutedEventArgs e)
        {

            if(sender is FrameworkElement fr)
            {
                if(fr.DataContext is IMenuItem item)
                {
                    currentOrder?.Remove(item);
                    IMenuItem? i = null;
                    ItemEdit?.Invoke(this, new ItemEditEventArgs(i));
                }
            }
            
        }
    }
}
