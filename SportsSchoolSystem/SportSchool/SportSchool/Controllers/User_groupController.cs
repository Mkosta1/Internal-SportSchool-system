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
    public class User_groupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_groupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_group
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_group.ToListAsync());
        }

        // GET: User_group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_group = await _context.User_group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_group == null)
            {
                return NotFound();
            }

            return View(user_group);
        }

        // GET: User_group/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size")] User_group user_group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_group);
        }

        // GET: User_group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_group = await _context.User_group.FindAsync(id);
            if (user_group == null)
            {
                return NotFound();
            }
            return View(user_group);
        }

        // POST: User_group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size")] User_group user_group)
        {
            if (id != user_group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_groupExists(user_group.Id))
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
            return View(user_group);
        }

        // GET: User_group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_group = await _context.User_group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_group == null)
            {
                return NotFound();
            }

            return View(user_group);
        }

        // POST: User_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_group = await _context.User_group.FindAsync(id);
            if (user_group != null)
            {
                _context.User_group.Remove(user_group);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_groupExists(int id)
        {
            return _context.User_group.Any(e => e.Id == id);
        }
    }
}
