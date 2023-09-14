using Ecommerce.Common.Dtos.Address;
using Ecommerce.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private IAddressService AddressService { get; }

        public AddressController(IAddressService addressService)
        {
            AddressService = addressService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAddress(AddressCreate addressCreate)
        {
            var id = await AddressService.CreateAddressAsync(addressCreate);
            return Ok(id);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAddress(AddressUpdate addressUpdate)
        {
            await AddressService.UpdateAddressAsync(addressUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAddress(AddressDelete addressUpdate)
        {
            await AddressService.DeleteAddressAsync(addressUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetAddress()
        {
            var t = await AddressService.GetAddressesAsync();

            return Ok(t);

        }


    }

}
