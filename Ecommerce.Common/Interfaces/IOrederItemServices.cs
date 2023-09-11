using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Dtos.ProductsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface IOrderItemServices
    {

        Task<int> CreateOrderItemAsync(OrderItemCreate objCreate);

        Task UpdateOrderItemAsync(OrderItemUpdate objUpdate);

        Task<List<OrderItemGet>> GetOrderItemAsync();

        Task<OrderItemGet> GetOrderItemAsync(int id);

        Task DeleteOrderItemAsync(OrderItemDelete objDelete);
    }
}
