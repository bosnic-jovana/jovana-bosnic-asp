using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.DTO
{
    public class SpecialtyDto : BaseDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public IEnumerable<string> Ingredients { get; set; }

    }

    public class CreateSpecialtyDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<int> IngredientIds { get; set; }
    }
}
