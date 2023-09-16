using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
        string GetToken(ApplicationUser user);
    }
}
