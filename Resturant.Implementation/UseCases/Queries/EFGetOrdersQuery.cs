using Resturant.Application.UseCases.DTO;
using Resturant.Application.UseCases.Queries;
using Resturant.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant.Application.Exceptions;
using Resturant.Domain;

namespace Resturant.Implementation.UseCases.Queries
{
    public class EFGetOrdersQuery : EFUseCase, IGetOrdersQuery
    {
        public EFGetOrdersQuery(ResturantDbContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Search orders for one user using Entity Framework.";

        public IEnumerable<OrderDto> Execute(int id)
        {
            var query = Context.Orders
                            .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Pricelist)
                            .ThenInclude(x => x.Specialty)
                            .Where(x => x.UserId == id && x.IsActive);

            if (query == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }

            return query.Select(x => new OrderDto
            {
                Date = x.CreatedAt,
                OrderItems = x.OrderItems.Where(x => x.IsActive).Select(y => new OrderItemDto
                {
                    SpecialtyName = y.Pricelist.Specialty.Name,
                    Quantity = y.Quantity,
                    Price = y.Pricelist.Price * y.Quantity
                }),
                TotalPrice = x.OrderItems.Sum(y => y.Quantity * y.Pricelist.Price)
            }).ToList();
        }
    }
}
