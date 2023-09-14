using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class Team : BaseEntity
    {

        public Team()
        {
            Employees = new();
        }
        public string Name { get; set; } = default!;

        public List<Employee> Employees { get; set; } = default!;

    }
}
