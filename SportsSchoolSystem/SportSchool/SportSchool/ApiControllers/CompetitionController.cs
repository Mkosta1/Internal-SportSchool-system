using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.EF.APP;
using Domain;
using Helpers.Base;
using Microsoft.AspNetCore.Authorization;

namespace SportSchool.ApiControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CompetitionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppUOW _uow;

        public CompetitionController(ApplicationDbContext context, IAppUOW uow)
        {
            _context = context;
            _uow = uow;
        }

        // GET: api/Competition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetition()
        {
            var vm = await 
                _uow.CompetitionRepository.AllAsync(User.GetUserId());
            
            return Ok(vm);
        }

        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(Guid id)
        {
          if (_context.Competition == null)
          {
              return NotFound();
          }
            var competition = await _context.Competition.FindAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            return competition;
        }

        // PUT: api/Competition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(Guid id, Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Competition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(Competition competition)
        {
            _context.Competition.Add(competition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }

        // DELETE: api/Competition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            if (_context.Competition == null)
            {
                return NotFound();
            }
            var competition = await _context.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _context.Competition.Remove(competition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(Guid id)
        {
            return (_context.Competition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
