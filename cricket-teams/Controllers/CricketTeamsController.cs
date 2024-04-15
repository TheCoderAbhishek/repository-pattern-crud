using cricket_teams.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cricket_teams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketTeamsController(CricketTeamRepository repository) : ControllerBase
    {
        private readonly CricketTeamRepository _repository = repository;

        [HttpGet("GetTeams")]
        public async Task<ActionResult<List<CricketTeam>>> GetTeams()
        {
            var teams = await _repository.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("GetTeamById/{id}")]
        public async Task<ActionResult<CricketTeam>> GetTeamById(int id)
        {
            var team = await _repository.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return team;
        }

        [HttpPost("CreateTeam")]
        public async Task<ActionResult<CricketTeam>> CreateTeam(CricketTeam team)
        {
            if (team == null)
            {
                return BadRequest();
            }

            await _repository.AddTeamAsync(team);

            return CreatedAtAction(nameof(GetTeamById), new { id = team.TeamId }, team);
        }

        [HttpPut("UpdateTeam/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, CricketTeam team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            await _repository.UpdateTeamAsync(team);

            return NoContent();
        }

        [HttpDelete("DeleteTeam/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _repository.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            await _repository.DeleteTeamAsync(id);

            return NoContent();
        }
    }
}
