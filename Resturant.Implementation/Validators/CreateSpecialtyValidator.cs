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
    public class CreateSpecialtyValidator : AbstractValidator<CreateSpecialtyDto>
    {
        private ResturantDbContext _context;
        public CreateSpecialtyValidator(ResturantDbContext context)
        {
            _context = context;

       
        }
    }
}
