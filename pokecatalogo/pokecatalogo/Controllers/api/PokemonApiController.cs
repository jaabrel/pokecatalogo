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
    /// API endpoints for managing Pokémon.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PokemonApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PokemonApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Pokémon.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDto>>> GetAll()
        {
            var pokemons = await _context.Pokemons.Include(p => p.Tipos).ToListAsync();
            var result = pokemons.Select(p => new PokemonDto
            {
                Id = p.Id,
                Nome = p.Nome,
                DescricaoPokedex = p.DescricaoPokedex,
                Altura = p.Altura,
                Peso = p.Peso,
                Especie = p.Especie,
                PokeApiId = p.PokeApiId,
                Tipos = p.Tipos.Select(t => t.Id).ToList()
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Pokémon by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonDto>> Get(int id)
        {
            var pokemon = await _context.Pokemons.Include(p => p.Tipos).FirstOrDefaultAsync(p => p.Id == id);
            if (pokemon == null)
                return NotFound(new { message = "Pokemon not found" });
            var dto = new PokemonDto
            {
                Id = pokemon.Id,
                Nome = pokemon.Nome,
                DescricaoPokedex = pokemon.DescricaoPokedex,
                Altura = pokemon.Altura,
                Peso = pokemon.Peso,
                Especie = pokemon.Especie,
                PokeApiId = pokemon.PokeApiId,
                Tipos = pokemon.Tipos.Select(t => t.Id).ToList()
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Pokémon.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PokemonDto>> Create([FromBody] PokemonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tipos = await _context.Tipos.Where(t => dto.Tipos.Contains(t.Id)).ToListAsync();
            if (tipos.Count != dto.Tipos.Count)
                return BadRequest(new { message = "One or more Tipo IDs are invalid." });

            var pokemon = new Pokemon
            {
                Nome = dto.Nome,
                DescricaoPokedex = dto.DescricaoPokedex,
                Altura = dto.Altura,
                Peso = dto.Peso,
                Especie = dto.Especie,
                PokeApiId = dto.PokeApiId,
                Tipos = tipos
            };
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
            dto.Id = pokemon.Id;
            return CreatedAtAction(nameof(Get), new { id = pokemon.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Pokémon.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PokemonDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemon = await _context.Pokemons.Include(p => p.Tipos).FirstOrDefaultAsync(p => p.Id == id);
            if (pokemon == null)
                return NotFound(new { message = "Pokemon not found" });

            var tipos = await _context.Tipos.Where(t => dto.Tipos.Contains(t.Id)).ToListAsync();
            if (tipos.Count != dto.Tipos.Count)
                return BadRequest(new { message = "One or more Tipo IDs are invalid." });

            pokemon.Nome = dto.Nome;
            pokemon.DescricaoPokedex = dto.DescricaoPokedex;
            pokemon.Altura = dto.Altura;
            pokemon.Peso = dto.Peso;
            pokemon.Especie = dto.Especie;
            pokemon.PokeApiId = dto.PokeApiId;
            pokemon.Tipos = tipos;

            _context.Entry(pokemon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Pokémon by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
                return NotFound(new { message = "Pokemon not found" });
            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 