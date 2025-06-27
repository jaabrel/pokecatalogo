using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pokecatalogo.Data;
using pokecatalogo.Models;

namespace pokecatalogo.Controllers
{
    public class EquipaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ataques.Include(a => a.Tipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipa/Details/5
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

        // GET: Equipa/Create
        public IActionResult Create()
        {
            ViewData["TipoFk"] = new SelectList(_context.Tipos, "Id", "Cor");
            return View();
        }

        // POST: Equipa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Equipa/Edit/5
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

        // POST: Equipa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Equipa/Delete/5
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

        // POST: Equipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
