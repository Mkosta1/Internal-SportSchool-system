using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace SportSchool.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompetitionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Competition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competition>>> GetCompetition()
        {
            return await _context.Competition.ToListAsync();
        }

        // GET: api/Competition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Competition>> GetCompetition(int id)
        {
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
        public async Task<IActionResult> PutCompetition(int id, Competition competition)
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
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var competition = await _context.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _context.Competition.Remove(competition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competition.Any(e => e.Id == id);
        }
    }
}
