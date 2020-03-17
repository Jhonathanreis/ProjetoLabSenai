using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDB.Data;
using WebApiDB.Domain;

namespace WebApiDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public SalaController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Sala
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSala()
        {
            return await _context.Sala.ToListAsync();
        }

        // GET: api/Sala/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(Guid id)
        {
            var sala = await _context.Sala.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            return sala;
        }

        // PUT: api/Sala/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(Guid id, Sala sala)
        {
            if (id != sala.Id)
            {
                return BadRequest();
            }

            _context.Entry(sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Sala
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
            _context.Sala.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSala", new { id = sala.Id }, sala);
        }

        // DELETE: api/Sala/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sala>> DeleteSala(Guid id)
        {
            var sala = await _context.Sala.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.Sala.Remove(sala);
            await _context.SaveChangesAsync();

            return sala;
        }

        private bool SalaExists(Guid id)
        {
            return _context.Sala.Any(e => e.Id == id);
        }
    }
}
