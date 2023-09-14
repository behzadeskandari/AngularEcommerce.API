using Ecommerce.Common.Dtos.Address;
using Ecommerce.Common.Dtos.Jobs;
using Ecommerce.Common.Dtos.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.Employee
{
    public record EmployeeDetails(int Id, string FirstName, string LastName, AddressGet Address, JobGet Job, List<TeamGet> teams);


}
