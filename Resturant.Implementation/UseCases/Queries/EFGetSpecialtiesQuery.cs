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
    public class EFGetSpecialtiesQuery : EFUseCase, IGetSpecialtiesQuery
    {
        public EFGetSpecialtiesQuery(ResturantDbContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Search specialties using Entity Framework.";

        public PagedResponse<SpecialtyDto> Execute(BasePagedSearch request)
        {
            var query = Context.Specialities.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword) 
                                        || x.Category.Name.Contains(request.Keyword)
                                        || x.SpecialtyIngredients.Any(y => y.Ingredient.Name.Contains(request.Keyword)));                  
            }

            if (request.PerPage == null || request.PerPage < 1)
            {
                request.PerPage = 15;
            }

            if (request.Page == null || request.Page < 1)
            {
                request.PerPage = 1;
            }

            var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

            var response = new PagedResponse<SpecialtyDto>();
            response.TotalCount = query.Count();

            response.Data = query.Skip(toSkip).Take(request.PerPage.Value).Select(x => new SpecialtyDto
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Weight = x.Weight,
                Category = x.Category.Name,
                Price = x.Pricelists.OrderByDescending(p => p.Date).Select(y => y.Price).First(),
                Ingredients = x.SpecialtyIngredients.Select(y => y.Ingredient.Name).ToList()

            }).ToList();
            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage.Value;

            return response;
        }
    }
}
