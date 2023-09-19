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
    /// Training controller
    /// </summary>
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        /// <summary>
        /// Training controller constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>
        public TrainingController(UserManager<AppUser> userManager, IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: Training
        /// <summary>
        /// Return table of db content
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.TrainingRepository.AllAsync();
            return View(vm);
        }

        // GET: Training/Details/5
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

            var training = await _uow.TrainingRepository.FindAsync(id.Value);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Training/Create
        /// <summary>
        /// Return create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add new row to db
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Location_id,Excercise_id,Sports_school_id")] Training training)
        {
            if (ModelState.IsValid)
            {
                training.Id = Guid.NewGuid();
                _uow.TrainingRepository.Add(training);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Training/Edit/5
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

            var training = await _uow.TrainingRepository.FindAsync(id.Value);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Training/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Update db with new information for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Duration,Location_id,Excercise_id,Sports_school_id")] Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.TrainingRepository.Update(training);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Training/Delete/5
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

            var training = await _uow.TrainingRepository.FindAsync(id.Value);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Training/Delete/5
        /// <summary>
        /// Delete selected row from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.TrainingRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
