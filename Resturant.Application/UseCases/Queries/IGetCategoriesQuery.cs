using Resturant.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.Queries
{
    public interface IGetCategoriesQuery : IQuery<BaseSearch, IEnumerable<BaseWithNameDto>>
    {

    }
}
