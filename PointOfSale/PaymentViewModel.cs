using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// The viewmodel for the payment control
    /// </summary>
    public class PaymentViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the order that the viewmodel gets the info from
        /// </summary>
        private Order _order;

        /// <summary>
        /// Stores the total to be paid
        /// </summary>
        public decimal Total { get; set; } 

        /// <summary>
        /// Stores the subtotal for the order
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Stores the tax owed
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// private backing field for the Paid property
        /// </summary>
        private decimal _paid;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Stores how much the customer paid for the order
        /// </summary>
        public decimal Paid
        {
            get
            {
                return _paid;
            }
            set
            {
                if(value >= Total)
                {
                    _paid = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Receipt)));
                }
            }
        }

        /// <summary>
        /// Calculates the change the customer is owed
        /// </summary>
        public decimal Change
        {
            get
            {
                return Paid - Total;
            }
        }

        /// <summary>
        /// Gets the string that is the customer's receipt
        /// </summary>
        public string Receipt
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("Order number {0}", Order.Number));
                sb.AppendLine(String.Format("Placed at: {0}", _order.PlacedAt));
                foreach(IMenuItem item in _order)
                {
                    sb.AppendLine(String.Format("{0}     {1:C}", item.Name, item.Price));
                    foreach(string s in item.SpecialInstructions)
                    {
                        sb.AppendLine("     " + s);
                    }
                }
                sb.AppendLine(String.Format("Subtotal: {0}", Subtotal));
                sb.AppendLine(String.Format("Tax: {0}", Tax));
                sb.AppendLine(String.Format("Total: {0}", Total));
                sb.AppendLine(String.Format("Amount Paid: {0}", Paid));
                sb.AppendLine(String.Format("Change: {0}", Change));
                sb.AppendLine("<--------------------------------->");
                return sb.ToString();
            }
        }



        public PaymentViewModel(Order o) 
        { 
            _order = o;
            Paid = _order.Total;
            Total = _order.Total;
            Subtotal = _order.Subtotal;
            Tax = _order.Tax;
        }
    }
}
