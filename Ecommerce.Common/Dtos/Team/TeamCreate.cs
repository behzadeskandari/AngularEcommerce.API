using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Dtos.Employee;
using Ecommerce.Common.Models;

namespace Ecommerce.Common.Dtos.Team
{
    public record TeamCreate(string Name,List<int> Employee);
    
}
