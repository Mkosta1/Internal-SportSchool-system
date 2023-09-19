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
    /// <inheritdoc />
    [Authorize]
    public class UserInGroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        private readonly ApplicationDbContext _context;

        /// <inheritdoc />
        public UserInGroupController(UserManager<AppUser> userManager, IAppUOW uow, ApplicationDbContext context)
        {
            _userManager = userManager;
            _uow = uow;
            _context = context;
        }

        // GET: UserInGroup
        /// <summary>
        /// Return index view with table
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.UserInGroupRepository.AllAsync();
            return View(vm);
        }

        // GET: UserInGroup/Details/5
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

            var userInGroup = await _uow.UserInGroupRepository.FindAsync(id.Value);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // GET: UserInGroup/Create
        /// <summary>
        /// Return create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "Id", "Name");
            return View();
        }

        // POST: UserInGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new row to db
        /// </summary>
        /// <param name="userInGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Since,Until,UserGroupId, AppUserId")] UserInGroup userInGroup)
        {
            if (ModelState.IsValid)
            {
                userInGroup.Id = Guid.NewGuid();
                _uow.UserInGroupRepository.Add(userInGroup);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "Id", "Name");
            return View(userInGroup);
        }

        // GET: UserInGroup/Edit/5
        /// <summary>
        /// Return selected row edit view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInGroup = await  _uow.UserInGroupRepository.FindAsync(id.Value);
            if (userInGroup == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "Id", "Name");
            return View(userInGroup);
        }

        // POST: UserInGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update db for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userInGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Since,Until,UserGroupId, AppUserId")] UserInGroup userInGroup)
        {
            if (id != userInGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.UserInGroupRepository.Update(userInGroup);
                await _uow.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroup, "Id", "Name");
            return View(userInGroup);
        }

        // GET: UserInGroup/Delete/5
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

            var userInGroup = await _uow.UserInGroupRepository.FindAsync(id.Value);
            if (userInGroup == null)
            {
                return NotFound();
            }

            return View(userInGroup);
        }

        // POST: UserInGroup/Delete/5
        /// <summary>
        /// Delete selected row from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.UserInGroupRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
