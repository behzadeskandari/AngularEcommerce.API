using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Dtos.UserDto
{
    public class ApplicationUserDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }

    }
}
