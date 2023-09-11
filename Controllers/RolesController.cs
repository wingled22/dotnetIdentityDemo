using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnetIdentityDemo.Entities;

namespace dotnetIdentityDemo.Controllers
{
    public class RolesController : Controller
    {
        private readonly SampleDbContext _context;

        public RolesController(SampleDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
              return _context.Aspnetroles != null ? 
                          View(await _context.Aspnetroles.ToListAsync()) :
                          Problem("Entity set 'SampleDbContext.Aspnetroles'  is null.");
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aspnetroles == null)
            {
                return NotFound();
            }

            var aspnetrole = await _context.Aspnetroles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspnetrole == null)
            {
                return NotFound();
            }

            return View(aspnetrole);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] Aspnetrole aspnetrole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspnetrole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspnetrole);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aspnetroles == null)
            {
                return NotFound();
            }

            var aspnetrole = await _context.Aspnetroles.FindAsync(id);
            if (aspnetrole == null)
            {
                return NotFound();
            }
            return View(aspnetrole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] Aspnetrole aspnetrole)
        {
            if (id != aspnetrole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspnetrole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspnetroleExists(aspnetrole.Id))
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
            return View(aspnetrole);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aspnetroles == null)
            {
                return NotFound();
            }

            var aspnetrole = await _context.Aspnetroles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspnetrole == null)
            {
                return NotFound();
            }

            return View(aspnetrole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aspnetroles == null)
            {
                return Problem("Entity set 'SampleDbContext.Aspnetroles'  is null.");
            }
            var aspnetrole = await _context.Aspnetroles.FindAsync(id);
            if (aspnetrole != null)
            {
                _context.Aspnetroles.Remove(aspnetrole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspnetroleExists(int id)
        {
          return (_context.Aspnetroles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
