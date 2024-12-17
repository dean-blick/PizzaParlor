using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaParlor.Data;

namespace Website.Pages
{
    /// <summary>
    /// Codebehind for the index page
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// logger
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// The menu items to filter through
        /// </summary>
        public IEnumerable<IMenuItem> MenuItems { get; set; } = Enumerable.Empty<IMenuItem>();

        /// <summary>
        /// search term
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string? SearchTerms { get; set; }
        /// <summary>
        /// search term
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }
        /// <summary>
        /// search term
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }
        /// <summary>
        /// search term
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }
        /// <summary>
        /// search term
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Gets the search results for display on the page
        /// </summary>
        public void OnGet()
        {
            MenuItems = Menu.Search(SearchTerms);
            MenuItems = Menu.FilterByCalories(MenuItems, CaloriesMin, CaloriesMax);
            MenuItems = Menu.FilterByPrice(MenuItems, PriceMin, PriceMax);
        }


        
    }
}