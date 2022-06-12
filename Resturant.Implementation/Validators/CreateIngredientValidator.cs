using FluentValidation;
using Resturant.Application.UseCases.DTO;
using Resturant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.Validators
{
    public class CreateIngredientValidator : AbstractValidator<CreateBase>
    {
        private ResturantDbContext _context;
        public CreateIngredientValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Minimal number of characters is 2.")
                .Must(name => !_context.Ingredients.Any(x => x.Name == name)).WithMessage("Ingredient {PropertyValue} is already in use.");
        }
    }
}
