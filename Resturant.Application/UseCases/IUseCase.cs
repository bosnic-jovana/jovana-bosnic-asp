using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
