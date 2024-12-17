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
    /// Interaction logic for ItemCountControl.xaml
    /// </summary>
    public partial class ItemCountControl : UserControl
    {
        /// <summary>
        /// placeholder
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }

        /// <summary>
        /// placeholder
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(ItemCountControl), new PropertyMetadata(1u));

        public ItemCountControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// placeholder
        /// </summary>
        /// <param name="sender">placeholder</param>
        /// <param name="e">placeholder</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count < uint.MaxValue) Count++;
        }

        /// <summary>
        /// placeholder
        /// </summary>
        /// <param name="sender">placeholder</param>
        /// <param name="e">placeholder</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count > 0) Count--;
        }
    }
}
