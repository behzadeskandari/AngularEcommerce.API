﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class Orders : BaseEntity
    {
        public List<OrderItem> orderItem { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public long Phone { get; set; }
        public string Status { get; set; }
        public long TotalPrice { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateOrdered { get; set; }

    }
}
