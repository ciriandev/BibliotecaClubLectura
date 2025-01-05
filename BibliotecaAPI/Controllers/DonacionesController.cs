using BibliotecaAPI.Data;
using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DonacionesController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public DonacionesController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/donaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donacion>>> GetDonaciones()
        {
            return await _context.Donaciones.ToListAsync();
        }

        // GET: api/donaciones/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> GetDonacion(int id)
        {
            var donacion = await _context.Donaciones.FindAsync(id);

            if (donacion == null)
            {
                return NotFound();
            }

            return donacion;
        }

        // POST: api/donaciones
        [HttpPost]
        public async Task<ActionResult<Donacion>> PostDonacion(DonacionDTO donacionDTO)
        {
            var donacion = new Donacion
            {
                LibrosId = donacionDTO.LibrosId,
                FechaDonacion = donacionDTO.FechaDonacion,
                CantidadDonada = donacionDTO.CantidadDonada
            };

            _context.Donaciones.Add(donacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDonacion), new { id = donacion.DonacionesId }, donacion);
        }

        // PUT: api/donaciones/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacion(int id, DonacionDTO donacionDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var donacion = await _context.Donaciones.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            donacion.LibrosId = donacionDto.LibrosId;
            donacion.FechaDonacion = donacionDto.FechaDonacion;
            donacion.CantidadDonada = donacionDto.CantidadDonada;

            _context.Entry(donacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // DELETE: api/donaciones/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacion(int id)
        {
            var donacion = await _context.Donaciones.FindAsync(id);
            if (donacion == null)
            {
                return NotFound();
            }

            _context.Donaciones.Remove(donacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionExists(int id)
        {
            return _context.Donaciones.Any(e => e.DonacionesId == id);
        }
    }
}