using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cricket_teams
{
    public class CricketTeam
    {
        [Key]
        [Column("teamid")]
        public int TeamId { get; set; }
        [Column("teamname")]
        public string? TeamName { get; set; }
        [Column("logoimage")]
        public string? LogoImage { get; set; }
        [Column("captain")]
        public string? Captain { get; set; }
        [Column("coach")]
        public string? Coach { get; set; }
    }
}
