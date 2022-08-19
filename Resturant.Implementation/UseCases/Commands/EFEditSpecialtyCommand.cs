﻿using FluentValidation;
using Resturant.Application.Exceptions;
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
    public class EFEditSpecialtyCommand : EFUseCase, IEditSpecialtyCommand
    {
        private EditSpecialtyValidator _validator;

        public EFEditSpecialtyCommand(ResturantDbContext context, EditSpecialtyValidator validator) : base(context)
        {
            _validator = validator;
        }
    
        public int Id => 14;

        public string Name => "Edit specialty using Entity Framework.";

        public void Execute(EditSpecialtyDto request)
        {
            var specialty = Context.Specialities.Where(x => x.Id == request.Id).FirstOrDefault();
            var price = Context.Pricelists.Where(x => x.SpecialtyId == request.Id).OrderByDescending(x => x.Date).Select(x => x.Price);

            if (specialty == null)
            {
                throw new EntityNotFoundException(nameof(Specialty), request.Id);
            }

            _validator.ValidateAndThrow(request);

            specialty.Name = request.Name;
            specialty.Weight = request.Weight;
            specialty.CategoryId = request.CategoryId;

            if(price.Equals(request.Price))
            {
                var newPrice = new Pricelist
                {
                    Price = request.Price,
                    Date = DateTime.UtcNow,
                    Specialty = specialty
                };

                Context.Pricelists.Add(newPrice);
            }

            Context.SaveChanges();
        }
    }
}
