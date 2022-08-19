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
    public class CreateCategoryValidator :  AbstractValidator<CreateBase>
    {
        private ResturantDbContext _context;
        public CreateCategoryValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Minimal number of characters is 3.")
                .Must(name => !_context.Categories.Any(x => x.Name == name)).WithMessage("Category {PropertyValue} is already in use.");
        }
    }
}
