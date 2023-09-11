using AutoMapper;
using Ecommerce.Common.Dtos.ProductsDto;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class ProductsServices : IProductsServices
    {

        public IMapper Mapper { get; }
        public IGenericRepository<Products> ProductsRepository { get; }

        public ProductsServices(IMapper mapper, IGenericRepository<Products> productsRepository)
        {
            Mapper = mapper;
            ProductsRepository = productsRepository;
        }
        public async Task<int> CreateProductsAsync(ProductsCreate objCreate)
        {
            var entity = Mapper.Map<Products>(objCreate);
            await ProductsRepository.InsertAsync(entity);
            await ProductsRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteProductsAsync(ProductsDelete objDelete)
        {
            var entity = await ProductsRepository.GetByIdAsync(objDelete.Id);
            ProductsRepository.Delete(entity);
            await ProductsRepository.SaveChangesAsync();
        }

        public async Task<List<ProductsGet>> GetProductsAsync()
        {
            var entity = await ProductsRepository.GetAysnc(null, null);
            var mappedEntity = Mapper.Map<List<ProductsGet>>(entity);
            return mappedEntity;
        }

        public async Task<ProductsGet> GetProductsAsync(int id)
        {
            var entity = await ProductsRepository.GetByIdAsync(id);
            var mappedEntity = Mapper.Map<ProductsGet>(entity);
            return mappedEntity;
        }

        public async Task UpdateProductsAsync(ProductsUpdate objUpdate)
        {
            var entity = Mapper.Map<Products>(objUpdate);
            ProductsRepository.Update(entity);
            await ProductsRepository.SaveChangesAsync();
        }
    }
}
