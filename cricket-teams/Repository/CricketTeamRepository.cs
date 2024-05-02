using cricket_teams.Data;
using Microsoft.EntityFrameworkCore;

namespace cricket_teams.Repository
{
    /// <summary>
    /// Repository for managing cricket teams in the database.
    /// </summary>
    public class CricketTeamRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        /// <summary>
        /// Retrieves all cricket teams asynchronously.
        /// </summary>
        /// <returns>The list of all cricket teams.</returns>
        public async Task<List<CricketTeam>> GetAllTeamsAsync()
        {
            return await _context.CricketTeams.ToListAsync();
        }

        /// <summary>
        /// Retrieves a cricket team by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the cricket team to retrieve.</param>
        /// <returns>The cricket team with the specified ID, or null if not found.</returns>
        public async Task<CricketTeam?> GetTeamByIdAsync(int id)
        {
            return await _context.CricketTeams.FindAsync(id);
        }

        /// <summary>
        /// Adds a new cricket team asynchronously.
        /// </summary>
        /// <param name="team">The cricket team to add.</param>
        public async Task AddTeamAsync(CricketTeam team)
        {
            _context.CricketTeams.Add(team);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing cricket team asynchronously.
        /// </summary>
        /// <param name="team">The updated cricket team information.</param>
        public async Task UpdateTeamAsync(CricketTeam team)
        {
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a cricket team by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the cricket team to delete.</param>
        public async Task DeleteTeamAsync(int id)
        {
            var team = await GetTeamByIdAsync(id);
            if (team != null)
            {
                _context.CricketTeams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }
    }
}