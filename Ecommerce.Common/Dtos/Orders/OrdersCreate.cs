﻿using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.OrdersDto
{
    public class OrdersCreate
    {
        public int Id { get; set; }
        public List<OrderItemGet> orderItem { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public string Status { get; set; }
        public int TotalPrice { get; set; }
        public UserDto.UserDto User { get; set; }
        public DateTime DateOrdered { get; set; }
    }
}
