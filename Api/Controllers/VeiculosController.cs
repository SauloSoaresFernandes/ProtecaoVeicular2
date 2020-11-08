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
    public class VeiculosController : ControllerBase
    {
        private readonly ProtecaoVeicularContext _context;

        public VeiculosController(ProtecaoVeicularContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculos>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculos>> GetVeiculos(int id)
        {
            var Veiculos = await _context.Veiculos.FindAsync(id);

            if (Veiculos == null)
            {
                return NotFound();
            }

            return Veiculos;
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculos(int id, Veiculos Veiculos)
        {
            if (id != Veiculos.Id)
            {
                return BadRequest();
            }

            _context.Entry(Veiculos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculosExists(id))
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

        // POST: api/Veiculos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Veiculos>> PostVeiculos(Veiculos Veiculos)
        {
            _context.Veiculos.Add(Veiculos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeiculos", new { id = Veiculos.Id }, Veiculos);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Veiculos>> DeleteVeiculos(int id)
        {
            var Veiculos = await _context.Veiculos.FindAsync(id);
            if (Veiculos == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(Veiculos);
            await _context.SaveChangesAsync();

            return Veiculos;
        }

        private bool VeiculosExists(int id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }
    }
}
