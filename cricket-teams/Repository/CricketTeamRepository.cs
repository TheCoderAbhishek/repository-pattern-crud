using cricket_teams.Data;
using Microsoft.EntityFrameworkCore;

namespace cricket_teams.Repository
{
    public class CricketTeamRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<CricketTeam>> GetAllTeamsAsync()
        {
            return await _context.CricketTeams.ToListAsync();
        }

        public async Task<CricketTeam?> GetTeamByIdAsync(int id)
        {
            return await _context.CricketTeams.FindAsync(id);
        }

        public async Task AddTeamAsync(CricketTeam team)
        {
            _context.CricketTeams.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamAsync(CricketTeam team)
        {
            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

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
