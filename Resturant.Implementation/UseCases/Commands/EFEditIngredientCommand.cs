using FluentValidation;
using Resturant.Application.Exceptions;
using Resturant.Application.UseCases.Commands;
using Resturant.Application.UseCases.DTO;
using Resturant.DataAccess;
using Resturant.Domain;
using Resturant.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases.Commands
{
    public class EFEditIngredientCommand : EFUseCase, IEditIngredientCommand
    {
        private EditIngredientValidator _validator;

        public EFEditIngredientCommand(ResturantDbContext context, EditIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Edit ingredient using Entity Framework.";

        public void Execute(BaseWithNameDto request)
        {
            var ingredient = Context.Ingredients.Where(x => x.Id == request.Id).FirstOrDefault();

            if (ingredient == null)
            {
                throw new EntityNotFoundException(nameof(Ingredient), request.Id);
            }

            _validator.ValidateAndThrow(request);

            ingredient.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
