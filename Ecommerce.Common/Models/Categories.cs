using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }

    }
}
