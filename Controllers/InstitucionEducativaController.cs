using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appComercial.Data;
using appComercial.Models;

namespace appComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCursos()
        {
            var cursos = await _context.Cursos
                .Include(c => c.Docente)
                .Select(c => new {
                    c.Id,
                    c.Nombre,
                    c.Creditos,
                    c.HorasSemanal,
                    c.Ciclo,
                    c.DocenteId,
                    NombreDocente = c.Docente.Nombres + " " + c.Docente.Apellidos
                })
                .ToListAsync();

            return Ok(cursos);
        }


        // GET: /api/cursos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
                return NotFound();

            return curso;
        }

        // GET: /api/cursos/ciclo/{ciclo}
        [HttpGet("ciclo/{ciclo:int}")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursosPorCiclo(int ciclo)
        {
            var cursos = await _context.Cursos
                .Where(c => c.Ciclo == ciclo)
                .ToListAsync();

            if (cursos == null || cursos.Count == 0)
                return NotFound();

            return cursos;
        }

        // POST: /api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        // PUT: /api/cursos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
                return BadRequest();

            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /api/cursos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
                return NotFound();

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
