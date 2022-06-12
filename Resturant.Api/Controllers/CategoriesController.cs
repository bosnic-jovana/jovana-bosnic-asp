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
    public class CategoriesController : ControllerBase
    {

        private UseCaseHandler _handler;
        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

     
        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromForm] CreateBase dto,
            [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

    }
}
