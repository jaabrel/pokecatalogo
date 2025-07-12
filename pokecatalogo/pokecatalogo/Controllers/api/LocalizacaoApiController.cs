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
    /// API endpoints for managing Localizacoes (locations).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocalizacaoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LocalizacaoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Localizacoes.
        /// </summary>
        /// <returns>List of LocalizacaoDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoDto>>> GetAll()
        {
            var localizacoes = await _context.Localizacoes.ToListAsync();
            var result = localizacoes.Select(l => new LocalizacaoDto
            {
                Id = l.Id,
                Nome = l.Nome
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Localizacao by its ID.
        /// </summary>
        /// <param name="id">Localizacao ID.</param>
        /// <returns>LocalizacaoDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalizacaoDto>> Get(int id)
        {
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao == null)
                return NotFound(new { message = "Localizacao not found" });
            var dto = new LocalizacaoDto
            {
                Id = localizacao.Id,
                Nome = localizacao.Nome
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Localizacao.
        /// </summary>
        /// <param name="dto">LocalizacaoDto to create.</param>
        /// <returns>The created LocalizacaoDto.</returns>
        /// <response code="201">Returns the newly created Localizacao</response>
        /// <response code="400">If the model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<LocalizacaoDto>> Create([FromBody] LocalizacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var localizacao = new Localizacao
            {
                Nome = dto.Nome
            };
            _context.Localizacoes.Add(localizacao);
            await _context.SaveChangesAsync();
            dto.Id = localizacao.Id;
            return CreatedAtAction(nameof(Get), new { id = localizacao.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Localizacao.
        /// </summary>
        /// <param name="id">Localizacao ID.</param>
        /// <param name="dto">LocalizacaoDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LocalizacaoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao == null)
                return NotFound(new { message = "Localizacao not found" });
            localizacao.Nome = dto.Nome;
            _context.Entry(localizacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Localizacao by its ID.
        /// </summary>
        /// <param name="id">Localizacao ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao == null)
                return NotFound(new { message = "Localizacao not found" });
            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 