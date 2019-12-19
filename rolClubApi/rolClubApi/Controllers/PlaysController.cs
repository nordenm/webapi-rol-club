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
    public class PlaysController : ControllerBase
    {
        private readonly Context _context;

        public PlaysController(Context context)
        {
            _context = context;
        }

        // GET: api/Plays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Play>>> GetPlays()
        {
            return await _context.Plays.ToListAsync();
        }

        // GET: api/Plays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Play>> GetPlay(int id)
        {
            var play = await _context.Plays.FindAsync(id);

            if (play == null)
            {
                return NotFound();
            }

            return play;
        }

        // PUT: api/Plays/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlay(int id, Play play)
        {
            if (id != play.Id)
            {
                return BadRequest();
            }

            _context.Entry(play).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayExists(id))
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

        // POST: api/Plays
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Play>> PostPlay(Play play)
        {
            _context.Plays.Add(play);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlay", new { id = play.Id }, play);
        }

        // DELETE: api/Plays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Play>> DeletePlay(int id)
        {
            var play = await _context.Plays.FindAsync(id);
            if (play == null)
            {
                return NotFound();
            }

            _context.Plays.Remove(play);
            await _context.SaveChangesAsync();

            return play;
        }

        private bool PlayExists(int id)
        {
            return _context.Plays.Any(e => e.Id == id);
        }
    }
}
