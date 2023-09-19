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
    /// User Group controller
    /// </summary>
    [Authorize]
    public class UserGroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        /// <summary>
        /// User group constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>
        public UserGroupController(UserManager<AppUser> userManager, IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: UserGroup
        /// <summary>
        /// Return index view with table
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.UserGroupRepository.AllAsync();
            return View(vm);
        }

        // GET: UserGroup/Details/5
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

            var userGroup = await _uow.UserGroupRepository.FindAsync(id.Value);
            if (userGroup == null)
            {
                return NotFound();
            }

            return View(userGroup);
        }

        // GET: UserGroup/Create
        /// <summary>
        /// Return creat view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new row to db
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                userGroup.Id = Guid.NewGuid();
                _uow.UserGroupRepository.Add(userGroup);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userGroup);
        }

        // GET: UserGroup/Edit/5
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

            var userGroup = await _uow.UserGroupRepository.FindAsync(id.Value);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update database with selected row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Size")] UserGroup userGroup)
        {
            if (id != userGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.UserGroupRepository.Update(userGroup);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(userGroup);
        }

        // GET: UserGroup/Delete/5
        /// <summary>
        /// Return delete view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroup = await _uow.UserGroupRepository.FindAsync(id.Value);
            if (userGroup == null)
            {
                return NotFound();
            }

            return View(userGroup);
        }

        // POST: UserGroup/Delete/5
        /// <summary>
        /// Delete selected row from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.UserGroupRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
