using BibliotecaAPI.Data;
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
        public async Task<ActionResult<IEnumerable<Donacion>>> GetLibros()
        {
            return await _context.Donaciones.ToListAsync();
        }

        // GET: api/donaciones/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacion>> GetLibro(int id)
        {
            var donacion = await _context.Donaciones.FindAsync(id);

            if (donacion == null)
            {
                return NotFound();
            }

            return donacion;
        }
    }
}