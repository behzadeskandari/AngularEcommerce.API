using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.OrderItemDto
{
    public class OrderItemCreate
    {
        public int Id { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
