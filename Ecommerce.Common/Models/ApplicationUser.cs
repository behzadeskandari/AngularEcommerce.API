using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{

    public class ApplicationUser : IdentityUser<string>
    {

        [Display(Name = "Full Name")]
        public string FullName { 
            get {
                return FirstName + LastName;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
