using Ecommerce.Common.Dtos.OrdersDto;
using Ecommerce.Common.Dtos.ProductsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface IOrdersService
    {
        Task<int> CreateOrdersAsync(OrdersCreate objCreate);

        Task UpdateOrdersAsync(OrdersUpdate objUpdate);

        Task<List<OrdersGet>> GetOrdersAsync();

        Task<OrdersGet> GetOrdersAsync(int id);
        
        Task DeleteOrdersAsync(OrdersDelete objDelete);
    }
}
