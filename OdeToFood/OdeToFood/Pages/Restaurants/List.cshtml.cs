using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
            this.logger = logger;
            this.restaurantData = restaurantData;
        } 

        public void OnGet(string searchTerm)
        {
            logger.LogError("Executing ListModel");
            Message = this.configuration["Message"];
            Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}