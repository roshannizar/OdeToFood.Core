using OdeToFood.Core;
using System;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Create(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
        int GetCount();
    }
}
