using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cricket_teams
{
    public class CricketTeam
    {
        [Key]
        [Column("")]
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? LogoImage { get; set; }
        public string? Captain { get; set; }
        public string? Coach { get; set; }
    }
}
