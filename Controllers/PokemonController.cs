using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pokedex.Models;
using pokedex.ViewModels;

namespace pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokedexContext _contex;
        public PokemonController(PokedexContext context)
        {
            _contex = context;

        }
        // GET: Pokemon
        public async Task<IActionResult> Index()
        {
            var listEntity = await _contex.Pokemon.ToListAsync();
            List<PokemonViewModel> vms = new List<PokemonViewModel>();
            listEntity.ForEach(item =>
                {
                    vms.Add(new PokemonViewModel
                    {
                        Nombre = item.Nombre,
                        Tipo = item.Tipo,
                        Tipo2 =item.Tipo2,
                        Ataques= item.Ataques,
                        Ataque2= item.Ataque2,
                        Ataque3= item.Ataque3,
                        Ataque4= item.Ataque4,
                        Region= item.Region
                        
                    }) ; 
                });

            return View(vms);
        }

        // GET: Pokemon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pokemon/Create
        public IActionResult Create()
        {
            var regiones = _contex.Regiones.ToList();
            ViewData["Regiones"] = new SelectList(regiones, "Region", "Region");

            var tipos = _contex.Tipo.ToList();
            ViewData["Tipos"] = new SelectList(tipos, "Tipos", "Tipos");
            

            return View();

        }

        // POST: Pokemon/Create
        [HttpPost]
        public async Task<IActionResult> Create(PokemonViewModel pokemon)
        {
            if (ModelState.IsValid)
            {
                var pokemo = new Pokemon
                {
                   Nombre= pokemon.Nombre,
                   Tipo= pokemon.Tipo,
                   Tipo2 = pokemon.Tipo2,
                   Ataques = pokemon.Ataques,
                   Ataque2= pokemon.Ataque2,
                   Ataque3=pokemon.Ataque3,
                   Ataque4=pokemon.Ataque4,
                   Region =pokemon.Region
                };
                _contex.Add(pokemo);
                await _contex.SaveChangesAsync();

            }
            return RedirectToAction("Index");



        }

        // GET: Pokemon/Edit/5
        public async Task< IActionResult> Edit(string nombre)
        {
            if (nombre == null)
            {
                return NotFound();
            }
            var pokemon = await _contex.Pokemon.FirstOrDefaultAsync(x => x.Nombre == nombre);
            if (pokemon == null)

            {
                return NotFound();
            }
            var regiones = _contex.Regiones.ToList();
            ViewData["Regiones"] = new SelectList(regiones, "Region", "Region");

            var Tipos = _contex.Tipo.ToList();
            ViewData["Tipos"] = new SelectList(Tipos, "Tipos", "Tipos");

            return View(pokemon);
        }

        // POST: Pokemon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(string nombre,Pokemon pokemon)
        {
            if (nombre != pokemon.Nombre )
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _contex.Update(pokemon);
                 await _contex.SaveChangesAsync();
            
            }
            return RedirectToAction("Index");
        }

        // GET: Pokemon/Delete/5
        public async Task<IActionResult> Delete(string nombre)
        {
            {
                if (nombre == null)
                {
                    return NotFound();
                }

                var pokemon = await _contex.Pokemon.FindAsync(nombre);
                if (pokemon == null)
                {
                    return NotFound();
                }

                return View(pokemon);
            }
        }

        // POST: Pokemon/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string? nombre)

        {
           var pokemon = await _contex.Pokemon.FindAsync(nombre);
            if (pokemon==null)
            {
                return NotFound();

            }


           
            _contex.Pokemon.Remove(pokemon);
                await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}