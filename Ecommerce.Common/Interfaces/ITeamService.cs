using Ecommerce.Common.Dtos.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface ITeamService
    {
        Task<int> CreateTeamAsync(TeamCreate teamCreate);

        Task UpdateTeamAsync(TeamUpdate teamUpdate);

        Task<List<TeamGet>> GetTeamsAsync();
        Task<TeamGet> GetTeamAsync(int id);

        Task DeleteTeamAsync(TeamDelete teamDelete);


    }
}
