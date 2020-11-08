using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadosController : ControllerBase
    {
        private readonly ProtecaoVeicularContext _context;

        public AssociadosController(ProtecaoVeicularContext context)
        {
            _context = context;
        }

        // GET: api/Associados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associados>>> GetAssociados()
        {
            return await _context.Associados.ToListAsync();
        }

        // GET: api/Associados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Associados>> GetAssociados(int id)
        {
            var Associados = await _context.Associados.FindAsync(id);

            if (Associados == null)
            {
                return NotFound();
            }

            return Associados;
        }

        // PUT: api/Associados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssociados(int id, Associados Associados)
        {
            if (id != Associados.Id)
            {
                return BadRequest();
            }

            _context.Entry(Associados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociadosExists(id))
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

        // POST: api/Associados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Associados>> PostAssociados(Associados Associados)
        {
            _context.Associados.Add(Associados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssociados", new { id = Associados.Id }, Associados);
        }

        // DELETE: api/Associados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Associados>> DeleteAssociados(int id)
        {
            var Associados = await _context.Associados.FindAsync(id);
            if (Associados == null)
            {
                return NotFound();
            }

            _context.Associados.Remove(Associados);
            await _context.SaveChangesAsync();

            return Associados;
        }

        private bool AssociadosExists(int id)
        {
            return _context.Associados.Any(e => e.Id == id);
        }
    }
}
