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
    /// API endpoints for managing PokemonEquipas (Pokémon-team links).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonEquipaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonEquipaApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all PokemonEquipas.
        /// </summary>
        /// <returns>List of PokemonEquipaDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonEquipaDto>>> GetAll()
        {
            var pes = await _context.PokemonEquipas.ToListAsync();
            var result = pes.Select(pe => new PokemonEquipaDto
            {
                Id = pe.Id,
                EquipaFk = pe.EquipaFk,
                PokemonFk = pe.PokemonFk,
                Nivel = pe.Nivel,
                Alcunha = pe.Alcunha,
                PosicaoNaEquipa = pe.PosicaoNaEquipa,
                Ataques = new List<int>(), // Not mapped in entity
                HabilidadeFk = pe.HabilidadeFk
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a PokemonEquipa by its ID.
        /// </summary>
        /// <param name="id">PokemonEquipa ID.</param>
        /// <returns>PokemonEquipaDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonEquipaDto>> Get(int id)
        {
            var pe = await _context.PokemonEquipas.FindAsync(id);
            if (pe == null)
                return NotFound(new { message = "PokemonEquipa not found" });
            var dto = new PokemonEquipaDto
            {
                Id = pe.Id,
                EquipaFk = pe.EquipaFk,
                PokemonFk = pe.PokemonFk,
                Nivel = pe.Nivel,
                Alcunha = pe.Alcunha,
                PosicaoNaEquipa = pe.PosicaoNaEquipa,
                Ataques = new List<int>(), // Not mapped in entity
                HabilidadeFk = pe.HabilidadeFk
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new PokemonEquipa.
        /// </summary>
        /// <param name="dto">PokemonEquipaDto to create.</param>
        /// <returns>The created PokemonEquipaDto.</returns>
        /// <response code="201">Returns the newly created PokemonEquipa</response>
        /// <response code="400">If any foreign key does not exist or model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<PokemonEquipaDto>> Create([FromBody] PokemonEquipaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var equipaExists = await _context.Equipas.AnyAsync(e => e.Id == dto.EquipaFk);
            if (!equipaExists)
                return BadRequest(new { message = "EquipaFk does not exist." });
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            if (dto.HabilidadeFk.HasValue)
            {
                var habilidadeExists = await _context.Habilidades.AnyAsync(h => h.Id == dto.HabilidadeFk);
                if (!habilidadeExists)
                    return BadRequest(new { message = "HabilidadeFk does not exist." });
            }
            var pe = new PokemonEquipa
            {
                EquipaFk = dto.EquipaFk,
                PokemonFk = dto.PokemonFk,
                Nivel = dto.Nivel,
                Alcunha = dto.Alcunha,
                PosicaoNaEquipa = dto.PosicaoNaEquipa,
                HabilidadeFk = dto.HabilidadeFk
            };
            _context.PokemonEquipas.Add(pe);
            await _context.SaveChangesAsync();
            dto.Id = pe.Id;
            return CreatedAtAction(nameof(Get), new { id = pe.Id }, dto);
        }

        /// <summary>
        /// Updates an existing PokemonEquipa.
        /// </summary>
        /// <param name="id">PokemonEquipa ID.</param>
        /// <param name="dto">PokemonEquipaDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PokemonEquipaDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pe = await _context.PokemonEquipas.FindAsync(id);
            if (pe == null)
                return NotFound(new { message = "PokemonEquipa not found" });
            var equipaExists = await _context.Equipas.AnyAsync(e => e.Id == dto.EquipaFk);
            if (!equipaExists)
                return BadRequest(new { message = "EquipaFk does not exist." });
            var pokemonExists = await _context.Pokemons.AnyAsync(p => p.Id == dto.PokemonFk);
            if (!pokemonExists)
                return BadRequest(new { message = "PokemonFk does not exist." });
            if (dto.HabilidadeFk.HasValue)
            {
                var habilidadeExists = await _context.Habilidades.AnyAsync(h => h.Id == dto.HabilidadeFk);
                if (!habilidadeExists)
                    return BadRequest(new { message = "HabilidadeFk does not exist." });
            }
            pe.EquipaFk = dto.EquipaFk;
            pe.PokemonFk = dto.PokemonFk;
            pe.Nivel = dto.Nivel;
            pe.Alcunha = dto.Alcunha;
            pe.PosicaoNaEquipa = dto.PosicaoNaEquipa;
            pe.HabilidadeFk = dto.HabilidadeFk;
            _context.Entry(pe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a PokemonEquipa by its ID.
        /// </summary>
        /// <param name="id">PokemonEquipa ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pe = await _context.PokemonEquipas.FindAsync(id);
            if (pe == null)
                return NotFound(new { message = "PokemonEquipa not found" });
            _context.PokemonEquipas.Remove(pe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 