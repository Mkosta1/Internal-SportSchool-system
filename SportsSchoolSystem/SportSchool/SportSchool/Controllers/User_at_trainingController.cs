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
    public class User_at_trainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_at_trainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_at_training
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_at_training.ToListAsync());
        }

        // GET: User_at_training/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_at_training = await _context.User_at_training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_at_training == null)
            {
                return NotFound();
            }

            return View(user_at_training);
        }

        // GET: User_at_training/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_at_training/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Since,Until,User_id,Training_id")] User_at_training user_at_training)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_at_training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_at_training);
        }

        // GET: User_at_training/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_at_training = await _context.User_at_training.FindAsync(id);
            if (user_at_training == null)
            {
                return NotFound();
            }
            return View(user_at_training);
        }

        // POST: User_at_training/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Since,Until,User_id,Training_id")] User_at_training user_at_training)
        {
            if (id != user_at_training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_at_training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_at_trainingExists(user_at_training.Id))
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
            return View(user_at_training);
        }

        // GET: User_at_training/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_at_training = await _context.User_at_training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user_at_training == null)
            {
                return NotFound();
            }

            return View(user_at_training);
        }

        // POST: User_at_training/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_at_training = await _context.User_at_training.FindAsync(id);
            if (user_at_training != null)
            {
                _context.User_at_training.Remove(user_at_training);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_at_trainingExists(int id)
        {
            return _context.User_at_training.Any(e => e.Id == id);
        }
    }
}
