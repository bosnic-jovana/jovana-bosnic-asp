using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application.UseCases.Commands;
using Resturant.Application.UseCases.DTO;
using Resturant.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resturant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public IngredientsController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // POST api/<IngredientsController>
        [HttpPost]
        public IActionResult Post([FromForm] CreateBase dto,
            [FromServices] ICreateIngredientCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BaseWithNameDto dto,
            [FromServices] IEditIngredientCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<IngredientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteIngredientCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
