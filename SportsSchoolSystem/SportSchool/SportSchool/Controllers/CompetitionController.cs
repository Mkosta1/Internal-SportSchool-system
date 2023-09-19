using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.EF.APP;
using Domain;
using Domain.App.Identity;
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SportSchool.Controllers
{
    /// <summary>
    /// Competition controller for api
    /// </summary>

    [Authorize]
    public class CompetitionController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        private readonly ApplicationDbContext _data;

        /// <summary>
        /// Competition controller constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>

        public CompetitionController(UserManager<AppUser> userManager, IAppUOW uow, ApplicationDbContext data)
        {
            _userManager = userManager;
            _uow = uow;
            _data = data;
        }

        // GET: Competition
        /// <summary>
        /// Get view of tables in competition db
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> Index()
        {
            var vm = await 
                _uow.CompetitionRepository.AllAsync(User.GetUserId());
            return View(vm);

        }

        // GET: Competition/Details/5
        /// <summary>
        /// Detail view of selected competition by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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
        /// <summary>
        /// Returns create view
        /// </summary>
        /// <returns></returns>

        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_data.Location, "Id", "Name");
            return View();
        }

        // POST: Competition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Add new competition to database
        /// </summary>
        /// <param name="competition"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Group_size,Since,Until,LocationId,Id")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                competition.Id = Guid.NewGuid();
                _uow.CompetitionRepository.Add(competition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocationId"] = new SelectList(_data.Location, "Id", "Name", competition.LocationId);
            return View(competition);
        }

        // GET: Competition/Edit/5
        /// <summary>
        /// Get the edit view for needed competition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

            ViewData["LocationId"] = new SelectList(_data.Location, "Id", "Name", competition.LocationId);
            return View(competition);
        }

        // POST: Competition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Save edited competiton
        /// </summary>
        /// <param name="id"></param>
        /// <param name="competition"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Group_size,Since,Until,LocationId,Id")] Competition competition)
        {
            if (id != competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid  &&

                await _uow.CompetitionRepository.IsOwnedByUserAsync(competition.Id, User.GetUserId())
               )
            {
                _uow.CompetitionRepository.Update(competition);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocationId"] = new SelectList(_data.Location, "Id", "Name", competition.LocationId);
            return View(competition);
        }

        // GET: Competition/Delete/5
        /// <summary>
        /// Delete selected competition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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
        /// <summary>
        /// Get confirmed screen for deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.CompetitionRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        
    }
}