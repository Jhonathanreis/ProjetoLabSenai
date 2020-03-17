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
    public class AcessoController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AcessoController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Acesso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acesso>>> GetAcesso()
        {
            return await _context.Acesso.ToListAsync();
        }

        // GET: api/Acesso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acesso>> GetAcesso(Guid id)
        {
            var acesso = await _context.Acesso.FindAsync(id);

            if (acesso == null)
            {
                return NotFound();
            }

            return acesso;
        }

        // PUT: api/Acesso/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcesso(Guid id, Acesso acesso)
        {
            if (id != acesso.Id)
            {
                return BadRequest();
            }

            _context.Entry(acesso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcessoExists(id))
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

        // POST: api/Acesso
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Acesso>> PostAcesso(Acesso acesso)
        {
            _context.Acesso.Add(acesso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcesso", new { id = acesso.Id }, acesso);
        }

        // DELETE: api/Acesso/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acesso>> DeleteAcesso(Guid id)
        {
            var acesso = await _context.Acesso.FindAsync(id);
            if (acesso == null)
            {
                return NotFound();
            }

            _context.Acesso.Remove(acesso);
            await _context.SaveChangesAsync();

            return acesso;
        }

        private bool AcessoExists(Guid id)
        {
            return _context.Acesso.Any(e => e.Id == id);
        }
    }
}
