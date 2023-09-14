using Ecommerce.Business.Services;
using Ecommerce.Common.Dtos.CategoriesDto;
using Ecommerce.Common.Dtos.Team;
using Ecommerce.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private ICategoriesServices CategoriesServices { get; }

        public CategoriesController(ICategoriesServices categoriesServices)
        {
            CategoriesServices = categoriesServices;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategories(CategoriesCreate teamCreate)
        {
            var id = await CategoriesServices.CreateCategoriesAsync(teamCreate);
            return Ok(id);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategories(CategoriesUpdate teamUpdate)
        {
            await CategoriesServices.UpdateCategoriesAsync(teamUpdate);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCategories(CategoriesDelete teamDelete)
        {
            await CategoriesServices.DeleteCategoriesAsync(teamDelete);
            return Ok();
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var team = await CategoriesServices.GetCategoriesAsync(id);
            return Ok(team);
        }



        [HttpGet]
        //[Route("Get")]
        public async Task<IActionResult> GetCategories()
        {
            var team = await CategoriesServices.GetCategoriesAsync();
            return Ok(team);
        }
    }
}
