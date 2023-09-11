using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.ProductsDto
{
    public class ProductsGet
    {
        public ProductsGet()
        {
            Category = new Categories();
        }
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string image { get; set; } = default!;
        public string description { get; set; } = default!;
        public string richDescription { get; set; } = default!;
        public string brand { get; set; } = default!;
        public int price { get; set; } = default!;
        public int CountInStock { get; set; } = default!;
        public int rating { get; set; }
        public bool isFeatured { get; set; }
        public DateTime dateCreated { get; set; }
        public Categories Category { get; set; }
    }
}
