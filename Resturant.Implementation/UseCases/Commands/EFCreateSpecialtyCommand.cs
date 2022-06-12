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
    public class EFCreateSpecialtyCommand : EFUseCase, ICreateSpecialtyCommand
    {
        private CreateSpecialtyValidator _validator;
        public EFCreateSpecialtyCommand(ResturantDbContext context, CreateSpecialtyValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 4;

        public string Name => "Create specialty using Entity Framework.";

        public void Execute(CreateSpecialtyDto request)
        {
            _validator.ValidateAndThrow(request);

            var specialty = new Specialty
            {
                Name = request.Name,
                Image = request.Image,
                Weight = request.Weight,
                CategoryId = request.CategoryId
            };

            var price = new Pricelist
            {
                Price = request.Price,
                Date = DateTime.UtcNow,
                Specialty = specialty
            };

            var specIngr = request.IngredientIds.Select(x => new SpecialtyIngredient
            {
                IngredientId = x,
                Specialty = specialty
            }).ToList();

            Context.Specialities.Add(specialty);
            Context.SaveChanges();
        }
    }
}
