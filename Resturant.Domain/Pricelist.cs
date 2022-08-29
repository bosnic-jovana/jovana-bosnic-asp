using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class Pricelist : Entity
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
