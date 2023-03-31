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
    public class UserAtTrainingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        
        public UserAtTrainingController(UserManager<AppUser> userManager, IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: UserAtTraining
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.UserAtTrainingRepository.AllAsync();
            return View(vm);
        }

        // GET: UserAtTraining/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtTraining = await _uow.UserAtTrainingRepository.FindAsync(id.Value);
            if (userAtTraining == null)
            {
                return NotFound();
            }

            return View(userAtTraining);
        }

        // GET: UserAtTraining/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAtTraining/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Since,Until,Training_id")] UserAtTraining userAtTraining)
        {
            if (ModelState.IsValid)
            {
                userAtTraining.Id = Guid.NewGuid();
                _uow.UserAtTrainingRepository.Add(userAtTraining);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAtTraining);
        }

        // GET: UserAtTraining/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtTraining = await _uow.UserAtTrainingRepository.FindAsync(id.Value);
            if (userAtTraining == null)
            {
                return NotFound();
            }
            return View(userAtTraining);
        }

        // POST: UserAtTraining/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Since,Until,Training_id")] UserAtTraining userAtTraining)
        {
            if (id != userAtTraining.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.UserAtTrainingRepository.Update(userAtTraining);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(userAtTraining);
        }

        // GET: UserAtTraining/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtTraining = await _uow.UserAtTrainingRepository.FindAsync(id.Value);
            if (userAtTraining == null)
            {
                return NotFound();
            }

            return View(userAtTraining);
        }

        // POST: UserAtTraining/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.UserAtTrainingRepository.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
