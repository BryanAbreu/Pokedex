using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pokedex.Models;
using pokedex.ViewModels;

namespace pokedex.Controllers
{
    public class RegionesController : Controller
    {
        private readonly PokedexContext _context;

        public RegionesController(PokedexContext context)
        {
            _context = context;
        }

        // GET: Regiones
        public async Task<IActionResult> Index()
        {
            var listEntity = await _context.Regiones.ToListAsync();
            List<RegionesViewModel> vms = new List<RegionesViewModel>();
            listEntity.ForEach(item =>
            {
                vms.Add(new RegionesViewModel
                {
                    Region = item.Region

                });
            });

            return View(vms);
        }
    




        // GET: Regiones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .FirstOrDefaultAsync(m => m.Region == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // GET: Regiones/Create
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Region")] Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return NotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Region")] Regiones regiones)
        {
            if (id != regiones.Region)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionesExists(regiones.Region))
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
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiones = await _context.Regiones
                .FirstOrDefaultAsync(m => m.Region == id);
            if (regiones == null)
            {
                return NotFound();
            }

            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var regiones = await _context.Regiones.FindAsync(id);
                _context.Regiones.Remove(regiones);
                await _context.SaveChangesAsync();
            }

            catch
            {
                var pokemon = _context.Pokemon.Where(x => x.Region == id);
                _context.Pokemon.RemoveRange(pokemon);

                var regiones = await _context.Regiones.FindAsync(id);
                _context.Regiones.Remove(regiones);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RegionesExists(string id)
        {
            return _context.Regiones.Any(e => e.Region == id);
        }
    }
}

