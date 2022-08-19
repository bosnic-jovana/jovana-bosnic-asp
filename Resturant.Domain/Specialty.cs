using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class Specialty : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<SpecialtyIngredient> SpecialtyIngredients { get; set; } = new List<SpecialtyIngredient>();
        public virtual ICollection<Pricelist> Pricelists { get; set; } = new List<Pricelist>();
    }
}
