using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {

        private readonly UseCaseHandler _handler;
        private readonly IRegisterUserCommand _command;

        public UsersController(
            UseCaseHandler handler,
            IRegisterUserCommand command)
        {
            _handler = handler;
            _command = command;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserDto dto)
        {
            _handler.HandleCommand(_command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
