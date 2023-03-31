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
    [Authorize]
    public class CompetitionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        public CompetitionController(
            UserManager<AppUser> userManager,
            IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: Competition
        public async Task<IActionResult> Index()
        {
            var vm = await 
                _uow.CompetitionRepository.AllAsync(User.GetUserId());
            return View(vm);
        }

        // GET: Competition/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _uow.CompetitionRepository.FindAsync(id.Value);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // GET: Competition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Group_size,Since,Until,Location_id")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                competition.Id = Guid.NewGuid();
                _uow.CompetitionRepository.Add(competition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competition);
        }

        // GET: Competition/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _uow.CompetitionRepository.FindAsync(id.Value);
            if (competition == null)
            {
                return NotFound();
            }
            return View(competition);
        }

        // POST: Competition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Group_size,Since,Until,Location_id")] Competition competition)
        {
            if (id != competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.CompetitionRepository.Update(competition);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(competition);
        }

        // GET: Competition/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _uow.CompetitionRepository.FindAsync(id.Value);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // POST: Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.CompetitionRepository.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
