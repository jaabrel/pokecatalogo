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
    public class AtaqueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AtaqueController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ataque
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ataques.Include(a => a.Tipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ataque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataques
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ataque == null)
            {
                return NotFound();
            }

            return View(ataque);
        }

        // GET: Ataque/Create
        [Authorize(Roles = "Administrador")] // Only administrators can create Ataque
        public IActionResult Create()
        {
            ViewData["TipoFk"] = new SelectList(_context.Tipos, "Id", "Cor");
            return View();
        }

        // POST: Ataque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can create Ataque
        public async Task<IActionResult> Create([Bind("Id,Nome,Categoria,Descricao,Dano,Precisao,PP,Prioridade,TipoFk")] Ataque ataque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ataque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoFk"] = new SelectList(_context.Tipos, "Id", "Cor", ataque.TipoFk);
            return View(ataque);
        }

        // GET: Ataque/Edit/5
        [Authorize(Roles = "Administrador")] // Only administrators can edit Ataque
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataques.FindAsync(id);
            if (ataque == null)
            {
                return NotFound();
            }
            ViewData["TipoFk"] = new SelectList(_context.Tipos, "Id", "Cor", ataque.TipoFk);
            return View(ataque);
        }

        // POST: Ataque/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can edit Ataque
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Categoria,Descricao,Dano,Precisao,PP,Prioridade,TipoFk")] Ataque ataque)
        {
            if (id != ataque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ataque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtaqueExists(ataque.Id))
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
            ViewData["TipoFk"] = new SelectList(_context.Tipos, "Id", "Cor", ataque.TipoFk);
            return View(ataque);
        }

        // GET: Ataque/Delete/5
        [Authorize(Roles = "Administrador")] // Only administrators can delete Ataque
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ataque = await _context.Ataques
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ataque == null)
            {
                return NotFound();
            }

            return View(ataque);
        }

        // POST: Ataque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can delete Ataque
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ataque = await _context.Ataques.FindAsync(id);
            if (ataque != null)
            {
                _context.Ataques.Remove(ataque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtaqueExists(int id)
        {
            return _context.Ataques.Any(e => e.Id == id);
        }
    }
}
