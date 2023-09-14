using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.Team
{
    public record TeamUpdate(int Id,string Name,List<int> Employees);
    

}
