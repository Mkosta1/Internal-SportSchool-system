using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.APP;
using DAL.EF.APP.Repositories;
using Domain;
using Domain.App.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SportSchool.Controllers
{
    [Authorize]
    public class MonthlySubscriptionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        public MonthlySubscriptionController(
            UserManager<AppUser> userManager,
            IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: MonthlySubscription
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.MonthlySubscriptionRepository.AllAsync();
            return View(vm);
        }

        // GET: MonthlySubscription/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlySubscription = await _uow.MonthlySubscriptionRepository.FindAsync(id.Value);
            if (monthlySubscription == null)
            {
                return NotFound();
            }

            return View(monthlySubscription);
        }

        // GET: MonthlySubscription/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonthlySubscription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Date,Sports_school_id")] MonthlySubscription monthlySubscription)
        {
            if (ModelState.IsValid)
            {
                monthlySubscription.Id = Guid.NewGuid();
                _uow.MonthlySubscriptionRepository.Add(monthlySubscription);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monthlySubscription);
        }

        // GET: MonthlySubscription/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlySubscription = await _uow.MonthlySubscriptionRepository.FindAsync(id.Value);
            if (monthlySubscription == null)
            {
                return NotFound();
            }
            return View(monthlySubscription);
        }

        // POST: MonthlySubscription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Date,Sports_school_id")] MonthlySubscription monthlySubscription)
        {
            if (id != monthlySubscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.MonthlySubscriptionRepository.Update(monthlySubscription);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(monthlySubscription);
        }

        // GET: MonthlySubscription/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlySubscription = await _uow.MonthlySubscriptionRepository.FindAsync(id.Value);
            if (monthlySubscription == null)
            {
                return NotFound();
            }

            return View(monthlySubscription);
        }

        // POST: MonthlySubscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.MonthlySubscriptionRepository.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
