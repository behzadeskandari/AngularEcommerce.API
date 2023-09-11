using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class OrderItem : BaseEntity
    {
        public Products products { get; set; }
        public int quantity { get; set; }
    }
}
