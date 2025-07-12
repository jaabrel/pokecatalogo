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
    /// API endpoints for managing Utilizadores (users).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UtilizadoresApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UtilizadoresApiController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets the current user's profile.
        /// </summary>
        /// <returns>Current user's UtilizadoresDto.</returns>
        [HttpGet("me")]
        public async Task<ActionResult<UtilizadoresDto>> GetCurrentUser()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Unauthorized();

            var user = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (user == null)
                return NotFound(new { message = "User profile not found" });

            var dto = new UtilizadoresDto
            {
                Id = user.Id,
                Nome = user.Nome,
                IdentityUserName = user.IdentityUserName
            };
            return Ok(dto);
        }

        /// <summary>
        /// Gets a Utilizador by its ID (only if it's the current user).
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <returns>UtilizadoresDto if found and authorized; 403 or 404 otherwise.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilizadoresDto>> Get(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Utilizador not found" });

            // Check if user is authorized to view this profile
            if (!await IsUserAuthorizedToManageProfileAsync(user))
                return Forbid();

            var dto = new UtilizadoresDto
            {
                Id = user.Id,
                Nome = user.Nome,
                IdentityUserName = user.IdentityUserName
            };
            return Ok(dto);
        }

        /// <summary>
        /// Updates the current user's profile.
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <param name="dto">UtilizadoresDto with updated data.</param>
        /// <returns>No content if successful; 403, 404 or 400 otherwise.</returns>
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

            // Check if user is authorized to edit this profile
            if (!await IsUserAuthorizedToManageProfileAsync(user))
                return Forbid();

            user.Nome = dto.Nome;
            // Don't allow changing IdentityUserName for security
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes the current user's profile.
        /// </summary>
        /// <param name="id">Utilizador ID.</param>
        /// <returns>No content if successful; 403 or 404 otherwise.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Utilizador not found" });

            // Check if user is authorized to delete this profile
            if (!await IsUserAuthorizedToManageProfileAsync(user))
                return Forbid();

            _context.Utilizadores.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Helper method to check if current user can manage a specific profile
        private async Task<bool> IsUserAuthorizedToManageProfileAsync(Utilizadores profile)
        {
            // Get current logged-in user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return false;

            // User can only manage their own profile
            return profile.IdentityUserName == currentUser.UserName;
        }
    }
} 