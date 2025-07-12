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
    /// API endpoints for managing PokemonStats (Pokémon stats).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonStatsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonStatsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all PokemonStats.
        /// </summary>
        /// <returns>List of PokemonStatsDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonStatsDto>>> GetAll()
        {
            var stats = await _context.PokemonStats.ToListAsync();
            var result = stats.Select(s => new PokemonStatsDto
            {
                Id = s.Id,
                Hp = s.Hp,
                Atk = s.Atk,
                Def = s.Def,
                SpA = s.SpA,
                SpD = s.SpD,
                Speed = s.Speed,
                PokemonFk = s.PokemonFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a PokemonStats by its ID.
        /// </summary>
        /// <param name="id">PokemonStats ID.</param>
        /// <returns>PokemonStatsDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonStatsDto>> Get(int id)
        {
            var stat = await _context.PokemonStats.FindAsync(id);
            if (stat == null)
                return NotFound(new { message = "PokemonStats not found" });
            var dto = new PokemonStatsDto
            {
                Id = stat.Id,
                Hp = stat.Hp,
                Atk = stat.Atk,
                Def = stat.Def,
                SpA = stat.SpA,
                SpD = stat.SpD,
                Speed = stat.Speed,
                PokemonFk = stat.PokemonFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new PokemonStats.
        /// </summary>
        /// <param name="dto">PokemonStatsDto to create.</param>
        /// <returns>The created PokemonStatsDto.</returns>
        /// <response code="201">Returns the newly created PokemonStats</response>
        /// <response code="400">If the model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<PokemonStatsDto>> Create([FromBody] PokemonStatsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stat = new PokemonStats
            {
                Hp = dto.Hp,
                Atk = dto.Atk,
                Def = dto.Def,
                SpA = dto.SpA,
                SpD = dto.SpD,
                Speed = dto.Speed,
                PokemonFk = dto.PokemonFk
            };
            _context.PokemonStats.Add(stat);
            await _context.SaveChangesAsync();
            dto.Id = stat.Id;
            return CreatedAtAction(nameof(Get), new { id = stat.Id }, dto);
        }

        /// <summary>
        /// Updates an existing PokemonStats.
        /// </summary>
        /// <param name="id">PokemonStats ID.</param>
        /// <param name="dto">PokemonStatsDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PokemonStatsDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var stat = await _context.PokemonStats.FindAsync(id);
            if (stat == null)
                return NotFound(new { message = "PokemonStats not found" });
            stat.Hp = dto.Hp;
            stat.Atk = dto.Atk;
            stat.Def = dto.Def;
            stat.SpA = dto.SpA;
            stat.SpD = dto.SpD;
            stat.Speed = dto.Speed;
            stat.PokemonFk = dto.PokemonFk;
            _context.Entry(stat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a PokemonStats by its ID.
        /// </summary>
        /// <param name="id">PokemonStats ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stat = await _context.PokemonStats.FindAsync(id);
            if (stat == null)
                return NotFound(new { message = "PokemonStats not found" });
            _context.PokemonStats.Remove(stat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 