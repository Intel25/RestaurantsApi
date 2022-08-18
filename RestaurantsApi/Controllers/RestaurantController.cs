using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsApi.Entity;
using RestaurantsApi.Models;
using RestaurantsApi.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _restaurantServices;
        
        public RestaurantController(IRestaurantServices restaurantServices)
        {
            _restaurantServices = restaurantServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantServices.GetAll();
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantServices.GetById(id);

            return Ok(restaurant);
        }

        [HttpPost]
        public ActionResult<Restaurant> CreateRestaurant ([FromBody]CreateRestaurantDto dto)
        {
            var id = _restaurantServices.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantServices.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Modify([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
            _restaurantServices.Modify(id, dto);
            
            return Ok();
        }
    }
}
