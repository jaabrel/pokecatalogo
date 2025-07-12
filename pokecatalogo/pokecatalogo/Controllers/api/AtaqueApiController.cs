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
    /// API endpoints for managing Ataques (attacks).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AtaqueApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AtaqueApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Ataques.
        /// </summary>
        /// <returns>List of AtaqueDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtaqueDto>>> GetAll()
        {
            var ataques = await _context.Ataques.ToListAsync();
            var result = ataques.Select(a => new AtaqueDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Categoria = a.Categoria,
                Descricao = a.Descricao,
                Dano = a.Dano,
                Precisao = a.Precisao,
                PP = a.PP,
                Prioridade = a.Prioridade,
                TipoFk = a.TipoFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets an Ataque by its ID.
        /// </summary>
        /// <param name="id">Ataque ID.</param>
        /// <returns>AtaqueDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AtaqueDto>> Get(int id)
        {
            var ataque = await _context.Ataques.FindAsync(id);
            if (ataque == null)
                return NotFound(new { message = "Ataque not found" });
            var dto = new AtaqueDto
            {
                Id = ataque.Id,
                Nome = ataque.Nome,
                Categoria = ataque.Categoria,
                Descricao = ataque.Descricao,
                Dano = ataque.Dano,
                Precisao = ataque.Precisao,
                PP = ataque.PP,
                Prioridade = ataque.Prioridade,
                TipoFk = ataque.TipoFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Ataque.
        /// </summary>
        /// <param name="dto">AtaqueDto to create.</param>
        /// <returns>The created AtaqueDto.</returns>
        /// <response code="201">Returns the newly created Ataque</response>
        /// <response code="400">If the TipoFk does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<AtaqueDto>> Create([FromBody] AtaqueDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tipoExists = await _context.Tipos.AnyAsync(t => t.Id == dto.TipoFk);
            if (!tipoExists)
                return BadRequest(new { message = "TipoFk does not exist." });
            var ataque = new Ataque
            {
                Nome = dto.Nome,
                Categoria = dto.Categoria,
                Descricao = dto.Descricao,
                Dano = dto.Dano,
                Precisao = dto.Precisao,
                PP = dto.PP,
                Prioridade = dto.Prioridade,
                TipoFk = dto.TipoFk
            };
            _context.Ataques.Add(ataque);
            await _context.SaveChangesAsync();
            dto.Id = ataque.Id;
            return CreatedAtAction(nameof(Get), new { id = ataque.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Ataque.
        /// </summary>
        /// <param name="id">Ataque ID.</param>
        /// <param name="dto">AtaqueDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtaqueDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var ataque = await _context.Ataques.FindAsync(id);
            if (ataque == null)
                return NotFound(new { message = "Ataque not found" });
            var tipoExists = await _context.Tipos.AnyAsync(t => t.Id == dto.TipoFk);
            if (!tipoExists)
                return BadRequest(new { message = "TipoFk does not exist." });
            ataque.Nome = dto.Nome;
            ataque.Categoria = dto.Categoria;
            ataque.Descricao = dto.Descricao;
            ataque.Dano = dto.Dano;
            ataque.Precisao = dto.Precisao;
            ataque.PP = dto.PP;
            ataque.Prioridade = dto.Prioridade;
            ataque.TipoFk = dto.TipoFk;
            _context.Entry(ataque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes an Ataque by its ID.
        /// </summary>
        /// <param name="id">Ataque ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ataque = await _context.Ataques.FindAsync(id);
            if (ataque == null)
                return NotFound(new { message = "Ataque not found" });
            _context.Ataques.Remove(ataque);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 