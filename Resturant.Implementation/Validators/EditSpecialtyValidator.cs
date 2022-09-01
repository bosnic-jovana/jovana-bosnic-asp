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
    public class EditSpecialtyValidator : AbstractValidator<EditSpecialtyDto>
    {
        private ResturantDbContext _context;
        public EditSpecialtyValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
               .MinimumLength(2).WithMessage("Minimal number of characters is 2.")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Name).Must((dto, name) => !_context.Specialities.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(y => $"Specialty with name {y.Name} already exists.");
               });


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
