using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using pokecatalogo.Data;
using pokecatalogo.Models;

namespace pokecatalogo.Controllers
{// Require authentication for all actions
    public class PokemonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PokemonController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pokemon
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pokemons.Include(p => p.Tipos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pokemon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .Include(p => p.Tipos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemon/Create
        [Authorize(Roles = "Administrador")] // Only administrators can create Pokemon
        public IActionResult Create()
        {
            ViewData["Tipo1Fk"] = new SelectList(_context.Tipos, "Id", "Nome");
            return View();
        }

        // POST: Pokemon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can create Pokemon
        public async Task<IActionResult> Create([Bind("Id,Nome,DescricaoPokedex,Altura,Peso,Especie,PokeApiId")] Pokemon pokemon, List<int> Tipos)
        {
            if (ModelState.IsValid)
            {
                if (Tipos.Count == 1)
                {
                    _context.Tipos.Where(t => t.Id == Tipos[0])
                        .ToList()
                        .ForEach(t => pokemon.Tipos.Add(t));
                } else if (Tipos.Count == 2)
                {
                    _context.Tipos.Where(t => t.Id == Tipos[0] || t.Id == Tipos[1])
                        .ToList()
                        .ForEach(t => pokemon.Tipos.Add(t));
                }
                
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tipo1Fk"] = new SelectList(_context.Tipos, "Id", "Nome", pokemon.Tipos);
            return View(pokemon);
        }

        // GET: Pokemon/Edit/5
        [Authorize(Roles = "Administrador")] // Only administrators can edit Pokemon
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon =  _context.Pokemons.Include(p => p.Tipos).First(p => p.Id==id);
            var tipo1 = pokemon.Tipos.First().Id;
            if (pokemon == null)
            {
                return NotFound();
            }
            ViewData["Tipo1Fk"] = new SelectList(_context.Tipos, "Id", "Nome", tipo1);
            return View(pokemon);
        }

        // POST: Pokemon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can edit Pokemon
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DescricaoPokedex,Altura,Peso,Especie,PokeApiId")] Pokemon pokemon)
        {
            if (id != pokemon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.Id))
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
            ViewData["Tipo1Fk"] = new SelectList(_context.Tipos, "Id", "Nome", pokemon.Tipos);
            return View(pokemon);
        }

        // GET: Pokemon/Delete/5
        [Authorize(Roles = "Administrador")] // Only administrators can delete Pokemon
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .Include(p => p.Tipos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")] // Only administrators can delete Pokemon
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.Id == id);
        }
        
        // GET: Pokemon/Search?term=query
        
    }
}
