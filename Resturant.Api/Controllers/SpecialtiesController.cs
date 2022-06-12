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
    public class SpecialtiesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public SpecialtiesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<SpecialtiesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetSpecialtiesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // GET api/<SpecialtiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindSpecialtyQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<SpecialtiesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateSpecialtyDto dto, [FromServices] ICreateSpecialtyCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

    }
}
