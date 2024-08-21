using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextBlueGen_API.Data;
using NextBlueGen_API.Models;
using System.Diagnostics;
using System.Text.Json;

namespace NextBlueGen_API.Controllers
{
    [Route("/scoreboard")]
    [ApiController]
    public class ScoreboardController : ControllerBase
    {
        private readonly ScoreboardContext context;

        public ScoreboardController(ScoreboardContext context)
        {
            this.context = context;
        }

        #region AddAsync
        [HttpPost("/add")]
        public async Task<ActionResult<Scoreboard>> AddAsync([Bind] Scoreboard scoreboard)
        {
            if (ModelState.IsValid)
            {
                context.Scoreboard.Add(scoreboard);
                await context.SaveChangesAsync();

                return Ok(context.Scoreboard);
            }
            else
                return BadRequest("");

        }
        #endregion

        [HttpGet("/get")]
        public async Task<ActionResult<IEnumerable<Scoreboard>>> GetAllAsync()
        {
            if (context.Scoreboard == null)
            {
                return NotFound("No Items was found");
            }

            IEnumerable<Scoreboard> scoreboards = await context.Scoreboard.ToListAsync();

            var jsonSerialized = JsonSerializer.Serialize(scoreboards);
            Debug.WriteLine(jsonSerialized);

            return Ok(jsonSerialized);
        }
    }
}
