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
    public class ExcerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExcerciseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Excercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excercise>>> GetExcercise()
        {
            return await _context.Excercise.ToListAsync();
        }

        // GET: api/Excercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excercise>> GetExcercise(int id)
        {
            var excercise = await _context.Excercise.FindAsync(id);

            if (excercise == null)
            {
                return NotFound();
            }

            return excercise;
        }

        // PUT: api/Excercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcercise(int id, Excercise excercise)
        {
            if (id != excercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(excercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcerciseExists(id))
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

        // POST: api/Excercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Excercise>> PostExcercise(Excercise excercise)
        {
            _context.Excercise.Add(excercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcercise", new { id = excercise.Id }, excercise);
        }

        // DELETE: api/Excercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcercise(int id)
        {
            var excercise = await _context.Excercise.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            _context.Excercise.Remove(excercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExcerciseExists(int id)
        {
            return _context.Excercise.Any(e => e.Id == id);
        }
    }
}
