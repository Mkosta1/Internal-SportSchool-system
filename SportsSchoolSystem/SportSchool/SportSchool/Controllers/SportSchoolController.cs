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
    public class SportSchoolController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;

        public SportSchoolController(
            UserManager<AppUser> userManager,
            IAppUOW uow)
        {
            _userManager = userManager;
            _uow = uow;
        }

        // GET: SportSchool
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.SportSchoolRepository.AllAsync();
            return View(vm);
        }

        // GET: SportSchool/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsSchool = await _uow.SportSchoolRepository.FindAsync(id.Value);
            if (sportsSchool == null)
            {
                return NotFound();
            }

            return View(sportsSchool);
        }

        // GET: SportSchool/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportSchool/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,PhoneNumber,Email,Message_id")] SportsSchool sportsSchool)
        {
            if (ModelState.IsValid)
            {
                sportsSchool.Id = Guid.NewGuid();
                _uow.SportSchoolRepository.Add(sportsSchool);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportsSchool);
        }

        // GET: SportSchool/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsSchool = await _uow.SportSchoolRepository.FindAsync(id.Value);
            if (sportsSchool == null)
            {
                return NotFound();
            }
            return View(sportsSchool);
        }

        // POST: SportSchool/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Address,PhoneNumber,Email,Message_id")] SportsSchool sportsSchool)
        {
            if (id != sportsSchool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                _uow.SportSchoolRepository.Update(sportsSchool);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportsSchool);
        }

        // GET: SportSchool/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsSchool = await _uow.SportSchoolRepository.FindAsync(id.Value);
            if (sportsSchool == null)
            {
                return NotFound();
            }

            return View(sportsSchool);
        }

        // POST: SportSchool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.SportSchoolRepository.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
