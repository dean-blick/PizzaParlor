using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }

        public event EventHandler<ItemEditEventArgs>? ButtonClicked;

        /// <summary>
        /// Finalize payment button
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">routedeventargs</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.AppendAllText("../receipts.txt", ((PaymentViewModel)DataContext).Receipt);
            ButtonClicked?.Invoke(this, new ItemEditEventArgs(new Pizza()));
        }
    }
}
