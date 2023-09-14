using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class Products : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string RichDescription { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public int Price { get; set; } = default!;
        public int CountInStock { get; set; } = default!;
        public int Rating { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime DateCreated { get; set; }
        public Categories Category { get; set; }

    }


}
