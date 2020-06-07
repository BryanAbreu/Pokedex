using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Schema;
using pokedex.Models;
using pokedex.ViewModels;

namespace pokedex.Controllers
{
    public class TiposController : Controller
    {
        private readonly PokedexContext _context;

        public TiposController(PokedexContext context)
        {
            _context = context;
        }

        // GET: Tipos 
        public async Task<IActionResult> Index( TipoViewModel tipo )
        {
            var listEntity = await _context.Tipo.ToListAsync();
            List<TipoViewModel> vms = new List<TipoViewModel>();
            listEntity.ForEach(item =>
            {
                vms.Add(new TipoViewModel
                {
                    Tipos = item.Tipos,
                    

                }) ;
            });

            return View(vms);




        }

        // GET: Tipos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.Tipos == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipos/Create
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear( TipoViewModel tipo)
        {
            if (ModelState.IsValid)
            {
                var tip = new Tipo
                {
                    Tipos = tipo.Tipos
                    

                };
                _context.Add(tip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        // GET: Tipos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tipos")] Tipo tipo)
        {
            if (id != tipo.Tipos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.Tipos))
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
            return View(tipo);
        }

        // GET: Tipos/Delete/5
        public async Task<IActionResult> Eliminar(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipo
                .FirstOrDefaultAsync(m => m.Tipos == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var tipos = await _context.Tipo.FindAsync(id);
                _context.Tipo.Remove(tipos);
                await _context.SaveChangesAsync();
            }

            catch
            {
                var pokemon = _context.Pokemon.Where(x => x.Tipo == id ||  x.Tipo2 == id);
                _context.Pokemon.RemoveRange(pokemon);

                var Tipo = await _context.Tipo.FindAsync(id);
                _context.Tipo.Remove(Tipo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool TipoExists(string id)
        {
            return _context.Tipo.Any(e => e.Tipos == id);
        }
    }
    }

    

