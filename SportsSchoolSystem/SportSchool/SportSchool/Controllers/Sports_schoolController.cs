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
    public class Sports_schoolController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Sports_schoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sports_school
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sports_school.ToListAsync());
        }

        // GET: Sports_school/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sports_school = await _context.Sports_school
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sports_school == null)
            {
                return NotFound();
            }

            return View(sports_school);
        }

        // GET: Sports_school/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sports_school/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,PhoneNumber,Email,Message_id")] Sports_school sports_school)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sports_school);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sports_school);
        }

        // GET: Sports_school/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sports_school = await _context.Sports_school.FindAsync(id);
            if (sports_school == null)
            {
                return NotFound();
            }
            return View(sports_school);
        }

        // POST: Sports_school/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,PhoneNumber,Email,Message_id")] Sports_school sports_school)
        {
            if (id != sports_school.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sports_school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sports_schoolExists(sports_school.Id))
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
            return View(sports_school);
        }

        // GET: Sports_school/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sports_school = await _context.Sports_school
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sports_school == null)
            {
                return NotFound();
            }

            return View(sports_school);
        }

        // POST: Sports_school/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sports_school = await _context.Sports_school.FindAsync(id);
            if (sports_school != null)
            {
                _context.Sports_school.Remove(sports_school);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sports_schoolExists(int id)
        {
            return _context.Sports_school.Any(e => e.Id == id);
        }
    }
}
