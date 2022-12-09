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
    public class VentasPorMesController : Controller
    {
        private readonly VentaAutomovilesContext _context;

        public VentasPorMesController(VentaAutomovilesContext context)
        {
            _context = context;
        }

        // GET: VentasPorMes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasPorMes.ToListAsync());
        }

        // GET: VentasPorMes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorMes = await _context.VentasPorMes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventasPorMes == null)
            {
                return NotFound();
            }

            return View(ventasPorMes);
        }

        // GET: VentasPorMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasPorMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,ReleaseDate,Año,Precio,Total")] VentasPorMes ventasPorMes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasPorMes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasPorMes);
        }

        // GET: VentasPorMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorMes = await _context.VentasPorMes.FindAsync(id);
            if (ventasPorMes == null)
            {
                return NotFound();
            }
            return View(ventasPorMes);
        }

        // POST: VentasPorMes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,ReleaseDate,Año,Precio,Total")] VentasPorMes ventasPorMes)
        {
            if (id != ventasPorMes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasPorMes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasPorMesExists(ventasPorMes.Id))
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
            return View(ventasPorMes);
        }

        // GET: VentasPorMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasPorMes = await _context.VentasPorMes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventasPorMes == null)
            {
                return NotFound();
            }

            return View(ventasPorMes);
        }

        // POST: VentasPorMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasPorMes = await _context.VentasPorMes.FindAsync(id);
            _context.VentasPorMes.Remove(ventasPorMes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasPorMesExists(int id)
        {
            return _context.VentasPorMes.Any(e => e.Id == id);
        }
    }
}
