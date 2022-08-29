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
    public class EditIngredientValidator : AbstractValidator<BaseWithNameDto>
    {
        private ResturantDbContext _context;
        public EditIngredientValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Minimal number of characters is 2.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name).Must((dto, name) => !_context.Ingredients.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(y => $"Ingredient with name {y.Name} already exists.");
                });

        }
    }
}
