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
    public class EFRegisterUserCommand : EFUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        public EFRegisterUserCommand(ResturantDbContext context, RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Registration using Entity Framework.";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hash,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            };

            var useCases = new List<UserUseCase>
            {
                new UserUseCase { User = user, UseCaseId = 3 },
                new UserUseCase { User = user, UseCaseId = 9 },
                new UserUseCase { User = user, UseCaseId = 6 },
                new UserUseCase { User = user, UseCaseId = 7 },
                new UserUseCase { User = user, UseCaseId = 8 }
             };


            Context.Users.Add(user);
            Context.UserUseCases.AddRange(useCases);

            Context.SaveChanges();
        }
    }
}
