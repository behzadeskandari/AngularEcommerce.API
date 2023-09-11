using AutoMapper;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.OrdersDto;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class OrdersService : IOrdersService
    {

        public IMapper Mapper { get; }
        public IGenericRepository<Orders> OrdersRepository { get; }

        public OrdersService(IMapper mapper, IGenericRepository<Orders> ordersRepository)
        {
            Mapper = mapper;
            OrdersRepository = ordersRepository;
        }
        public async Task<int> CreateOrdersAsync(OrdersCreate objCreate)
        {
            var entity = Mapper.Map<Orders>(objCreate);
            await OrdersRepository.InsertAsync(entity);
            await OrdersRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteOrdersAsync(OrdersDelete objDelete)
        {
            var entity = await OrdersRepository.GetByIdAsync(objDelete.Id);
            OrdersRepository.Delete(entity);
            await OrdersRepository.SaveChangesAsync();
        }

        public async Task<List<OrdersGet>> GetOrdersAsync()
        {
            var entity = await OrdersRepository.GetAysnc(null, null);
            var mappedEntity = Mapper.Map<List<OrdersGet>>(entity);
            return mappedEntity;
        }

        public async Task<OrdersGet> GetOrdersAsync(int id)
        {
            var entity = await OrdersRepository.GetByIdAsync(id);
            var mappedEntity = Mapper.Map<OrdersGet>(entity);
            return mappedEntity;
        }

        public async Task UpdateOrdersAsync(OrdersUpdate objUpdate)
        {
            var entity = Mapper.Map<Orders>(objUpdate);
            OrdersRepository.Update(entity);
            await OrdersRepository.SaveChangesAsync();
        }
    }
}
