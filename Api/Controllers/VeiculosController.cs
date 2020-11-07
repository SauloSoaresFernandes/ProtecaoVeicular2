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
    public class VeiculosController : ControllerBase
    {
        private readonly ProtecaoVeicularContext _context;

        public VeiculosController(ProtecaoVeicularContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbVeiculo>>> GetTbVeiculo()
        {
            return await _context.TbVeiculo.ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbVeiculo>> GetTbVeiculo(int id)
        {
            var tbVeiculo = await _context.TbVeiculo.FindAsync(id);

            if (tbVeiculo == null)
            {
                return NotFound();
            }

            return tbVeiculo;
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbVeiculo(int id, TbVeiculo tbVeiculo)
        {
            if (id != tbVeiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbVeiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbVeiculoExists(id))
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
        public async Task<ActionResult<TbVeiculo>> PostTbVeiculo(TbVeiculo tbVeiculo)
        {
            _context.TbVeiculo.Add(tbVeiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbVeiculo", new { id = tbVeiculo.Id }, tbVeiculo);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbVeiculo>> DeleteTbVeiculo(int id)
        {
            var tbVeiculo = await _context.TbVeiculo.FindAsync(id);
            if (tbVeiculo == null)
            {
                return NotFound();
            }

            _context.TbVeiculo.Remove(tbVeiculo);
            await _context.SaveChangesAsync();

            return tbVeiculo;
        }

        private bool TbVeiculoExists(int id)
        {
            return _context.TbVeiculo.Any(e => e.Id == id);
        }
    }
}
