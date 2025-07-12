using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokecatalogo.Data;
using pokecatalogo.Models;
using pokecatalogo.Models.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace pokecatalogo.Controllers.api
{
    /// <summary>
    /// API endpoints for managing Tipos (types).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TipoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TipoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Tipos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDto>>> GetAll()
        {
            var tipos = await _context.Tipos.ToListAsync();
            var result = tipos.Select(t => new TipoDto
            {
                Id = t.Id,
                Nome = t.Nome.ToString(),
                Cor = t.Cor
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Tipo by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDto>> Get(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
                return NotFound(new { message = "Tipo not found" });
            var dto = new TipoDto
            {
                Id = tipo.Id,
                Nome = tipo.Nome.ToString(),
                Cor = tipo.Cor
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Tipo.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TipoDto>> Create([FromBody] TipoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tipo = new Tipo
            {
                Nome = Enum.TryParse<TiposEnum>(dto.Nome, out var nome) ? nome : throw new ArgumentException("Invalid Tipo Nome"),
                Cor = dto.Cor
            };
            _context.Tipos.Add(tipo);
            await _context.SaveChangesAsync();
            dto.Id = tipo.Id;
            return CreatedAtAction(nameof(Get), new { id = tipo.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Tipo.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
                return NotFound(new { message = "Tipo not found" });
            tipo.Nome = Enum.TryParse<TiposEnum>(dto.Nome, out var nome) ? nome : throw new ArgumentException("Invalid Tipo Nome");
            tipo.Cor = dto.Cor;
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Tipo by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
                return NotFound(new { message = "Tipo not found" });
            _context.Tipos.Remove(tipo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 