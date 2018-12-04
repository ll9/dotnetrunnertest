using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NsSqliteServer.Data;
using NsSqliteServer.Models;

namespace Ns_Sqlite_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichtpunktController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LichtpunktController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Lichtpunkt
        [HttpGet]
        public IEnumerable<Lichtpunkt> GetLichtpunkt()
        {
            return _context.Lichtpunkt;
        }

        // GET: api/Lichtpunkt/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLichtpunkt([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lichtpunkt = await _context.Lichtpunkt.FindAsync(id);

            if (lichtpunkt == null)
            {
                return NotFound();
            }

            return Ok(lichtpunkt);
        }

        // PUT: api/Lichtpunkt/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichtpunkt([FromRoute] string id, [FromBody] Lichtpunkt lichtpunkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lichtpunkt.Id)
            {
                return BadRequest();
            }

            _context.Entry(lichtpunkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichtpunktExists(id))
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

        // POST: api/Lichtpunkt
        [HttpPost]
        public async Task<IActionResult> PostLichtpunkt([FromBody] Lichtpunkt lichtpunkt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lichtpunkt.Add(lichtpunkt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichtpunkt", new { id = lichtpunkt.Id }, lichtpunkt);
        }

        // POST: api/Lichtpunkt
        [HttpPost("Batch")]
        public async Task<IActionResult> PostLichtpunkt([FromBody] IEnumerable<Lichtpunkt> lichtpunkte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lichtpunkt.AddRange(lichtpunkte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLichtpunkt", new { ids = lichtpunkte.Select(lp => lp.Id) }, lichtpunkte);
        }

        // DELETE: api/Lichtpunkt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichtpunkt([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lichtpunkt = await _context.Lichtpunkt.FindAsync(id);
            if (lichtpunkt == null)
            {
                return NotFound();
            }

            _context.Lichtpunkt.Remove(lichtpunkt);
            await _context.SaveChangesAsync();

            return Ok(lichtpunkt);
        }

        private bool LichtpunktExists(string id)
        {
            return _context.Lichtpunkt.Any(e => e.Id == id);
        }
    }
}