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
        public Products products { get; set; }
        public int quantity { get; set; }
    }
}
