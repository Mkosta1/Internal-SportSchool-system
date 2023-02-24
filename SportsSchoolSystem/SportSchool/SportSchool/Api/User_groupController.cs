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
    public class User_groupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public User_groupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User_group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_group>>> GetUser_group()
        {
            return await _context.User_group.ToListAsync();
        }

        // GET: api/User_group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_group>> GetUser_group(int id)
        {
            var user_group = await _context.User_group.FindAsync(id);

            if (user_group == null)
            {
                return NotFound();
            }

            return user_group;
        }

        // PUT: api/User_group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_group(int id, User_group user_group)
        {
            if (id != user_group.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_groupExists(id))
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

        // POST: api/User_group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_group>> PostUser_group(User_group user_group)
        {
            _context.User_group.Add(user_group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_group", new { id = user_group.Id }, user_group);
        }

        // DELETE: api/User_group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_group(int id)
        {
            var user_group = await _context.User_group.FindAsync(id);
            if (user_group == null)
            {
                return NotFound();
            }

            _context.User_group.Remove(user_group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_groupExists(int id)
        {
            return _context.User_group.Any(e => e.Id == id);
        }
    }
}
