using Ecommerce.Common.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.Team
{
    public record TeamGet(int Id,string Name,List<EmployeeList> Employees);
    
}
