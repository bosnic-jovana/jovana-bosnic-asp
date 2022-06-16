using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.DTO
{
    public class BaseWithNameDto : BaseDto
    {
        public string Name { get; set; }
    }

    public class CreateBase
    {
        public string Name { get; set; }
    }
}
