using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantsApi.Entity;
using RestaurantsApi.Exceptions;
using RestaurantsApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsApi.Services
{
    public interface IRestaurantServices
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Modify(int id, UpdateRestaurantDto dto);
    }

    public class RestaurantServices : IRestaurantServices
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantServices> _logger;
        public RestaurantServices(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantServices> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
                throw new NotFoundExceptions("Restaurant not found");

            var result = _mapper.Map<RestaurantDto>(restaurant);

            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
                .Restaurants
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            
            return restaurant.Id;
        }

        public void Delete(int id)
        {

            var restaurant = _dbContext
               .Restaurants
               .FirstOrDefault(r => r.Id == id);

            if(restaurant is null)
                throw new NotFoundExceptions("Restaurant not found");

            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();
          
        }

        public void Modify (int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContext
               .Restaurants
               .FirstOrDefault(r => r.Id == id);
            
            if(restaurant == null)
                throw new NotFoundExceptions("Restaurant not found");

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Descrption;
            restaurant.HasDelivery = dto.HasDelivery;

            _dbContext.SaveChanges();

        }
    }
}
