using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {

        private readonly OdeToFoodDbContext db;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            db.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in db.Restaurants
                        orderby r.Name
                        select r;

            return query;

        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCount()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);

            entity.State = EntityState.Modified;

            return restaurant;
        }
    }
}
