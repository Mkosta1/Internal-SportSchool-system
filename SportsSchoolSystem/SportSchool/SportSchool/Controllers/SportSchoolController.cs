using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contracts.Base;
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
    /// Sportschool controller
    /// </summary>
    [Authorize]
    public class SportSchoolController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUOW _uow;
        private readonly ApplicationDbContext _data;

        /// <summary>
        /// Sports school controller constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="uow"></param>
        public SportSchoolController(
            UserManager<AppUser> userManager,
            IAppUOW uow, IAppBLL bll, ApplicationDbContext data)
        {
            _userManager = userManager;
            _uow = uow;
            _data = data;
            
        }

        // GET: SportSchool
        /// <summary>
        /// Return index view of the table
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var vm = await _uow.SportSchoolRepository.AllAsync();

            return View(vm);
        }

        // GET: SportSchool/Details/5
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

            var sportsSchool = await _uow.SportSchoolRepository.FindAsync(id.Value);
            if (sportsSchool == null)
            {
                return NotFound();
            }

            return View(sportsSchool);
        }

        // GET: SportSchool/Create
        /// <summary>
        /// Return create view to add new row
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["MessageId"] = new SelectList(_data.Message, "Id", "Subject");
            return View();
        }

        // POST: SportSchool/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new row to db
        /// </summary>
        /// <param name="sportsSchool"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,PhoneNumber,Email,MessageId")] SportsSchool sportsSchool)
        {
            if (ModelState.IsValid)
            {
                sportsSchool.Id = Guid.NewGuid();
                _uow.SportSchoolRepository.Add(sportsSchool);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MessageId"] = new SelectList(_data.Message, "Id", "Subject");
            return View(sportsSchool);
        }

        // GET: SportSchool/Edit/5
        /// <summary>
        /// Return edit view for selected row
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            ViewData["MessageId"] = new SelectList(_data.Message, "Id", "Subject");
            return View(sportsSchool);
        }

        // POST: SportSchool/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit selected row and update database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sportsSchool"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Address,PhoneNumber,Email,MessageId")] SportsSchool sportsSchool)
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
            ViewData["MessageId"] = new SelectList(_data.Message, "Id", "Subject");
            return View(sportsSchool);
        }

        // GET: SportSchool/Delete/5
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

            var sportsSchool = await _uow.SportSchoolRepository.FindAsync(id.Value);
            if (sportsSchool == null)
            {
                return NotFound();
            }

            return View(sportsSchool);
        }

        // POST: SportSchool/Delete/5
        /// <summary>
        /// Delete selected row from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.SportSchoolRepository.RemoveAsync(id, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
