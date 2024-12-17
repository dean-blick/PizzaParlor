using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaParlor.Data;

namespace Website.Pages
{
    public class ReviewsModel : PageModel
    {
        public void OnGet()
        {
        }


		public void OnPost()
		{
			//will be automatically called when there is a post request
			//want to add name to the list
			ReviewList.AddReview(new PizzaParlor.Data.Review(ReviewText));
			ReviewText = null;
		}

		[BindProperty]
		public string ReviewText { get; set; }
	}
}
