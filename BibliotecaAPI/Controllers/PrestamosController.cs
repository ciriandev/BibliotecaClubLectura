using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public PrestamosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/prestamos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestado>>> GetPrestamos()
        {
            return await _context.Prestados.ToListAsync();
        }

        // GET: api/prestamos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestado>> GetPrestamo(int id)
        {
            var prestamo = await _context.Prestados.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // POST: api/prestamos
        [HttpPost]
        public async Task<ActionResult<Prestado>> PostPrestado(Prestado prestado)
        {
            _context.Prestados.Add(prestado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrestamo), new { id = prestado.LibrosId }, prestado);
        }

        // PUT: api/prestamos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestado prestado)
        {
            if (id != prestado.LibrosId)
            {
                return BadRequest();
            }

            _context.Entry(prestado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExits(id))
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

        // DELETE: api/prestamos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestados.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            _context.Prestados.Remove(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestamoExits(int id)
        {            
            return _context.Prestados.Any(e => e.PrestadosId == id);
        }
    }
}