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
    /// API endpoints for managing PokemonLocalizacoes (Pokémon-location links).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonLocalizacaoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonLocalizacaoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all PokemonLocalizacoes.
        /// </summary>
        /// <returns>List of PokemonLocalizacaoDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonLocalizacaoDto>>> GetAll()
        {
            var pls = await _context.PokemonLocalizacoes.ToListAsync();
            var result = pls.Select(pl => new PokemonLocalizacaoDto
            {
                Id = pl.Id,
                PokemonFk = pl.PokemonFk,
                LocalizacaoFk = pl.LocalizacaoFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a PokemonLocalizacao by its ID.
        /// </summary>
        /// <param name="id">PokemonLocalizacao ID.</param>
        /// <returns>PokemonLocalizacaoDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonLocalizacaoDto>> Get(int id)
        {
            var pl = await _context.PokemonLocalizacoes.FindAsync(id);
            if (pl == null)
                return NotFound(new { message = "PokemonLocalizacao not found" });
            var dto = new PokemonLocalizacaoDto
            {
                Id = pl.Id,
                PokemonFk = pl.PokemonFk,
                LocalizacaoFk = pl.LocalizacaoFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new PokemonLocalizacao.
        /// </summary>
        /// <param name="dto">PokemonLocalizacaoDto to create.</param>
        /// <returns>The created PokemonLocalizacaoDto.</returns>
        /// <response code="201">Returns the newly created PokemonLocalizacao</response>
        /// <response code="400">If any foreign key does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<PokemonLocalizacaoDto>> Create([FromBody] PokemonLocalizacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            var localizacaoExists = await _context.Localizacoes.AnyAsync(l => l.Id == dto.LocalizacaoFk);
            if (!localizacaoExists)
                return BadRequest(new { message = "LocalizacaoFk does not exist." });
            var pl = new PokemonLocalizacao
            {
                PokemonFk = dto.PokemonFk,
                LocalizacaoFk = dto.LocalizacaoFk
            };
            _context.PokemonLocalizacoes.Add(pl);
            await _context.SaveChangesAsync();
            dto.Id = pl.Id;
            return CreatedAtAction(nameof(Get), new { id = pl.Id }, dto);
        }

        /// <summary>
        /// Updates an existing PokemonLocalizacao.
        /// </summary>
        /// <param name="id">PokemonLocalizacao ID.</param>
        /// <param name="dto">PokemonLocalizacaoDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PokemonLocalizacaoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pl = await _context.PokemonLocalizacoes.FindAsync(id);
            if (pl == null)
                return NotFound(new { message = "PokemonLocalizacao not found" });
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            var localizacaoExists = await _context.Localizacoes.AnyAsync(l => l.Id == dto.LocalizacaoFk);
            if (!localizacaoExists)
                return BadRequest(new { message = "LocalizacaoFk does not exist." });
            pl.PokemonFk = dto.PokemonFk;
            pl.LocalizacaoFk = dto.LocalizacaoFk;
            _context.Entry(pl).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a PokemonLocalizacao by its ID.
        /// </summary>
        /// <param name="id">PokemonLocalizacao ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pl = await _context.PokemonLocalizacoes.FindAsync(id);
            if (pl == null)
                return NotFound(new { message = "PokemonLocalizacao not found" });
            _context.PokemonLocalizacoes.Remove(pl);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 