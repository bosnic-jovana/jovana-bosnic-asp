using Resturant.Application.Exceptions;
using Resturant.Application.UseCases.Commands;
using Microsoft.EntityFrameworkCore;
using Resturant.DataAccess;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases.Commands
{
    public class EFDeleteSpecialtyCommand : EFUseCase, IDeleteSpecialtyCommand
    {
        private IApplicationUser _user;
        public EFDeleteSpecialtyCommand(ResturantDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 16;

        public string Name => "Delete specialty using Entity Framework";

        public void Execute(int id)
        {
            var specialty = Context.Specialities
                .Include(x => x.Pricelists)
                .Include(x => x.SpecialtyIngredients)
                .FirstOrDefault(x => x.Id == id && x.IsActive);

            if (specialty == null)
            {
                throw new EntityNotFoundException(nameof(Specialty), id);
            }

            var prices = specialty.Pricelists.ToList();

            foreach(var p in prices){
                p.DeletedAt = DateTime.UtcNow;
                p.DeletedBy = _user.Identity;
                p.IsActive = false;
            }

            var ingredients = specialty.SpecialtyIngredients.ToList();

            if (ingredients.Any())
            {
                Context.SpecialtyIngredients.RemoveRange(ingredients);
            }

            specialty.DeletedAt = DateTime.UtcNow;
            specialty.DeletedBy = _user.Identity;
            specialty.IsActive = false;

            Context.SaveChanges();
        }
    }
}
