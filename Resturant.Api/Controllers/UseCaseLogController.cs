using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application;
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
    public class UseCaseLogController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UseCaseLogController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        //public IActionResult Get(
        //    [FromQuery] UseCaseLogSearch search,
        //    [FromServices] IGetUseCaseLogsQuery query)
        //{
        //    return Ok(_handler.HandleQuery(query, search));
        //}
    }
}
