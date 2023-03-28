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
    public class ExcerciseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        

        public ExcerciseController( IAppUOW uow,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: Excercise
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.ExerciseRepository.AllAsync();
            return View(vm);
        }

        // GET: Excercise/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // GET: Excercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excercise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,Level")] Excercise excercise)
        {
            if (ModelState.IsValid)
            {
                excercise.Id = Guid.NewGuid();
                _uow.ExerciseRepository.Add(excercise);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excercise);
        }

        // GET: Excercise/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }
            return View(excercise);
        }

        // POST: Excercise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                
                _uow.ExerciseRepository.Update(excercise);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(excercise);
        }

        // GET: Excercise/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excercise = await _uow.ExerciseRepository.FindAsync(id.Value);
            if (excercise == null)
            {
                return NotFound();
            }

            return View(excercise);
        }

        // POST: Excercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.ExerciseRepository.RemoveAsync(id);
            await  _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
