using cricket_teams.Data;
using Microsoft.EntityFrameworkCore;

namespace cricket_teams.Repository
{
    public class CricketTeamRepository
    {
        private readonly ApplicationDbContext _context;

        public CricketTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CricketTeam>> GetAllTeamsAsync()
        {
            return await _context.CricketTeams.ToListAsync();
        }
    }
}
