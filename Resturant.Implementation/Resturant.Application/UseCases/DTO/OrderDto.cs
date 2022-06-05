using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.DTO
{
    public class OrderDto : BaseDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderDto
    {
        public int? UserId { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
