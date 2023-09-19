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
using Microsoft.AspNetCore.Identity;

namespace SportSchool.Controllers
{
    public class UserAtCompetitionController : Controller
    {
        private readonly ApplicationDbContext _data;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        public UserAtCompetitionController(ApplicationDbContext context, UserManager<AppUser> userManager, IAppUOW uow)
        {
            _data = context;
            _userManager = userManager;
            _uow = uow;
        }

        // GET: UserAtCompetition
        public async Task<IActionResult> Index()
        {
            var vm = await 
                _uow.UserAtCompetitionRepository.AllAsync(User.GetUserId());
            return View(vm);
        }

        // GET: UserAtCompetition/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtCompetition = await _uow.UserAtCompetitionRepository.FindAsync(id.Value);
            if (userAtCompetition == null)
            {
                return NotFound();
            }

            return View(userAtCompetition);
        }

        // GET: UserAtCompetition/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_data.Users, "Id", "FirstName");
            ViewData["CompetitionId"] = new SelectList(_data.Competition, "Id", "Name");
            return View();
        }

        // POST: UserAtCompetition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Since,Until,CompetitionId,AppUserId,Id")] UserAtCompetition userAtCompetition)
        {
            if (ModelState.IsValid)
            {
                userAtCompetition.Id = Guid.NewGuid();
                _uow.UserAtCompetitionRepository.Add(userAtCompetition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_data.Users, "Id", "FirstName", userAtCompetition.AppUserId);
            ViewData["CompetitionId"] = new SelectList(_data.Competition, "Id", "Name", userAtCompetition.CompetitionId);
            return View(userAtCompetition);
        }

        // GET: UserAtCompetition/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtCompetition = await _uow.UserAtCompetitionRepository.FindAsync(id.Value);
            if (userAtCompetition == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_data.Users, "Id", "FirstName", userAtCompetition.AppUserId);
            ViewData["CompetitionId"] = new SelectList(_data.Competition, "Id", "Name", userAtCompetition.CompetitionId);
            return View(userAtCompetition);
        }

        // POST: UserAtCompetition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Since,Until,CompetitionId,AppUserId,Id")] UserAtCompetition userAtCompetition)
        {
            if (id != userAtCompetition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid  &&

                await _uow.UserAtCompetitionRepository.IsOwnedByUserAsync(userAtCompetition.Id, User.GetUserId())
               )
            {
                
                _uow.UserAtCompetitionRepository.Update(userAtCompetition);
                await _uow.SaveChangesAsync();
                    
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_data.Users, "Id", "FirstName", userAtCompetition.AppUserId);
            ViewData["CompetitionId"] = new SelectList(_data.Competition, "Id", "Name", userAtCompetition.CompetitionId);
            return View(userAtCompetition);
        }

        // GET: UserAtCompetition/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAtCompetition = await _uow.UserAtCompetitionRepository.FindAsync(id.Value);
                
            if (userAtCompetition == null)
            {
                return NotFound();
            }

            return View(userAtCompetition);
        }

        // POST: UserAtCompetition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.UserAtCompetitionRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
