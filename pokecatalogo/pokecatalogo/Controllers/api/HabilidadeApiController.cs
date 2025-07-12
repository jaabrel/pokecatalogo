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
    /// API endpoints for managing Habilidades (abilities).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HabilidadeApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HabilidadeApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Habilidades.
        /// </summary>
        /// <returns>List of HabilidadeDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadeDto>>> GetAll()
        {
            var habilidades = await _context.Habilidades.ToListAsync();
            var result = habilidades.Select(h => new HabilidadeDto
            {
                Id = h.Id,
                Nome = h.Nome,
                Descricao = h.Descricao,
                PokemonFk = h.PokemonFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Habilidade by its ID.
        /// </summary>
        /// <param name="id">Habilidade ID.</param>
        /// <returns>HabilidadeDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HabilidadeDto>> Get(int id)
        {
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade == null)
                return NotFound(new { message = "Habilidade not found" });
            var dto = new HabilidadeDto
            {
                Id = habilidade.Id,
                Nome = habilidade.Nome,
                Descricao = habilidade.Descricao,
                PokemonFk = habilidade.PokemonFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Habilidade.
        /// </summary>
        /// <param name="dto">HabilidadeDto to create.</param>
        /// <returns>The created HabilidadeDto.</returns>
        /// <response code="201">Returns the newly created Habilidade</response>
        /// <response code="400">If the PokemonFk does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<HabilidadeDto>> Create([FromBody] HabilidadeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            var habilidade = new Habilidade
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                PokemonFk = dto.PokemonFk
            };
            _context.Habilidades.Add(habilidade);
            await _context.SaveChangesAsync();
            dto.Id = habilidade.Id;
            return CreatedAtAction(nameof(Get), new { id = habilidade.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Habilidade.
        /// </summary>
        /// <param name="id">Habilidade ID.</param>
        /// <param name="dto">HabilidadeDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HabilidadeDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade == null)
                return NotFound(new { message = "Habilidade not found" });
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            habilidade.Nome = dto.Nome;
            habilidade.Descricao = dto.Descricao;
            habilidade.PokemonFk = dto.PokemonFk;
            _context.Entry(habilidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Habilidade by its ID.
        /// </summary>
        /// <param name="id">Habilidade ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var habilidade = await _context.Habilidades.FindAsync(id);
            if (habilidade == null)
                return NotFound(new { message = "Habilidade not found" });
            _context.Habilidades.Remove(habilidade);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 