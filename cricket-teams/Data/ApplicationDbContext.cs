using Microsoft.EntityFrameworkCore;

namespace cricket_teams.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CricketTeam> CricketTeams { get; set; }
    }
}