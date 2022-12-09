using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VentaAutomoviles.Data;
using VentaAutomoviles.Models;

namespace VentaAutomoviles.Controllers
{
    public class AutosIngresadosController : Controller
    {
        private readonly VentaAutomovilesContext _context;

        public AutosIngresadosController(VentaAutomovilesContext context)
        {
            _context = context;
        }

        // GET: AutosIngresados
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutosIngresados.ToListAsync());
        }

        // GET: AutosIngresados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autosIngresados = await _context.AutosIngresados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autosIngresados == null)
            {
                return NotFound();
            }

            return View(autosIngresados);
        }

        // GET: AutosIngresados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutosIngresados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,ReleaseDate,Tipo,Placas,Color,Año,Precio")] AutosIngresados autosIngresados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autosIngresados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autosIngresados);
        }

        // GET: AutosIngresados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autosIngresados = await _context.AutosIngresados.FindAsync(id);
            if (autosIngresados == null)
            {
                return NotFound();
            }
            return View(autosIngresados);
        }

        // POST: AutosIngresados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,ReleaseDate,Tipo,Placas,Color,Año,Precio")] AutosIngresados autosIngresados)
        {
            if (id != autosIngresados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autosIngresados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutosIngresadosExists(autosIngresados.Id))
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
            return View(autosIngresados);
        }

        // GET: AutosIngresados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autosIngresados = await _context.AutosIngresados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autosIngresados == null)
            {
                return NotFound();
            }

            return View(autosIngresados);
        }

        // POST: AutosIngresados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autosIngresados = await _context.AutosIngresados.FindAsync(id);
            _context.AutosIngresados.Remove(autosIngresados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutosIngresadosExists(int id)
        {
            return _context.AutosIngresados.Any(e => e.Id == id);
        }
    }
}
