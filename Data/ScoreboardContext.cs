using Microsoft.EntityFrameworkCore;
using NextBlueGen_API.Models;

namespace NextBlueGen_API.Data
{
    public class ScoreboardContext : DbContext
    {
        public ScoreboardContext(DbContextOptions<ScoreboardContext> options) : base(options) { }

        public DbSet<Scoreboard> Scoreboard { get; set; }

    }
}
