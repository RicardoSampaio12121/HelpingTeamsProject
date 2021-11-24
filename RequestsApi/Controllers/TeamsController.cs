using Microsoft.AspNetCore.Mvc;
using RequestsApi.Repositories;
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

        /// <summary>
        /// Gets all the teams stored in the database
        /// </summary>
        /// <returns>
        /// IEnumerable of the ReturnTeamDto
        /// </returns>
        [HttpGet("GetTeams")]
        public async Task<IEnumerable<ReturnTeamDto>> GetTeamsAsync()
        {
            var output = (await _repository.GetTeamsAsync()).Select(team => team.AsReturnTeamDto());
            return output;
        }

        /// <summary>
        /// Gets a team by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a ReturnTeamDto
        /// </returns>
        [HttpGet("GetTeam/{id}")]
        public async Task<ReturnTeamDto> GetTeamByIdAsync(int id)
        {
            var output = (await _repository.GetTeamByIdAsync(id)).AsReturnTeamDto();
            return output;
        }


        /// <summary>
        /// Gets the team members from the database of a team by the team id
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>
        /// IEnumerable of ReturnTeamMemberDto
        /// </returns>
        [HttpGet("GetTeamMembers/{teamId}")]
        public async Task<IEnumerable<ReturnTeamMemberDto>> GetTeamMembersAsync(int teamId)
        {
            var output = (await _repository.GetTteamMembersAsync(teamId)).Select(member => member.AsReturnTeamMemberDto());
            return output;
        }


        /// <summary>
        /// Creates a team
        /// </summary>
        /// <param name="team"></param>
        /// <returns>
        /// Returns the path to where the team is stored
        /// </returns>
        [HttpPost("CreateTeam")]
        public async Task<ActionResult<CreateTeamDto>> CreateTeam(CreateTeamDto team)
        {
            await _repository.CreateTeamAsync(team.location);
            //TODO: Fazer return a um createdataction
            return Ok();
        }

        /// <summary>
        /// Adds a list of members to the last created team
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        [HttpPost("AddMembers")] //TODO: Change the name of this endpoint to a more appropriate one
        public async Task<ActionResult<AddMemberDto>> AddMembers(List<AddMemberDto> members)
        {
            await _repository.AddTeamMembersAsync(members);
            //TODO: Return a createdataction
            return Ok();
        }

        /// <summary>
        /// Adds a member to a team identified by the team id
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost("AddMember/{teamId}")]
        public async Task<ActionResult<AddMemberDto>> AddMember(int teamId, AddMemberDto member)
        {
            await _repository.AddTeamMemberAsync(teamId, member);
            //TODO: Return a createdataction
            return Ok();
        }

        /// <summary>
        /// Removes a member from a team
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns>
        /// NoContent
        /// </returns>
        [HttpDelete("RemoveMember/{memberId}")]
        public async Task<ActionResult> RemoveMember(int memberId)
        {
            await _repository.RemoveTeamMember(memberId);
            return NoContent();
        }

        [HttpDelete("RemoveTeam/{teamId}")]
        public async Task<ActionResult> RemoveTeam(int teamId)
        {
            await _repository.RemoveTeam(teamId);
            return NoContent();
        }

        [HttpDelete("RemoveAllTeamMembers/{teamId}")]
        public async Task<ActionResult> RemoveAllTeamMembers(int teamId)
        {
            await _repository.RemoveAllTeamMembers(teamId);
            return NoContent();
        }

    }
}
