﻿using cricket_teams.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cricket_teams.Controllers
{
    /// <summary>
    /// Controller for managing cricket teams.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CricketTeamsController(CricketTeamRepository repository, ILogger<CricketTeamsController> logger) : ControllerBase
    {
        private readonly CricketTeamRepository _repository = repository;
        private readonly ILogger<CricketTeamsController> _logger = logger;

        /// <summary>
        /// Retrieves all cricket teams.
        /// </summary>
        /// <returns>The list of all cricket teams.</returns>
        [HttpGet("GetTeams")]
        public async Task<ActionResult<List<CricketTeam>>> GetTeams()
        {
            try
            {
                var teams = await _repository.GetAllTeamsAsync();
                _logger.LogInformation("Retrieved all cricket teams successfully.");
                return Ok(teams);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve cricket teams: {errorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve cricket teams. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a cricket team by its ID.
        /// </summary>
        /// <param name="id">The ID of the cricket team to retrieve.</param>
        /// <returns>The cricket team with the specified ID.</returns>
        [HttpGet("GetTeamById/{id}")]
        public async Task<ActionResult<CricketTeam>> GetTeamById(int id)
        {
            try
            {
                var team = await _repository.GetTeamByIdAsync(id);
                if (team == null)
                {
                    _logger.LogWarning("No cricket team found with ID {id}.", id);
                    return NotFound();
                }
                _logger.LogInformation("Retrieved cricket team with ID {id} successfully.", id);
                return team;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to retrieve cricket team with ID {id}: {errorMessage}", id, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve cricket team with ID {id}. {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new cricket team.
        /// </summary>
        /// <param name="team">The cricket team to create.</param>
        /// <returns>The newly created cricket team.</returns>
        [HttpPost("CreateTeam")]
        public async Task<ActionResult<CricketTeam>> CreateTeam(CricketTeam team)
        {
            try
            {
                if (team == null)
                {
                    _logger.LogWarning("Invalid cricket team data received for creation.");
                    return BadRequest();
                }
                await _repository.AddTeamAsync(team);
                _logger.LogInformation("Cricket team registration is successfully done.");
                return CreatedAtAction(nameof(GetTeamById), new { id = team.TeamId }, team);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while creating cricket team: {errorMessage}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating cricket team. {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing cricket team.
        /// </summary>
        /// <param name="id">The ID of the cricket team to update.</param>
        /// <param name="team">The updated cricket team information.</param>
        /// <returns>No content.</returns>
        [HttpPut("UpdateTeam/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, CricketTeam team)
        {
            try
            {
                if (id != team.TeamId)
                {
                    _logger.LogWarning("Mismatch in cricket team ID between request and data.");
                    return BadRequest();
                }

                await _repository.UpdateTeamAsync(team);
                _logger.LogInformation("Cricket team with ID {id} has been updated successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating cricket team with ID {id}: {errorMessage}", id, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating cricket team with ID {id}. {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a cricket team by its ID.
        /// </summary>
        /// <param name="id">The ID of the cricket team to delete.</param>
        [HttpDelete("DeleteTeam/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                var team = await _repository.GetTeamByIdAsync(id);
                if (team == null)
                {
                    _logger.LogWarning("No cricket team found with ID {id}. Delete operation aborted.", id);
                    return NotFound();
                }
                await _repository.DeleteTeamAsync(id);
                _logger.LogInformation("Cricket team with ID {id} has been deleted successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting cricket team with ID {id}: {errorMessage}", id, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting cricket team with ID {id}. {ex.Message}");
            }
        }
    }
}