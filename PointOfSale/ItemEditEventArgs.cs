using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// A custom event to handle the editing of an item
    /// </summary>
    public class ItemEditEventArgs : RoutedEventArgs
    {
        //Set the current data context of the control for that item type to the new item of that type or
        //the selected item of that type

        //Invoked by button in the menuitemselection control and bubbles up to the main window.
        //Main window changes visibility of the needed controls

        /// <summary>
        /// The window that should be on display
        /// </summary>
        public IMenuItem SelectedMenuItem { get; private set; }

        /// <summary>
        /// Constructs the custom event args
        /// </summary>
        /// <param name="menuItem"></param>
        public ItemEditEventArgs(IMenuItem menuItem)
        {
            SelectedMenuItem = menuItem;
        }
    }
}
