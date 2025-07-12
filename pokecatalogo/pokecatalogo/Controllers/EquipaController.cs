using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using pokecatalogo.Data;
using pokecatalogo.Models;

namespace pokecatalogo.Controllers
{
    [Authorize] // Require authentication for all actions
    public class EquipaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EquipaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Equipa
        public async Task<IActionResult> Index()
        {
            // Get current user's teams
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var currentUtilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (currentUtilizador == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            // Show only teams owned by the current user
            var userTeams = await _context.Equipas
                .Include(e => e.Dono)
                .Where(e => e.DonoFk == currentUtilizador.Id)
                .ToListAsync();

            return View(userTeams);
        }

        // GET: Equipa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipas
                .Include(e => e.Dono)
                .Include(e => e.Pokemons)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipa == null)
            {
                return NotFound();
            }

            // Check if user is authorized to view this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
            {
                return Forbid();
            }

            return View(equipa);
        }

        // GET: Equipa/Create
        public async Task<IActionResult> Create()
        {
            // All available Pokémons
            var pokemons = await _context.Pokemons.ToListAsync();
            ViewBag.Pokemons = new SelectList(pokemons, "Id", "Nome");
            
            // All available attacks
            var ataques = await _context.Ataques.ToListAsync();
            ViewBag.Ataques = new SelectList(ataques, "Id", "Nome");
            
            // All available abilities
            var habilidades = await _context.Habilidades.ToListAsync();
            ViewBag.Habilidades = new SelectList(habilidades, "Id", "Nome");
            
            return View();
        }

        // POST: Equipa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEquipa,Descricao,DataCriacao,DonoFk")] Equipa equipa, 
            int PokemonFk, int Nivel, string? Alcunha, int PosicaoNaEquipa, int? HabilidadeFk, List<int> AtaquesFk)
        {
            if (ModelState.IsValid)
            {
                // Set the current user as the owner
                var currentUser = await _userManager.GetUserAsync(User);
                var currentUtilizador = await _context.Utilizadores
                    .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

                if (currentUtilizador != null)
                {
                    equipa.DonoFk = currentUtilizador.Id;
                    equipa.DataCriacao = DateTime.Now;
                    
                    _context.Add(equipa);
                    await _context.SaveChangesAsync();
                    
                    // Create the first PokemonEquipa
                    var pokemonEquipa = new PokemonEquipa
                    {
                        EquipaFk = equipa.Id,
                        PokemonFk = PokemonFk,
                        Nivel = Nivel,
                        Alcunha = Alcunha,
                        PosicaoNaEquipa = PosicaoNaEquipa,
                        HabilidadeFk = HabilidadeFk,
                        Ataques = new List<Ataque>()
                    };
                    
                    // Attach selected Ataques
                    if (AtaquesFk != null && AtaquesFk.Any())
                    {
                        var listaataques = await _context.Ataques.Where(a => AtaquesFk.Contains(a.Id)).ToListAsync();
                        pokemonEquipa.Ataques = listaataques;
                    }
                    
                    _context.PokemonEquipas.Add(pokemonEquipa);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            
            // Reload ViewBag data for validation errors
            var pokemons = await _context.Pokemons.ToListAsync();
            ViewBag.Pokemons = new SelectList(pokemons, "Id", "Nome", PokemonFk);
            var ataques = await _context.Ataques.ToListAsync();
            ViewBag.Ataques = new SelectList(ataques, "Id", "Nome");
            var habilidades = await _context.Habilidades.ToListAsync();
            ViewBag.Habilidades = new SelectList(habilidades, "Id", "Nome", HabilidadeFk);
            
            return View(equipa);
        }

        // GET: Equipa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipas.FindAsync(id);
            if (equipa == null)
            {
                return NotFound();
            }

            // Check if user is authorized to edit this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
            {
                return Forbid();
            }

            return View(equipa);
        }

        // POST: Equipa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEquipa,Descricao,DataCriacao,DonoFk")] Equipa equipa)
        {
            if (id != equipa.Id)
            {
                return NotFound();
            }

            // Check if user is authorized to edit this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipaExists(equipa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipa);
        }

        // GET: Equipa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipas
                .Include(e => e.Dono)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipa == null)
            {
                return NotFound();
            }

            // Check if user is authorized to delete this team
            if (!await IsUserAuthorizedToManageTeamAsync(equipa))
            {
                return Forbid();
            }

            return View(equipa);
        }

        // POST: Equipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipa = await _context.Equipas.FindAsync(id);
            if (equipa != null)
            {
                // Check if user is authorized to delete this team
                if (!await IsUserAuthorizedToManageTeamAsync(equipa))
                {
                    return Forbid();
                }

                _context.Equipas.Remove(equipa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipaExists(int id)
        {
            return _context.Equipas.Any(e => e.Id == id);
        }

        // Helper method to check if current user can manage a specific team
        private async Task<bool> IsUserAuthorizedToManageTeamAsync(Equipa team)
        {
            // Get current logged-in user
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return false;
            }

            // Find the Utilizadores record for the current logged-in user
            var currentUtilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(u => u.IdentityUserName == currentUser.UserName);

            if (currentUtilizador == null)
            {
                return false;
            }

            // User can only manage teams they own
            return team.DonoFk == currentUtilizador.Id;
        }
    }
}
