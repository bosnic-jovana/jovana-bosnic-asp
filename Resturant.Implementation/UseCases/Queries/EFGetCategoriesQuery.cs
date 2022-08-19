using Resturant.Application.UseCases.DTO;
using Resturant.Application.UseCases.Queries;
using Resturant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases.Queries
{
    public class EFGetCategoriesQuery : EFUseCase, IGetCategoriesQuery
    {
        public EFGetCategoriesQuery(ResturantDbContext context) : base(context)
        {

        }

        public int Id => 6;

        public string Name => "Search categories using Entity Framework.";

        public IEnumerable<BaseWithNameDto> Execute(BaseSearch request)
        {
            var query = Context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            var response = new PagedResponse<BaseWithNameDto>();

            return query.Select(x => new BaseWithNameDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
