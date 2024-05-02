using Microsoft.EntityFrameworkCore;

namespace cricket_teams.Data
{
    /// <summary>
    /// Represents the database context for the cricket teams application.
    /// </summary>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the DbSet representing the cricket teams in the database.
        /// </summary>
        public DbSet<CricketTeam> CricketTeams { get; set; }
    }
}