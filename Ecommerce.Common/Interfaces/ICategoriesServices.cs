using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.ProductsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface ICategoriesServices
    {

        Task<int> CreateCategoriesAsync(CategoriesCreate objCreate);

        Task UpdateCategoriesAsync(CategoriesUpdate objUpdate);

        Task<List<CategoriesGet>> GetCategoriesAsync();

        Task<CategoriesGet> GetCategoriesAsync(int id);

        Task DeleteCategoriesAsync(CategoriesDelete objDelete);
    }
}
