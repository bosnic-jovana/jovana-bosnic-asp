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
    public class EFCreateCategoryCommand : EFUseCase, ICreateCategoryCommand
    {
        private CreateCategoryValidator _validator;

        public EFCreateCategoryCommand(ResturantDbContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create category using Entity Framework.";

        public void Execute(CreateBase request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name,
            };

            Context.Categories.Add(category);

            Context.SaveChanges();
        }
    }
}
