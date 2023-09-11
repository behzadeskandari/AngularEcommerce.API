using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Models
{
    public class ShoppingCartItem : BaseEntity
    {

        public int Id { get; set; }

        public List<Products> products { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }


    }
}
