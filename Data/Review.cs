using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Stores the outline for a review so that it can be deserialized from JSON
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Stores the text of the review
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// Stores the DateTime
        /// </summary>
        public DateTime DateTime { get; init; }

        /// <summary>
        /// Sets the DateTime to be the current DateTime
        /// </summary>
        public Review(string text)
        {
            Text = text;
            DateTime = DateTime.Now;
        }

    }
}
