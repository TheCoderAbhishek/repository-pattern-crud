using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cricket_teams
{
    /// <summary>
    /// Represents a cricket team.
    /// </summary>
    public class CricketTeam
    {
        /// <summary>
        /// Gets or sets the unique identifier for the cricket team.
        /// </summary>
        [Key]
        [Column("teamid")]
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cricket team.
        /// </summary>
        [Column("teamname")]
        public string? TeamName { get; set; }

        /// <summary>
        /// Gets or sets the path to the logo image of the cricket team.
        /// </summary>
        [Column("logoimage")]
        public string? LogoImage { get; set; }

        /// <summary>
        /// Gets or sets the name of the captain of the cricket team.
        /// </summary>
        [Column("captain")]
        public string? Captain { get; set; }

        /// <summary>
        /// Gets or sets the name of the coach of the cricket team.
        /// </summary>
        [Column("coach")]
        public string? Coach { get; set; }
    }
}
