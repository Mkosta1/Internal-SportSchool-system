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
    public class Sports_schoolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Sports_schoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sports_school
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sports_school>>> GetSports_school()
        {
            return await _context.Sports_school.ToListAsync();
        }

        // GET: api/Sports_school/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sports_school>> GetSports_school(int id)
        {
            var sports_school = await _context.Sports_school.FindAsync(id);

            if (sports_school == null)
            {
                return NotFound();
            }

            return sports_school;
        }

        // PUT: api/Sports_school/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSports_school(int id, Sports_school sports_school)
        {
            if (id != sports_school.Id)
            {
                return BadRequest();
            }

            _context.Entry(sports_school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sports_schoolExists(id))
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

        // POST: api/Sports_school
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sports_school>> PostSports_school(Sports_school sports_school)
        {
            _context.Sports_school.Add(sports_school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSports_school", new { id = sports_school.Id }, sports_school);
        }

        // DELETE: api/Sports_school/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSports_school(int id)
        {
            var sports_school = await _context.Sports_school.FindAsync(id);
            if (sports_school == null)
            {
                return NotFound();
            }

            _context.Sports_school.Remove(sports_school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sports_schoolExists(int id)
        {
            return _context.Sports_school.Any(e => e.Id == id);
        }
    }
}
