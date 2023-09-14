using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class OrderItem : BaseEntity
    {
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
