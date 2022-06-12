using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<SpecialtyIngredient> SpecialtyIngredients { get; set; } = new List<SpecialtyIngredient>();
    }
}
