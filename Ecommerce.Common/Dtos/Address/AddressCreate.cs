using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.Address
{
    public record AddressCreate(string Street, string Zip, string City, string Email, string? Phone);

}
