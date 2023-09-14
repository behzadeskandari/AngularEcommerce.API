using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.ProductsDto;
using Ecommerce.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsServices ProductsServices { get; }

        public ProductsController(IProductsServices productsServices)
        {
            ProductsServices = productsServices;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProducts(ProductsCreate objCreate)
        {
            var id = await ProductsServices.CreateProductsAsync(objCreate);
            return Ok(id);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateProducts(ProductsUpdate objUpdate)
        {
            await ProductsServices.UpdateProductsAsync(objUpdate);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteProducts(ProductsDelete objDelete)
        {
            await ProductsServices.DeleteProductsAsync(objDelete);
            return Ok();
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var obj = await ProductsServices.GetProductsAsync(id);
            return Ok(obj);
        }



        [HttpGet]
        //[Route("Get")]
        public async Task<IActionResult> GetCategories()
        {
            var obj = await ProductsServices.GetProductsAsync();
            return Ok(obj);
        }
    }
}
