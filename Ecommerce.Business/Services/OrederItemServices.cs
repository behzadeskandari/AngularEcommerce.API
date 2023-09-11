using AutoMapper;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.OrderItemDto;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class OrederItemServices : IOrderItemServices
    {

        public IMapper Mapper { get; }
        public IGenericRepository<OrderItem> OrederItemRepository { get; }

        public OrederItemServices(IMapper mapper, IGenericRepository<OrderItem> orederItemRepository)
        {
            Mapper = mapper;
            OrederItemRepository = orederItemRepository;
        }
        public async Task<int> CreateOrderItemAsync(OrderItemCreate objCreate)
        {
            var entity = Mapper.Map<OrderItem>(objCreate);
            await OrederItemRepository.InsertAsync(entity);
            await OrederItemRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteOrderItemAsync(OrderItemDelete objDelete)
        {
            var entity = await OrederItemRepository.GetByIdAsync(objDelete.Id);
            OrederItemRepository.Delete(entity);
            await OrederItemRepository.SaveChangesAsync();
        }

        public async Task<List<OrderItemGet>> GetOrderItemAsync()
        {
            var entity = await OrederItemRepository.GetAysnc(null, null);
            var mappedEntity = Mapper.Map<List<OrderItemGet>>(entity);
            return mappedEntity;
        }

        public async Task<OrderItemGet> GetOrderItemAsync(int id)
        {
            var entity = await OrederItemRepository.GetByIdAsync(id);
            var mappedEntity = Mapper.Map<OrderItemGet>(entity);
            return mappedEntity;
        }

        public async Task UpdateOrderItemAsync(OrderItemUpdate objUpdate)
        {
            var entity = Mapper.Map<OrderItem>(objUpdate);
            OrederItemRepository.Update(entity);
            await OrederItemRepository.SaveChangesAsync();
        }
    }
}
