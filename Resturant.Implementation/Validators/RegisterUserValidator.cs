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
    public class RegisterUserValidator : AbstractValidator<UserDto>
    {
        private ResturantDbContext _context;
        public RegisterUserValidator(ResturantDbContext context)
        {
            _context = context;

            var firstLastNameRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .Matches(firstLastNameRegex).WithMessage("First name is not in the correct format.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches(firstLastNameRegex).WithMessage("Last name is not in the correct format.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not in the correct format.")
                .Must(email => !_context.Users.Any(y => y.Email == email)).WithMessage("Email {PropertyValue} is already in use.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Minimal number of characters is 8.");

            RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Phone number is required.");

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Address is required.")
                .MinimumLength(8).WithMessage("Minimal number of characters is 8.");
        }
    }
}
