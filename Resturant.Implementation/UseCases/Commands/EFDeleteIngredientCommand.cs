using Resturant.Application.UseCases.Commands;
using Resturant.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain;
using Resturant.Application.Exceptions;

namespace Resturant.Implementation.UseCases.Commands
{
    public class EFDeleteIngredientCommand : EFUseCase, IDeleteIngredientCommand
    {
        public EFDeleteIngredientCommand(ResturantDbContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Delete ingredient using Entity Framework";

        public void Execute(int id)
        {
            var ingredient = Context.Ingredients
                                    .Include(x => x.SpecialtyIngredients)
                                    .FirstOrDefault(x => x.Id == id && x.IsActive);

            if(ingredient == null)
            {
                throw new EntityNotFoundException(nameof(Ingredient), id);
            }

            Context.SpecialtyIngredients.RemoveRange(ingredient.SpecialtyIngredients);
            Context.Ingredients.Remove(ingredient);

            Context.SaveChanges();
        }
    }
}
