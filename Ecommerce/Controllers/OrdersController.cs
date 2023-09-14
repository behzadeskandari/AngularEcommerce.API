using Ecommerce.Business.Services;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.OrdersDto;
using Ecommerce.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class OrdersController : ControllerBase
    {
        private IOrdersService OrdersService { get; }

        public OrdersController(IOrdersService ordersService)
        {
            OrdersService = ordersService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategories(OrdersCreate objCreate)
        {
            var id = await OrdersService.CreateOrdersAsync(objCreate);
            return Ok(id);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategories(OrdersUpdate objUpdate)
        {
            await OrdersService.UpdateOrdersAsync(objUpdate);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrders(OrdersDelete objDelete)
        {
            await OrdersService.DeleteOrdersAsync(objDelete);
            return Ok();
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetOrders(int id)
        {
            var team = await OrdersService.GetOrdersAsync(id);
            return Ok(team);
        }



        [HttpGet]
        //[Route("Get")]
        public async Task<IActionResult> GetOrders()
        {
            var obj = await OrdersService.GetOrdersAsync();
            return Ok(obj);
        }

    }
}
