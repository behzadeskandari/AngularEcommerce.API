using Ecommerce.Common.Dtos.Team;
using Ecommerce.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService TeamService;

        public TeamController(ITeamService teamService)
        {
            TeamService = teamService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateTeam(TeamCreate teamCreate)
        {
            var id = await TeamService.CreateTeamAsync(teamCreate);
            return Ok(id);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateTeam(TeamUpdate teamUpdate)
        {
            await TeamService.UpdateTeamAsync(teamUpdate);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteTeam(TeamDelete teamDelete)
        {
            await TeamService.DeleteTeamAsync(teamDelete);
            return Ok();
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await TeamService.GetTeamAsync(id);
            return Ok(team);
        }



        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetTeams()
        {
            var team = await TeamService.GetTeamsAsync();
            return Ok(team);
        }


    }

}
