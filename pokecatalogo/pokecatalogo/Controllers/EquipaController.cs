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
            var applicationDbContext = _context.Equipa.Include(e => e.Dono);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipa
                .Include(e => e.Dono)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipa == null)
            {
                return NotFound();
            }

            return View(equipa);
        }

        // GET: Equipa/Create
        public IActionResult Create()
        {
            ViewData["DonoFk"] = new SelectList(_context.Utilizadores, "Id", "Email");
            return View();
        }

        // POST: Equipa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEquipa,CreatedDate,DonoFk")] Equipa equipa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonoFk"] = new SelectList(_context.Utilizadores, "Id", "Email", equipa.DonoFk);
            return View(equipa);
        }

        // GET: Equipa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipa.FindAsync(id);
            if (equipa == null)
            {
                return NotFound();
            }
            ViewData["DonoFk"] = new SelectList(_context.Utilizadores, "Id", "Email", equipa.DonoFk);
            return View(equipa);
        }

        // POST: Equipa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEquipa,CreatedDate,DonoFk")] Equipa equipa)
        {
            if (id != equipa.Id)
            {
                return NotFound();
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
            ViewData["DonoFk"] = new SelectList(_context.Utilizadores, "Id", "Email", equipa.DonoFk);
            return View(equipa);
        }

        // GET: Equipa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipa = await _context.Equipa
                .Include(e => e.Dono)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipa == null)
            {
                return NotFound();
            }

            return View(equipa);
        }

        // POST: Equipa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipa = await _context.Equipa.FindAsync(id);
            if (equipa != null)
            {
                _context.Equipa.Remove(equipa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipaExists(int id)
        {
            return _context.Equipa.Any(e => e.Id == id);
        }
    }
}
