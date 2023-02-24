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
    public class Monthly_subscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Monthly_subscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monthly_subscription
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monthly_subscription.ToListAsync());
        }

        // GET: Monthly_subscription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_subscription = await _context.Monthly_subscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthly_subscription == null)
            {
                return NotFound();
            }

            return View(monthly_subscription);
        }

        // GET: Monthly_subscription/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monthly_subscription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Date,Sports_school_id")] Monthly_subscription monthly_subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthly_subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthly_subscription);
        }

        // GET: Monthly_subscription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_subscription = await _context.Monthly_subscription.FindAsync(id);
            if (monthly_subscription == null)
            {
                return NotFound();
            }
            return View(monthly_subscription);
        }

        // POST: Monthly_subscription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Date,Sports_school_id")] Monthly_subscription monthly_subscription)
        {
            if (id != monthly_subscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthly_subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Monthly_subscriptionExists(monthly_subscription.Id))
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
            return View(monthly_subscription);
        }

        // GET: Monthly_subscription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthly_subscription = await _context.Monthly_subscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthly_subscription == null)
            {
                return NotFound();
            }

            return View(monthly_subscription);
        }

        // POST: Monthly_subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthly_subscription = await _context.Monthly_subscription.FindAsync(id);
            if (monthly_subscription != null)
            {
                _context.Monthly_subscription.Remove(monthly_subscription);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Monthly_subscriptionExists(int id)
        {
            return _context.Monthly_subscription.Any(e => e.Id == id);
        }
    }
}
