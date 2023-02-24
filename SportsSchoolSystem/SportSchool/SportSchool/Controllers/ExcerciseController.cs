using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace SportSchool.Controllers
{
    public class ExcerciseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excercise
        public async Task<IActionResult> Index()
        {
            return View(await _context.Excercise.ToListAsync());
        }

        // GET: Excercise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // GET: Excercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excercise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Level")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excercise);
        }

        // GET: Excercise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }
            return View(excercise);
        }

        // POST: Excercise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Duration,Level")] Excercise excercise)
        {
            if (id != excercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcerciseExists(excercise.Id))
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
            return View(excercise);
        }

        // GET: Excercise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _context.Excercise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // POST: Excercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excercise = await _context.Excercise.FindAsync(id);
            if (excercise != null)
            {
                _context.Excercise.Remove(excercise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcerciseExists(int id)
        {
            return _context.Excercise.Any(e => e.Id == id);
        }
    }
}
