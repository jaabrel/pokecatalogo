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
    /// API endpoints for managing Equipas (teams).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EquipaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EquipaApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Equipas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipaDto>>> GetAll()
        {
            var equipas = await _context.Equipas.Include(e => e.Pokemons).ToListAsync();
            var result = equipas.Select(e => new EquipaDto
            {
                Id = e.Id,
                NomeEquipa = e.NomeEquipa,
                Descricao = e.Descricao,
                DataCriacao = e.DataCriacao,
                DonoFk = e.DonoFk,
                Pokemons = e.Pokemons?.Select(pe => pe.Id).ToList() ?? new List<int>()
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets an Equipa by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipaDto>> Get(int id)
        {
            var equipa = await _context.Equipas.Include(e => e.Pokemons).FirstOrDefaultAsync(e => e.Id == id);
            if (equipa == null)
                return NotFound(new { message = "Equipa not found" });
            var dto = new EquipaDto
            {
                Id = equipa.Id,
                NomeEquipa = equipa.NomeEquipa,
                Descricao = equipa.Descricao,
                DataCriacao = equipa.DataCriacao,
                DonoFk = equipa.DonoFk,
                Pokemons = equipa.Pokemons?.Select(pe => pe.Id).ToList() ?? new List<int>()
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Equipa.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EquipaDto>> Create([FromBody] EquipaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var donoExists = await _context.Utilizadores.AnyAsync(u => u.Id == dto.DonoFk);
            if (!donoExists)
                return BadRequest(new { message = "DonoFk does not exist." });
            var equipa = new Equipa
            {
                NomeEquipa = dto.NomeEquipa,
                Descricao = dto.Descricao,
                DataCriacao = dto.DataCriacao,
                DonoFk = dto.DonoFk
            };
            _context.Equipas.Add(equipa);
            await _context.SaveChangesAsync();
            dto.Id = equipa.Id;
            return CreatedAtAction(nameof(Get), new { id = equipa.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Equipa.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquipaDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var equipa = await _context.Equipas.FindAsync(id);
            if (equipa == null)
                return NotFound(new { message = "Equipa not found" });
            var donoExists = await _context.Utilizadores.AnyAsync(u => u.Id == dto.DonoFk);
            if (!donoExists)
                return BadRequest(new { message = "DonoFk does not exist." });
            equipa.NomeEquipa = dto.NomeEquipa;
            equipa.Descricao = dto.Descricao;
            equipa.DataCriacao = dto.DataCriacao;
            equipa.DonoFk = dto.DonoFk;
            _context.Entry(equipa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes an Equipa by its ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipa = await _context.Equipas.FindAsync(id);
            if (equipa == null)
                return NotFound(new { message = "Equipa not found" });
            _context.Equipas.Remove(equipa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 