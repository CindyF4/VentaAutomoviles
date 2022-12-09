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
    public class CompradoresController : Controller
    {
        private readonly VentaAutomovilesContext _context;

        public CompradoresController(VentaAutomovilesContext context)
        {
            _context = context;
        }

        // GET: Compradores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compradores.ToListAsync());
        }

        // GET: Compradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compradores = await _context.Compradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compradores == null)
            {
                return NotFound();
            }

            return View(compradores);
        }

        // GET: Compradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,ReleaseDate,Apellidos,DUI,Telefono,Direccion")] Compradores compradores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compradores);
        }

        // GET: Compradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compradores = await _context.Compradores.FindAsync(id);
            if (compradores == null)
            {
                return NotFound();
            }
            return View(compradores);
        }

        // POST: Compradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,ReleaseDate,Apellidos,DUI,Telefono,Direccion")] Compradores compradores)
        {
            if (id != compradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompradoresExists(compradores.Id))
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
            return View(compradores);
        }

        // GET: Compradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compradores = await _context.Compradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compradores == null)
            {
                return NotFound();
            }

            return View(compradores);
        }

        // POST: Compradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compradores = await _context.Compradores.FindAsync(id);
            _context.Compradores.Remove(compradores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompradoresExists(int id)
        {
            return _context.Compradores.Any(e => e.Id == id);
        }
    }
}
