using AutoMapper;
using Ecommerce.Common.Dtos.Address;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class AddressService : IAddressService
    {
        public IMapper Mapper { get; }
        public IGenericRepository<Address> AddressRepository { get; }

        public AddressService(IMapper mapper, IGenericRepository<Address> addressRepository)
        {
            Mapper = mapper;
            AddressRepository = addressRepository;
        }

        public async Task<int> CreateAddressAsync(AddressCreate addressCreate)
        {
            var entity = Mapper.Map<Address>(addressCreate);
            await AddressRepository.InsertAsync(entity);
            await AddressRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAddressAsync(AddressDelete addressDelete)
        {
            var entity = await AddressRepository.GetByIdAsync(addressDelete.Id);
            if (entity !=null)
            {
                AddressRepository.Delete(entity);
                await AddressRepository.SaveChangesAsync();
            }
            else
            {
                throw new EntityException($"The Address Doesn't Exists {entity}");
            }
    

        }

        public async Task<List<AddressGet>> GetAddressesAsync()
        {
            var entity = await AddressRepository.GetAysnc(null, null);
            var mappedEntity = Mapper.Map<List<AddressGet>>(entity);
            return mappedEntity;

        }

        public async Task UpdateAddressAsync(AddressUpdate addressUpdate)
        {
            var entity = Mapper.Map<Address>(addressUpdate);
            AddressRepository.Update(entity);
            await AddressRepository.SaveChangesAsync();


        }
    }

}
