using FluentValidation;
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
    public class EFCreateIngredientCommand : EFUseCase, ICreateIngredientCommand
    {
        private CreateIngredientValidator _validator;
        public EFCreateIngredientCommand(ResturantDbContext context, CreateIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create ingredient using Entity Framework.";

        public void Execute(CreateBase request)
        {
            _validator.ValidateAndThrow(request);

            var ingredient = new Ingredient
            {
                Name = request.Name
            };

            Context.Ingredients.Add(ingredient);

            Context.SaveChanges();
        }
    }
}
