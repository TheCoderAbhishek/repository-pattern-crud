using cricket_teams.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cricket_teams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketTeamsController(CricketTeamRepository repository) : ControllerBase
    {
        private readonly CricketTeamRepository _repository = repository;

        [HttpGet]
        public async Task<ActionResult<List<CricketTeam>>> GetTeams()
        {
            var teams = await _repository.GetAllTeamsAsync();
            return Ok(teams);
        }

        // Implement other CRUD actions as needed
    }
}
