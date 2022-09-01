using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.UseCases.DTO
{
    public class OrderDto : BaseDto
    {
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }

    public class CreateOrderDto
    {
        public IEnumerable<CreateOrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public string SpecialtyName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
        public int PricelistId { get; set; }
    }
}
