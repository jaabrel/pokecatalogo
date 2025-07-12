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
    /// API endpoints for managing Utilizadores (users).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UtilizadoresApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UtilizadoresApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Utilizadores.
        /// </summary>
        /// <returns>List of UtilizadoresDto.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilizadoresDto>>> GetAll()
        {
            var users = await _context.Utilizadores.ToListAsync();
            var result = users.Select(u => new UtilizadoresDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                IdentityUserName = u.IdentityUserName
            });
            return Ok(result);
        }

        /// <summary>
        /// Gets a Utilizador by its ID.
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <returns>UtilizadoresDto if found; 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilizadoresDto>> Get(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Utilizador not found" });
            var dto = new UtilizadoresDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                IdentityUserName = user.IdentityUserName
            };
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new Utilizador.
        /// </summary>
        /// <param name="dto">UtilizadoresDto to create.</param>
        /// <returns>The created UtilizadoresDto.</returns>
        /// <response code="201">Returns the newly created Utilizador</response>
        /// <response code="400">If the model is invalid</response>
        [HttpPost]
        public async Task<ActionResult<UtilizadoresDto>> Create([FromBody] UtilizadoresDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new Utilizadores
            {
                Nome = dto.Nome,
                Email = dto.Email,
                IdentityUserName = dto.IdentityUserName
            };
            _context.Utilizadores.Add(user);
            await _context.SaveChangesAsync();
            dto.Id = user.Id;
            return CreatedAtAction(nameof(Get), new { id = user.Id }, dto);
        }

        /// <summary>
        /// Updates an existing Utilizador.
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <param name="dto">UtilizadoresDto with updated data.</param>
        /// <returns>No content if successful; 404 or 400 otherwise.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UtilizadoresDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch." });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _context.Utilizadores.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Utilizador not found" });
            user.Nome = dto.Nome;
            user.Email = dto.Email;
            user.IdentityUserName = dto.IdentityUserName;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes a Utilizador by its ID.
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <returns>No content if successful; 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Utilizador not found" });
            _context.Utilizadores.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 