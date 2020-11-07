using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;

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
        public async Task<ActionResult<IEnumerable<TbAssociado>>> GetTbAssociado()
        {
            return await _context.TbAssociado.ToListAsync();
        }

        // GET: api/Associados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAssociado>> GetTbAssociado(int id)
        {
            var tbAssociado = await _context.TbAssociado.FindAsync(id);

            if (tbAssociado == null)
            {
                return NotFound();
            }

            return tbAssociado;
        }

        // PUT: api/Associados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAssociado(int id, TbAssociado tbAssociado)
        {
            if (id != tbAssociado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbAssociado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAssociadoExists(id))
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
        public async Task<ActionResult<TbAssociado>> PostTbAssociado(TbAssociado tbAssociado)
        {
            _context.TbAssociado.Add(tbAssociado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAssociado", new { id = tbAssociado.Id }, tbAssociado);
        }

        // DELETE: api/Associados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbAssociado>> DeleteTbAssociado(int id)
        {
            var tbAssociado = await _context.TbAssociado.FindAsync(id);
            if (tbAssociado == null)
            {
                return NotFound();
            }

            _context.TbAssociado.Remove(tbAssociado);
            await _context.SaveChangesAsync();

            return tbAssociado;
        }

        private bool TbAssociadoExists(int id)
        {
            return _context.TbAssociado.Any(e => e.Id == id);
        }
    }
}
