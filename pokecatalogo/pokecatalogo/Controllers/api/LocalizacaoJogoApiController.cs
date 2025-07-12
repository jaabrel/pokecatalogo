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
    /// API endpoints for managing LocalizacaoJogos (location-game links).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocalizacaoJogoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LocalizacaoJogoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all LocalizacaoJogos.
        /// </summary>
        /// <returns>List of LocalizacaoJogoDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoJogoDto>>> GetAll()
        {
            var localizacoesJogo = await _context.LocalizacaoJogos.ToListAsync();
            var result = localizacoesJogo.Select(lj => new LocalizacaoJogoDto
            {
                Id = lj.Id,
                JogoFk = lj.JogoFk,
                LocalizacaoFk = lj.LocalizacaoFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a LocalizacaoJogo by its ID.
        /// </summary>
        /// <param name="id">LocalizacaoJogo ID.</param>
        /// <returns>LocalizacaoJogoDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalizacaoJogoDto>> Get(int id)
        {
            var lj = await _context.LocalizacaoJogos.FindAsync(id);
            if (lj == null)
                return NotFound(new { message = "LocalizacaoJogo not found" });
            var dto = new LocalizacaoJogoDto
            {
                Id = lj.Id,
                JogoFk = lj.JogoFk,
                LocalizacaoFk = lj.LocalizacaoFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new LocalizacaoJogo.
        /// </summary>
        /// <param name="dto">LocalizacaoJogoDto to create.</param>
        /// <returns>The created LocalizacaoJogoDto.</returns>
        /// <response code="201">Returns the newly created LocalizacaoJogo</response>
        /// <response code="400">If the model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<LocalizacaoJogoDto>> Create([FromBody] LocalizacaoJogoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lj = new LocalizacaoJogo
            {
                JogoFk = dto.JogoFk,
                LocalizacaoFk = dto.LocalizacaoFk
            };
            _context.LocalizacaoJogos.Add(lj);
            await _context.SaveChangesAsync();
            dto.Id = lj.Id;
            return CreatedAtAction(nameof(Get), new { id = lj.Id }, dto);
        }

        /// <summary>
        /// Updates an existing LocalizacaoJogo.
        /// </summary>
        /// <param name="id">LocalizacaoJogo ID.</param>
        /// <param name="dto">LocalizacaoJogoDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LocalizacaoJogoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lj = await _context.LocalizacaoJogos.FindAsync(id);
            if (lj == null)
                return NotFound(new { message = "LocalizacaoJogo not found" });
            lj.JogoFk = dto.JogoFk;
            lj.LocalizacaoFk = dto.LocalizacaoFk;
            _context.Entry(lj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a LocalizacaoJogo by its ID.
        /// </summary>
        /// <param name="id">LocalizacaoJogo ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lj = await _context.LocalizacaoJogos.FindAsync(id);
            if (lj == null)
                return NotFound(new { message = "LocalizacaoJogo not found" });
            _context.LocalizacaoJogos.Remove(lj);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 