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
    /// Location controller
    /// </summary>
    [Authorize]
    public class LocationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        
        /// <summary>
        /// Location controller constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>
        public LocationController(UserManager<AppUser> userManager,
            IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: Location
        /// <summary>
        /// Return index view of controller
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.LocationRepository.AllAsync();
            return View(vm);
        }

        // GET: Location/Details/5
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

            var location = await _uow.LocationRepository.FindAsync(id.Value);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Location/Create
        /// <summary>
        /// Return create view 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new location and add to db
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] Location location)
        {
            if (ModelState.IsValid)
            {
                location.Id = Guid.NewGuid();
                _uow.LocationRepository.Add(location);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Location/Edit/5
        /// <summary>
        /// Return edit view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _uow.LocationRepository.FindAsync(id.Value);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save and edit seleceted row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Address")] Location location)
        {
            if (id != location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.LocationRepository.Update(location);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(location);
        }

        // GET: Location/Delete/5
        /// <summary>
        /// Return delete view for the row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _uow.LocationRepository.FindAsync(id.Value);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Location/Delete/5
        /// <summary>
        /// Delete the row and confirm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.LocationRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
