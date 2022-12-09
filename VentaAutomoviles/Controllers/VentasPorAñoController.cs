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
    public class VentasPorAñoController : Controller
    {
        private readonly VentaAutomovilesContext _context;

        public VentasPorAñoController(VentaAutomovilesContext context)
        {
            _context = context;
        }

        // GET: VentasPorAño
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasPorAño.ToListAsync());
        }

        // GET: VentasPorAño/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorAño = await _context.VentasPorAño
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventasPorAño == null)
            {
                return NotFound();
            }

            return View(ventasPorAño);
        }

        // GET: VentasPorAño/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasPorAño/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,Año,Precio,Total")] VentasPorAño ventasPorAño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasPorAño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasPorAño);
        }

        // GET: VentasPorAño/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorAño = await _context.VentasPorAño.FindAsync(id);
            if (ventasPorAño == null)
            {
                return NotFound();
            }
            return View(ventasPorAño);
        }

        // POST: VentasPorAño/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,Año,Precio,Total")] VentasPorAño ventasPorAño)
        {
            if (id != ventasPorAño.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasPorAño);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasPorAñoExists(ventasPorAño.Id))
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
            return View(ventasPorAño);
        }

        // GET: VentasPorAño/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorAño = await _context.VentasPorAño
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventasPorAño == null)
            {
                return NotFound();
            }

            return View(ventasPorAño);
        }

        // POST: VentasPorAño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasPorAño = await _context.VentasPorAño.FindAsync(id);
            _context.VentasPorAño.Remove(ventasPorAño);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasPorAñoExists(int id)
        {
            return _context.VentasPorAño.Any(e => e.Id == id);
        }
    }
}
