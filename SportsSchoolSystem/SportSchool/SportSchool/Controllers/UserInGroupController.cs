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
using Microsoft.AspNetCore.Identity;

namespace SportSchool.Controllers
{
    public class UserInGroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        public UserInGroupController(UserManager<AppUser> userManager, IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: UserInGroup
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.UserInGroupRepository.AllAsync();
            return View(vm);
        }

        // GET: UserInGroup/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserInGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Since,Until,User_group_id")] UserInGroup userInGroup)
        {
            if (ModelState.IsValid)
            {
                userInGroup.Id = Guid.NewGuid();
                _uow.UserInGroupRepository.Add(userInGroup);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInGroup);
        }

        // GET: UserInGroup/Edit/5
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
            return View(userInGroup);
        }

        // POST: UserInGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Since,Until,User_group_id")] UserInGroup userInGroup)
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
            return View(userInGroup);
        }

        // GET: UserInGroup/Delete/5
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.UserInGroupRepository.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
