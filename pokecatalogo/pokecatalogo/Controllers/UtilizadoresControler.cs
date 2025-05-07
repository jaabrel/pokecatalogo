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
    public class UtilizadoresControler : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilizadoresControler(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UtilizadoresControler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: UtilizadoresControler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // GET: UtilizadoresControler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UtilizadoresControler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IdentityUserName")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilizadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilizadores);
        }

        // GET: UtilizadoresControler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32("utilizadorId", utilizadores.Id);
            
            return View(utilizadores);
        }

        // POST: UtilizadoresControler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IdentityUserName")] Utilizadores utilizadores)
        {
            if (id != utilizadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var utilizadorDaSessao = HttpContext.Session.GetInt32("utilizadorId");
                    
                    _context.Update(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizadores.Id))
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
            return View(utilizadores);
        }

        // GET: UtilizadoresControler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // POST: UtilizadoresControler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores != null)
            {
                _context.Utilizadores.Remove(utilizadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.Id == id);
        }
    }
}
