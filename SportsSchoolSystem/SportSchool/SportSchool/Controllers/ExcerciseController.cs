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
    /// Exercise controller 
    /// </summary>
    [Authorize]
    public class ExcerciseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        private readonly ApplicationDbContext _data;
        

        /// <summary>
        /// Exercise controller constructor
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="userManager"></param>
        public ExcerciseController( IAppUOW uow,
            UserManager<AppUser> userManager, ApplicationDbContext data)
        {
            _userManager = userManager;
            _uow = uow;
            _data = data;
        }

        // GET: Excercise
        /// <summary>
        /// Return list of exercises
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.ExcerciseRepository.AllAsync();
            return View(vm);
        }

        // GET: Excercise/Details/5
        /// <summary>
        /// Get to detail view of exercise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExcerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // GET: Excercise/Create
        /// <summary>
        /// Return create view for creating exercise
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excercise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new exercise and add to database
        /// </summary>
        /// <param name="excercise"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Level")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                excercise.Id = Guid.NewGuid();
                _uow.ExcerciseRepository.Add(excercise);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excercise);
        }

        // GET: Excercise/Edit/5
        /// <summary>
        /// Return view of selected exercise you want to edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExcerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }
            return View(excercise);
        }

        // POST: Excercise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit and save exercise to db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="excercise"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Duration,Level")] Excercise excercise)
        {
            if (id != excercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.ExcerciseRepository.Update(excercise);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(excercise);
        }

        // GET: Excercise/Delete/5
        /// <summary>
        /// Return view of deleted exercise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExcerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // POST: Excercise/Delete/5
        /// <summary>
        /// Get confirmation for deleteing exercise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.ExcerciseRepository.RemoveAsync(id, User.GetUserId());
            await  _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
