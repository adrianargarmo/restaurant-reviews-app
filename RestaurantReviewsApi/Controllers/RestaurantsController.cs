using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewsApi.Models;
using System;

namespace RestaurantReviewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        // creating the api to get the results we need 1 of 2
        private readonly RestaurantReviewsDbContext _dbContext;

        // creating the api to get the results we need 2 of 2
        public RestaurantsController(RestaurantReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // API to get all the restaurants
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
        {
            return _dbContext.Restaurants.ToList();
        }

        // Create the API to get a single restaurant by using it's id
        // GET: api/restaurants/{id}
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetRestaurant(int id)
        {
            var restaurant = _dbContext.Restaurants.Find(id);

            if (restaurant == null) { return NotFound(); }
            return restaurant;
        }

        // API to update a restaurant
        // PUT: api/restaurants/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] Restaurant updatedRestaurant)
        {
            var restaurant = _dbContext.Restaurants.Find(id);

            if (restaurant == null) { return NotFound(); }

            restaurant.Name = updatedRestaurant.Name;
            restaurant.Review = updatedRestaurant.Review;
            restaurant.Rating = updatedRestaurant.Rating;

            _dbContext.Restaurants.Update(restaurant);

            _dbContext.SaveChanges();

            return NoContent();
        }

        //API to add a restaurant
        // POST: api/restaurants
        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);

            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        // API to delete a restaurant by ID
        // DELETE: api/restaurants/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _dbContext.Restaurants.Find(id);

            if (restaurant == null) { return NotFound(); }

            _dbContext.Restaurants.Remove(restaurant);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}