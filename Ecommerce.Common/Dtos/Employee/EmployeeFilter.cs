using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.Employee
{
    public record EmployeeFilter(string? FirstName, string? LastName, string? Job, string? Team, int? Skip, int? Take);

}
