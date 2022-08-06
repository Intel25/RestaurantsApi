using AutoMapper;
using RestaurantsApi.Entity;
using RestaurantsApi.Models;

namespace RestaurantsApi
{
    public class RestaurantMappingProfile :Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Addres.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Addres.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Addres.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Addres, c => c.MapFrom(dto => new Addres() 
                {City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
            

            
        }      
    }
}
