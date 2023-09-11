using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Dtos.UserDto;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.OrdersDto
{
    public class OrdersUpdate
    {
        public int Id { get; set; }
        public List<OrderItemGet> orderItem { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public string status { get; set; }
        public int totalPrice { get; set; }
        public ApplicationUserDto User { get; set; }
        public DateTime dateOrdered { get; set; }
    }
}
