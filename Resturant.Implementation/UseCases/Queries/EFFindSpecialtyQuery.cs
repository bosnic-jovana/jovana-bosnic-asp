using Resturant.Application.UseCases.DTO;
using Resturant.Application.UseCases.Queries;
using Resturant.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant.Application.Exceptions;
using Resturant.Domain;

namespace Resturant.Implementation.UseCases.Queries
{
    public class EFFindSpecialtyQuery : EFUseCase, IFindSpecialtyQuery
    {
  
        public EFFindSpecialtyQuery(ResturantDbContext context) : base(context)
        {
            
        }

        public int Id => 9;

        public string Name => "EF Find Specialty.";

        public SpecialtyDto Execute(int id)
        {
            var specialty = Context.Specialities
                             .Include(x => x.Category)
                             .Include(x => x.SpecialtyIngredients)
                             .ThenInclude(x => x.Ingredient)
                             .Include(x => x.Pricelists)
                             .FirstOrDefault(x => x.Id == id && x.IsActive);

            if(specialty == null)
            {
                throw new EntityNotFoundException(nameof(Specialty), id);
            }

            return new SpecialtyDto
            {
                Id = specialty.Id,
                Name = specialty.Name,
                Weight = specialty.Weight,
                Image = specialty.Image,
                Category = specialty.Category.Name,
                Price = specialty.Pricelists.OrderByDescending(x => x.Date).Select(x => x.Price).First(),
                Ingredients = specialty.SpecialtyIngredients.Select(x => x.Ingredient.Name).ToList()
            };

        }
    }
}
