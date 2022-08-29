using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class SpecialtyIngredient
    {
        public int SpecialtyId { get; set; }
        public int IngredientId { get; set; }

        public virtual Specialty Specialty { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
