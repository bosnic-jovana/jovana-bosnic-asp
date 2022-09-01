using Resturant.Application.Exceptions;
using Resturant.Application.UseCases.Commands;
using Resturant.DataAccess;
using Microsoft.EntityFrameworkCore;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases.Commands
{
    public class EFDeleteOrderCommand : EFUseCase, IDeleteOrderCommand
    {
        private IApplicationUser _user;
        public EFDeleteOrderCommand(ResturantDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 15;

        public string Name => "Delete order using Entity Framework";

        public void Execute(int id)
        {
            var order = Context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), id);
            }

            var items = order.OrderItems.ToList();

            foreach (var itm in items)
            {
                itm.DeletedAt = DateTime.UtcNow;
                itm.DeletedBy = _user.Identity;
                itm.IsActive = false;
            }

            order.DeletedBy = _user.Identity;
            order.DeletedAt = DateTime.UtcNow;
            order.IsActive = false;


            Context.SaveChanges();
        }
    }
}
