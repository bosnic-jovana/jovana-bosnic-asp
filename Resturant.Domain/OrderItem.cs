using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain
{
    public class OrderItem : Entity
    {
        public int Quantity { get; set; }
        public int PricelistId { get; set; }
        public int OrderId { get; set; }

        public virtual Pricelist Pricelist { get; set; }
        public virtual Order Order { get; set; }
    }
}
