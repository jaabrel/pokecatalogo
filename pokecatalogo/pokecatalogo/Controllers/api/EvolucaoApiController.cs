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
    /// API endpoints for managing Evolucoes (evolutions).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EvolucaoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EvolucaoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Evolucoes.
        /// </summary>
        /// <returns>List of EvolucaoDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvolucaoDto>>> GetAll()
        {
            var evolucoes = await _context.Evolucoes.ToListAsync();
            var result = evolucoes.Select(e => new EvolucaoDto
            {
                Id = e.Id,
                Descricao = e.Descricao,
                PokemonFk1 = e.PokemonFk1,
                PokemonFk2 = e.PokemonFk2
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets an Evolucao by its ID.
        /// </summary>
        /// <param name="id">Evolucao ID.</param>
        /// <returns>EvolucaoDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EvolucaoDto>> Get(int id)
        {
            var evolucao = await _context.Evolucoes.FindAsync(id);
            if (evolucao == null)
                return NotFound(new { message = "Evolucao not found" });
            var dto = new EvolucaoDto
            {
                Id = evolucao.Id,
                Descricao = evolucao.Descricao,
                PokemonFk1 = evolucao.PokemonFk1,
                PokemonFk2 = evolucao.PokemonFk2
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Evolucao.
        /// </summary>
        /// <param name="dto">EvolucaoDto to create.</param>
        /// <returns>The created EvolucaoDto.</returns>
        /// <response code="201">Returns the newly created Evolucao</response>
        /// <response code="400">If the PokemonFk1 or PokemonFk2 does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<EvolucaoDto>> Create([FromBody] EvolucaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pokemon1Exists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk1);
            if (!pokemon1Exists)
                return BadRequest(new { message = "PokemonFk1 does not exist." });
            if (dto.PokemonFk2.HasValue)
            {
                var pokemon2Exists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk2);
                if (!pokemon2Exists)
                    return BadRequest(new { message = "PokemonFk2 does not exist." });
            }
            var evolucao = new Evolucao
            {
                Descricao = dto.Descricao,
                PokemonFk1 = dto.PokemonFk1,
                PokemonFk2 = dto.PokemonFk2
            };
            _context.Evolucoes.Add(evolucao);
            await _context.SaveChangesAsync();
            dto.Id = evolucao.Id;
            return CreatedAtAction(nameof(Get), new { id = evolucao.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Evolucao.
        /// </summary>
        /// <param name="id">Evolucao ID.</param>
        /// <param name="dto">EvolucaoDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvolucaoDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var evolucao = await _context.Evolucoes.FindAsync(id);
            if (evolucao == null)
                return NotFound(new { message = "Evolucao not found" });
            var pokemon1Exists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk1);
            if (!pokemon1Exists)
                return BadRequest(new { message = "PokemonFk1 does not exist." });
            if (dto.PokemonFk2.HasValue)
            {
                var pokemon2Exists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk2);
                if (!pokemon2Exists)
                    return BadRequest(new { message = "PokemonFk2 does not exist." });
            }
            evolucao.Descricao = dto.Descricao;
            evolucao.PokemonFk1 = dto.PokemonFk1;
            evolucao.PokemonFk2 = dto.PokemonFk2;
            _context.Entry(evolucao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes an Evolucao by its ID.
        /// </summary>
        /// <param name="id">Evolucao ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evolucao = await _context.Evolucoes.FindAsync(id);
            if (evolucao == null)
                return NotFound(new { message = "Evolucao not found" });
            _context.Evolucoes.Remove(evolucao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 