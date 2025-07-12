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
    /// API endpoints for managing PokemonHabilidades (Pokémon-ability links).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonHabilidadeApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonHabilidadeApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all PokemonHabilidades.
        /// </summary>
        /// <returns>List of PokemonHabilidadeDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonHabilidadeDto>>> GetAll()
        {
            var phs = await _context.PokemonHabilidades.ToListAsync();
            var result = phs.Select(ph => new PokemonHabilidadeDto
            {
                Id = ph.Id,
                PokemonFk = ph.PokemonFk,
                HabilidadeFk = ph.HabilidadeFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a PokemonHabilidade by its ID.
        /// </summary>
        /// <param name="id">PokemonHabilidade ID.</param>
        /// <returns>PokemonHabilidadeDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonHabilidadeDto>> Get(int id)
        {
            var ph = await _context.PokemonHabilidades.FindAsync(id);
            if (ph == null)
                return NotFound(new { message = "PokemonHabilidade not found" });
            var dto = new PokemonHabilidadeDto
            {
                Id = ph.Id,
                PokemonFk = ph.PokemonFk,
                HabilidadeFk = ph.HabilidadeFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new PokemonHabilidade.
        /// </summary>
        /// <param name="dto">PokemonHabilidadeDto to create.</param>
        /// <returns>The created PokemonHabilidadeDto.</returns>
        /// <response code="201">Returns the newly created PokemonHabilidade</response>
        /// <response code="400">If any foreign key does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<PokemonHabilidadeDto>> Create([FromBody] PokemonHabilidadeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            var habilidadeExists = await _context.Habilidades.AnyAsync(h => h.Id == dto.HabilidadeFk);
            if (!habilidadeExists)
                return BadRequest(new { message = "HabilidadeFk does not exist." });
            var ph = new PokemonHabilidade
            {
                PokemonFk = dto.PokemonFk,
                HabilidadeFk = dto.HabilidadeFk
            };
            _context.PokemonHabilidades.Add(ph);
            await _context.SaveChangesAsync();
            dto.Id = ph.Id;
            return CreatedAtAction(nameof(Get), new { id = ph.Id }, dto);
        }

        /// <summary>
        /// Updates an existing PokemonHabilidade.
        /// </summary>
        /// <param name="id">PokemonHabilidade ID.</param>
        /// <param name="dto">PokemonHabilidadeDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PokemonHabilidadeDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var ph = await _context.PokemonHabilidades.FindAsync(id);
            if (ph == null)
                return NotFound(new { message = "PokemonHabilidade not found" });
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            var habilidadeExists = await _context.Habilidades.AnyAsync(h => h.Id == dto.HabilidadeFk);
            if (!habilidadeExists)
                return BadRequest(new { message = "HabilidadeFk does not exist." });
            ph.PokemonFk = dto.PokemonFk;
            ph.HabilidadeFk = dto.HabilidadeFk;
            _context.Entry(ph).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a PokemonHabilidade by its ID.
        /// </summary>
        /// <param name="id">PokemonHabilidade ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ph = await _context.PokemonHabilidades.FindAsync(id);
            if (ph == null)
                return NotFound(new { message = "PokemonHabilidade not found" });
            _context.PokemonHabilidades.Remove(ph);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 