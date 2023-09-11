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
        public string Email { get; set; }
        public string street { get; set; }
        public string apartment { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public int phone { get; set; }
        public bool isAdmin { get; set; }
    }
}
