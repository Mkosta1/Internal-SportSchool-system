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
    public class User_typeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_typeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_type
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_type.ToListAsync());
        }

        // GET: User_type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_type = await _context.User_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_type == null)
            {
                return NotFound();
            }

            return View(user_type);
        }

        // GET: User_type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Since,Until")] User_type user_type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_type);
        }

        // GET: User_type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_type = await _context.User_type.FindAsync(id);
            if (user_type == null)
            {
                return NotFound();
            }
            return View(user_type);
        }

        // POST: User_type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Since,Until")] User_type user_type)
        {
            if (id != user_type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_typeExists(user_type.Id))
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
            return View(user_type);
        }

        // GET: User_type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_type = await _context.User_type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_type == null)
            {
                return NotFound();
            }

            return View(user_type);
        }

        // POST: User_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_type = await _context.User_type.FindAsync(id);
            if (user_type != null)
            {
                _context.User_type.Remove(user_type);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_typeExists(int id)
        {
            return _context.User_type.Any(e => e.Id == id);
        }
    }
}
