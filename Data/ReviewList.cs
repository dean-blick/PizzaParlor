using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaParlor.Data
{
	public static class ReviewList
	{
		/// <summary>
		/// private backing field for the Reviews property
		/// </summary>
		private static List<Review> _reviews;
		static ReviewList()
		{
			if (File.Exists("reviews.json"))
			{
				string json = File.ReadAllText("reviews.json");

				_reviews = JsonConvert.DeserializeObject<List<Review>>(json);
			}
			if (_reviews == null)
			{
				_reviews = new List<Review>();
			}
		}

		/// <summary>
		/// Makes the reviews publicly available
		/// </summary>
		public static IEnumerable<Review> Reviews => _reviews;

		/// <summary>
		/// Adds the review to the file
		/// </summary>
		/// <param name="n"></param>
		public static void AddReview(Review n)
		{
			if (n != null)
			{
				_reviews.Add(n);


				File.WriteAllText("reviews.json", JsonConvert.SerializeObject(Reviews));
			}
		}
	}
}
