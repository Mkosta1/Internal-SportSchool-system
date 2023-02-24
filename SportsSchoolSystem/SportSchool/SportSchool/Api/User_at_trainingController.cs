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
    public class User_at_trainingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public User_at_trainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User_at_training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_at_training>>> GetUser_at_training()
        {
            return await _context.User_at_training.ToListAsync();
        }

        // GET: api/User_at_training/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_at_training>> GetUser_at_training(int id)
        {
            var user_at_training = await _context.User_at_training.FindAsync(id);

            if (user_at_training == null)
            {
                return NotFound();
            }

            return user_at_training;
        }

        // PUT: api/User_at_training/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_at_training(int id, User_at_training user_at_training)
        {
            if (id != user_at_training.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_at_training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_at_trainingExists(id))
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

        // POST: api/User_at_training
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_at_training>> PostUser_at_training(User_at_training user_at_training)
        {
            _context.User_at_training.Add(user_at_training);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_at_training", new { id = user_at_training.Id }, user_at_training);
        }

        // DELETE: api/User_at_training/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_at_training(int id)
        {
            var user_at_training = await _context.User_at_training.FindAsync(id);
            if (user_at_training == null)
            {
                return NotFound();
            }

            _context.User_at_training.Remove(user_at_training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_at_trainingExists(int id)
        {
            return _context.User_at_training.Any(e => e.Id == id);
        }
    }
}
