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
    public class EditCategoryValidator : AbstractValidator<BaseWithNameDto>
    {
        private ResturantDbContext _context;
        public EditCategoryValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Minimal number of characters is 3.")
                .DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((dto, name) => !_context.Categories.Any(y => y.Name == name && y.Id != dto.Id)).WithMessage(y => $"Category with name {y.Name} already exists.");
            });

        }
    }
}
