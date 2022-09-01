using FluentValidation;
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
    public class EFEditCategoryCommand : EFUseCase, IEditCategoryCommand
    {
        private EditCategoryValidator _validator;

        public EFEditCategoryCommand(ResturantDbContext context, EditCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 12;

        public string Name => "Edit category using Entity Framework.";

        public void Execute(BaseWithNameDto request)
        {
            var category = Context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request.Id);
            }

            _validator.ValidateAndThrow(request);

            category.Name = request.Name;

            Context.SaveChanges();

        }
    }
}
