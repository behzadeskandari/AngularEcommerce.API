using AutoMapper;
using Ecommerce.Common.Dtos.CategoriesDto;
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
    public class CategoriesServices : ICategoriesServices
    {


        public IMapper Mapper { get; }
        public IGenericRepository<Categories> CategoriesRepository { get; }

        public CategoriesServices(IMapper mapper, IGenericRepository<Categories> categoriesRepository)
        {
            Mapper = mapper;
            CategoriesRepository = categoriesRepository;
        }
        public async Task<int> CreateCategoriesAsync(CategoriesCreate objCreate)
        {
            var entity = Mapper.Map<Categories>(objCreate);
            await CategoriesRepository.InsertAsync(entity);
            await CategoriesRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteCategoriesAsync(CategoriesDelete objDelete)
        {
            var entity = await CategoriesRepository.GetByIdAsync(objDelete.Id);
            CategoriesRepository.Delete(entity);
            await CategoriesRepository.SaveChangesAsync();
        }

        public async Task<List<CategoriesGet>> GetCategoriesAsync()
        {
            var entity = await CategoriesRepository.GetAysnc(null, null);
            var mappedEntity = Mapper.Map<List<CategoriesGet>>(entity);
            return mappedEntity;
        }

        public async Task<CategoriesGet> GetCategoriesAsync(int id)
        {
            var entity = await CategoriesRepository.GetByIdAsync(id);
            var mappedEntity = Mapper.Map<CategoriesGet>(entity);
            return mappedEntity;
        }

        public async Task UpdateCategoriesAsync(CategoriesUpdate objUpdate)
        {
            var entity = Mapper.Map<Categories>(objUpdate);
            CategoriesRepository.Update(entity);
            await CategoriesRepository.SaveChangesAsync();
        }
    }
}
