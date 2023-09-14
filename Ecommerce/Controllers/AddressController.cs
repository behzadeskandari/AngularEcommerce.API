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
        private readonly ILogger<AddressController> _logger;
        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            AddressService = addressService;
            _logger = logger;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAddress(AddressCreate addressCreate)
        {

            _logger.LogInformation("CreateAddress...");
            var id = await AddressService.CreateAddressAsync(addressCreate);
            return Ok(id);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAddress(AddressUpdate addressUpdate)
        {

            _logger.LogInformation("UpdateAddress...");
            await AddressService.UpdateAddressAsync(addressUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAddress(AddressDelete addressUpdate)
        {
            _logger.LogInformation("DeleteAddress...");

            await AddressService.DeleteAddressAsync(addressUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetAddress()
        {
            _logger.LogInformation("Getting address...");

            var t = await AddressService.GetAddressesAsync();

            return Ok(t);
        }


    }

}
