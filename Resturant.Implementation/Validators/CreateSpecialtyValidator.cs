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
    public class CreateSpecialtyValidator : AbstractValidator<CreateSpecialtyDto>
    {
        private ResturantDbContext _context;
        public CreateSpecialtyValidator(ResturantDbContext context)
        {
            _context = context;

           RuleFor(x => x.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Name is required.")
               .MinimumLength(3).WithMessage("Minimal number of characters is 3.")
               .Must(name => !_context.Specialities.Any(x => x.Name == name)).WithMessage("Specialty {PropertyValue} is already in use.");

            RuleFor(x => x.Image)
                  .NotEmpty().WithMessage("Image is required.");

            RuleFor(x => x.Weight)
                 .NotEmpty().WithMessage("Weight is required.");

            RuleFor(x => x.Price)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Price is required.")
                 .Must(price => price > 0).WithMessage("Price must be above 0.");

            RuleFor(x => x.CategoryId)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Category is required.")
                 .Must(cat => _context.Categories.Any(x => x.Id == cat)).WithMessage("Category does not exist.");

            RuleFor(x => x.IngredientIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Minimum number of ingredients is 1.")
                .Must(values => values.Distinct().Count() == values.Count()).WithMessage("Duplicate values are not allowed.")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.IngredientIds)
                    .Must(val => _context.Ingredients.Any(y => y.Id == val))
                    .WithMessage("The ingredient does not exist.");
                });

        }
    }
}
