using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application.UseCases.Commands;
using Resturant.Application.UseCases.DTO;
using Resturant.Application.UseCases.Queries;
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
    public class OrdersController : ControllerBase
    {
        private UseCaseHandler _handler;

        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get([FromQuery] int id, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
