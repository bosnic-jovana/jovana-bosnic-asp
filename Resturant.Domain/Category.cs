using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Specialty> Specialities { get; set; } = new List<Specialty>();
    }
}
