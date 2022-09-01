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
    public class EFCreateOrderCommand : EFUseCase, ICreateOrderCommand
    {
        private CreateOrderValidator _validator;
        private IApplicationUser _user;
        public EFCreateOrderCommand(ResturantDbContext context, CreateOrderValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }

        public int Id => 3;

        public string Name => "Create order using Entity Framework.";

        public void Execute(CreateOrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                UserId = _user.Id
            };

            var orderItems = request.OrderItems.Select(x => new OrderItem {
                Quantity = x.Quantity,
                PricelistId = x.PricelistId,
                Order = order
            }).ToList();

            Context.Orders.Add(order);
            Context.OrderItems.AddRange(orderItems);
            Context.SaveChanges();
        }
    }
}
