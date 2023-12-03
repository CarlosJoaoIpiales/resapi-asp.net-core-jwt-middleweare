using actividad_6.Data;
using actividad_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace actividad_6.Controllers
{
    [Authorize(Policy = "Enter")] // Aplica la política de autorización
    [Route("api/[controller]")]
    [ApiController]
    public class AllCoursesController : ControllerBase
    {
        private readonly actividad_6Context _context;

        public AllCoursesController(actividad_6Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetNombresDeCursos()
        {
            try
            {
                var nombresDeCursos = await _context.Cursos
                    .Select(Cursos => Cursos.Name)
                    .ToListAsync();

                return Ok(nombresDeCursos);
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
