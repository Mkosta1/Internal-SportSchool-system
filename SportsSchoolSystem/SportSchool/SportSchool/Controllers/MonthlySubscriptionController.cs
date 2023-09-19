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
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SportSchool.Controllers
{
    /// <summary>
    /// Monthly subscription controller
    /// </summary>
    [Authorize]
    public class MonthlySubscriptionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        private readonly ApplicationDbContext _data;

        /// <summary>
        /// Monthly subscription controller constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>
        public MonthlySubscriptionController(
            UserManager<AppUser> userManager,
            IAppUOW uow, ApplicationDbContext data)
        {
            _userManager = userManager;
            _uow = uow;
            _data = data;
        }

        // GET: MonthlySubscription
        /// <summary>
        /// Return index view with table content
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.MonthlySubscriptionRepository.AllAsync();
            return View(vm);
        }

        // GET: MonthlySubscription/Details/5
        /// <summary>
        /// Return details view for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Return create view for new row
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["SportsSchoolId"] = new SelectList(_data.SportsSchool, "Id", "Address");
            return View();
        }

        // POST: MonthlySubscription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new row to db and save
        /// </summary>
        /// <param name="monthlySubscription"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Date,SportsSchoolId")] MonthlySubscription monthlySubscription)
        {
            if (ModelState.IsValid)
            {
                monthlySubscription.Id = Guid.NewGuid();
                _uow.MonthlySubscriptionRepository.Add(monthlySubscription);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SportsSchoolId"] = new SelectList(_data.SportsSchool, "Id", "Address");
            return View(monthlySubscription);
        }

        // GET: MonthlySubscription/Edit/5
        /// <summary>
        /// Return edit view for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            ViewData["SportsSchoolId"] = new SelectList(_data.SportsSchool, "Id", "Address");
            return View(monthlySubscription);
        }

        // POST: MonthlySubscription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save edited row to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monthlySubscription"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,Date,SportsSchoolId")] MonthlySubscription monthlySubscription)
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
            ViewData["SportsSchoolId"] = new SelectList(_data.SportsSchool, "Id", "Address");
            return View(monthlySubscription);
        }

        // GET: MonthlySubscription/Delete/5
        /// <summary>
        /// Return delete view for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete selected row form db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.MonthlySubscriptionRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
