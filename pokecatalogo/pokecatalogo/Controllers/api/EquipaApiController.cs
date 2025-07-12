using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pokecatalogo.Data;
using pokecatalogo.Models;
using pokecatalogo.Models.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<IdentityUser> _userManager;

        public EquipaApiController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets all Equipas for the current user.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipaDto>>> GetAll()
        {
            // Get current user's teams only
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Unauthorized();

            var currentUtilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (currentUtilizador == null)
                return Unauthorized();

            var equipas = await _context.Equipas
                .Include(e => e.Pokemons)
                .Where(e => e.DonoFk == currentUtilizador.Id)
                .ToListAsync();

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
        /// Gets an Equipa by its ID (only if owned by current user).
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipaDto>> Get(int id)
        {
            var equipa = await _context.Equipas.Include(e => e.Pokemons).FirstOrDefaultAsync(e => e.Id == id);
            if (equipa == null)
                return NotFound(new { message = "Equipa not found" });

            // Check if user owns this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
                return Forbid();

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
        /// Creates a new Equipa for the current user.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EquipaDto>> Create([FromBody] EquipaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get current user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Unauthorized();

            var currentUtilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (currentUtilizador == null)
                return Unauthorized();

            var equipa = new Equipa
            {
                NomeEquipa = dto.NomeEquipa,
                Descricao = dto.Descricao,
                DataCriacao = DateTime.Now,
                DonoFk = currentUtilizador.Id // Force ownership to current user
            };
            _context.Equipas.Add(equipa);
            await _context.SaveChangesAsync();
            dto.Id = equipa.Id;
            dto.DonoFk = currentUtilizador.Id;
            return CreatedAtAction(nameof(Get), new { id = equipa.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Equipa (only if owned by current user).
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

            // Check if user owns this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
                return Forbid();

            equipa.NomeEquipa = dto.NomeEquipa;
            equipa.Descricao = dto.Descricao;
            // Don't allow changing ownership or creation date
            _context.Entry(equipa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes an Equipa by its ID (only if owned by current user).
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipa = await _context.Equipas.FindAsync(id);
            if (equipa == null)
                return NotFound(new { message = "Equipa not found" });

            // Check if user owns this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
                return Forbid();

            _context.Equipas.Remove(equipa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Helper method to check if current user can manage a specific team
        private async Task<bool> IsUserAuthorizedToManageTeamAsync(Equipa team)
        {
            // Get current logged-in user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return false;

            // Find the Utilizadores record for the current logged-in user
            var currentUtilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (currentUtilizador == null)
                return false;

            // User can only manage teams they own
            return team.DonoFk == currentUtilizador.Id;
        }
    }
} 