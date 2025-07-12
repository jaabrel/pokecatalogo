using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokecatalogo.Data;
using pokecatalogo.Models;
using pokecatalogo.Models.ApiModels;

namespace pokecatalogo.Controllers.api
{
    /// <summary>
    /// API endpoints for managing Jogos (games).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class JogoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public JogoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Jogos.
        /// </summary>
        /// <returns>List of JogoDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoDto>>> GetAll()
        {
            var jogos = await _context.Jogos.ToListAsync();
            var result = jogos.Select(j => new JogoDto
            {
                Id = j.Id,
                Nome = j.Nome,
                DataLancamento = j.DataLancamento
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Jogo by its ID.
        /// </summary>
        /// <param name="id">Jogo ID.</param>
        /// <returns>JogoDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<JogoDto>> Get(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
                return NotFound(new { message = "Jogo not found" });
            var dto = new JogoDto
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                DataLancamento = jogo.DataLancamento
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Jogo.
        /// </summary>
        /// <param name="dto">JogoDto to create.</param>
        /// <returns>The created JogoDto.</returns>
        /// <response code="201">Returns the newly created Jogo</response>
        /// <response code="400">If the model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<JogoDto>> Create([FromBody] JogoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var jogo = new Jogo
            {
                Nome = dto.Nome,
                DataLancamento = dto.DataLancamento
            };
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();
            dto.Id = jogo.Id;
            return CreatedAtAction(nameof(Get), new { id = jogo.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Jogo.
        /// </summary>
        /// <param name="id">Jogo ID.</param>
        /// <param name="dto">JogoDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JogoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
                return NotFound(new { message = "Jogo not found" });
            jogo.Nome = dto.Nome;
            jogo.DataLancamento = dto.DataLancamento;
            _context.Entry(jogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Jogo by its ID.
        /// </summary>
        /// <param name="id">Jogo ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null)
                return NotFound(new { message = "Jogo not found" });
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 