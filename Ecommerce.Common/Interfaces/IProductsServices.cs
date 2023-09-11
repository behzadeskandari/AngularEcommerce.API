using Ecommerce.Common.Dtos.ProductsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface IProductsServices
    {

        Task<int> CreateProductsAsync(ProductsCreate objCreate);

        Task UpdateProductsAsync(ProductsUpdate objUpdate);

        Task<List<ProductsGet>> GetProductsAsync();

        Task<ProductsGet> GetProductsAsync(int id);

        Task DeleteProductsAsync(ProductsDelete objDelete);
    }
}
