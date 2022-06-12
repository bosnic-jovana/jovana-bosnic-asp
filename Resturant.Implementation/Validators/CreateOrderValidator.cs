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
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        private ResturantDbContext _context;
        public CreateOrderValidator(ResturantDbContext context)
        {
            _context = context;

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("You must log in to make an order.")
                .Must(user => _context.Users.Any(x => x.Id == user)).WithMessage("User is not registered.");

            RuleFor(x => x.OrderItems)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("You must select an item to order.");
        }
    }
}
