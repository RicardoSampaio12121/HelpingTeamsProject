using Microsoft.AspNetCore.Mvc;
using RequestsApi.Repositories;
using System.Collections;
using RequestsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace RequestsApi.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _repository;

        public TeamsController(ITeamsRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("GetTeams")]
        public async Task<IEnumerable<ReturnTeamDto>> GetTeamsAsync()
        {
            var output = (await _repository.GetTeamsAsync()).Select(team => team.AsReturnTeamDto());
            return output;
        }


        [HttpGet("GetTeamMembers/{teamId}")]
        public async Task<IEnumerable<ReturnTeamMemberDto>> GetTeamMembersAsync(int teamId)
        {
            var output = (await _repository.GetTteamMembersAsync(teamId)).Select(member => member.AsReturnMemberDto());
            return output;

        }

        [HttpPost("CreateTeam")]
        public async Task<ActionResult<CreateTeamDto>> CreateTeam(CreateTeamDto team)
        {
            await _repository.CreateTeamAsync(team.location);
            return Ok();
        }

        [HttpPost("AddMembers")]
        public async Task<ActionResult<AddMemberDto>> AddMembers(List<AddMemberDto> members)
        {
            await _repository.AddTeamMembersAsync(members);
            return Ok();
        }
    }
}
