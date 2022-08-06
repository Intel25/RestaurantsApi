using RestaurantsApi.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsApi
{
    public class RestaurantSeeder
    {
        public readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>();
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "FastFood",
                    Description = "Kentucky Fried Chicken",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Addres = new Addres()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                };

                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "FastFood",
                    Description = "Golden Arches",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Price = 5.20M
                        },
                        new Dish()
                        {
                            Name = "McDouble",
                            Price = 6.30M
                        }
                    },
                    Addres = new Addres()
                    {
                        City = "Warszawa",
                        Street = "Nowolipki 5",
                        PostalCode = "05-055"
                    }
                };

                return restaurants;
            }
        }
        
    }
}
