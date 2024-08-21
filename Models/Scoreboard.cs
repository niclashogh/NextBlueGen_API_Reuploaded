using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextBlueGen_API.Models
{
    [PrimaryKey("PlayerName"),Table("Scoreboard")]
    public class Scoreboard
    {
        public string PlayerName { get; set; }
        [Required]
        public int Score {  get; set; }

    }
}
