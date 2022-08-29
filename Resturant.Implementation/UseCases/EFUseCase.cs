using Resturant.Application.UseCases;
using Resturant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases
{
    public abstract class EFUseCase 
    {
        protected ResturantDbContext Context { get; }
        protected EFUseCase(ResturantDbContext context)
        {
            Context = context;
        }
    }
}
