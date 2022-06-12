﻿using Microsoft.AspNetCore.Mvc;
using Resturant.DataAccess;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resturant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var categories = new List<Category>
                {
                    new Category{ Name = "Breakfast"},
                    new Category{ Name = "Pasta"},
                    new Category{ Name = "Fish"},
                    new Category{ Name = "Steak"},
                };

                var ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "iceberg"},
                    new Ingredient { Name = "Caesar dressing"},
                    new Ingredient { Name = "cheese"},
                    new Ingredient { Name = "ham"},
                    new Ingredient { Name = "tortilla"},
                     new Ingredient { Name = "4 toasts"},
                    new Ingredient { Name = "ketchup"},
                    new Ingredient { Name = "French fries"},
                    new Ingredient { Name = "steak"},
                    new Ingredient { Name = "baked potato"}
                };

                var specialties = new List<Specialty>
                {
                    new Specialty { Name = "Tortilla with ham", Image = "image1.jpg", Weight = "300gr", Category = categories.ElementAt(0)},
                    new Specialty { Name = "Tost sandwich", Image = "image2.jpg", Weight = "350gr", Category = categories.ElementAt(0)},
                    new Specialty { Name = "Grilled beefsteak", Image = "image3.jpg", Weight = "300gr", Category = categories.ElementAt(3)}
                };

                var prices = new List<Pricelist>
                {
                    new Pricelist { Price = 380, Date = new DateTime(2022, 6, 1), Specialty = specialties.ElementAt(0)},
                    new Pricelist { Price = 320, Date = new DateTime(2022, 6, 1), Specialty = specialties.ElementAt(1)},
                    new Pricelist { Price = 2250, Date = new DateTime(2022, 6, 1), Specialty = specialties.ElementAt(2)}
                };

                var specialtyIngredients = new List<SpecialtyIngredient>
                {
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(0), Ingredient = ingredients.ElementAt(0)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(0), Ingredient = ingredients.ElementAt(1)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(0), Ingredient = ingredients.ElementAt(2)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(0), Ingredient = ingredients.ElementAt(3)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(0), Ingredient = ingredients.ElementAt(4)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(1), Ingredient = ingredients.ElementAt(2)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(1), Ingredient = ingredients.ElementAt(3)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(1), Ingredient = ingredients.ElementAt(5)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(1), Ingredient = ingredients.ElementAt(6)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(1), Ingredient = ingredients.ElementAt(7)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(2), Ingredient = ingredients.ElementAt(8)},
                    new SpecialtyIngredient { Specialty = specialties.ElementAt(2), Ingredient = ingredients.ElementAt(9)}
                };

                var users = new List<User>
                {
                    new User { FirstName = "Jovana", LastName = "Bosnic", Email = "jovana.bosnic@gmail.com", Password = "jovana123", Address = "Njegoseva 33", PhoneNumber = "063 444 4444"}
                };

                var orders = new List<Order>
                {
                    new Order { User = users.ElementAt(0)}
                };

                var orderItems = new List<OrderItem>
                {
                    new OrderItem { Order = orders.ElementAt(0), Pricelist = prices.ElementAt(2), Quantity = 2 }
                };



                var context = new ResturantDbContext();
                context.Categories.AddRange(categories);
                context.Ingredients.AddRange(ingredients);
                context.Specialities.AddRange(specialties);
                context.Pricelists.AddRange(prices);
                context.SpecialtyIngredients.AddRange(specialtyIngredients);
                context.Users.AddRange(users);
                context.Orders.AddRange(orders);
                context.OrderItems.AddRange(orderItems);
                

                context.SaveChanges();

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Error = "There was an error processing your request." });
            }

            return NoContent();
        }
    }
}
