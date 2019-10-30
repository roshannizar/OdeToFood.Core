using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Masala Pizza", Location = "Mexico", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 2, Name="Santa Maria Pizza", Location = "French", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name="Chicken Tandoori Pizza", Location = "Italy", Cuisine = CuisineType.Italian}
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            this.restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            return restaurant;

        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCount()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant UpdateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == UpdateRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = UpdateRestaurant.Name;
                restaurant.Location = UpdateRestaurant.Location;
                restaurant.Cuisine = UpdateRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}
