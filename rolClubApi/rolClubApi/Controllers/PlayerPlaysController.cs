using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rolClubApi.Models;

namespace rolClubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerPlaysController : ControllerBase
    {
        private readonly Context _context;

        public PlayerPlaysController(Context context)
        {
            _context = context;
        }

        // GET: api/PlayerPlays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerPlay>>> GetPlayerPlays()
        {
            return await _context.PlayerPlays.ToListAsync();
        }

        // GET: api/PlayerPlays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerPlay>> GetPlayerPlay(int id)
        {
            var playerPlay = await _context.PlayerPlays.FindAsync(id);

            if (playerPlay == null)
            {
                return NotFound();
            }

            return playerPlay;
        }

        // PUT: api/PlayerPlays/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerPlay(int id, PlayerPlay playerPlay)
        {
            if (id != playerPlay.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerPlay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerPlayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayerPlays
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlayerPlay>> PostPlayerPlay(PlayerPlay playerPlay)
        {
            _context.PlayerPlays.Add(playerPlay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerPlay", new { id = playerPlay.Id }, playerPlay);
        }

        // DELETE: api/PlayerPlays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerPlay>> DeletePlayerPlay(int id)
        {
            var playerPlay = await _context.PlayerPlays.FindAsync(id);
            if (playerPlay == null)
            {
                return NotFound();
            }

            _context.PlayerPlays.Remove(playerPlay);
            await _context.SaveChangesAsync();

            return playerPlay;
        }

        private bool PlayerPlayExists(int id)
        {
            return _context.PlayerPlays.Any(e => e.Id == id);
        }
    }
}
