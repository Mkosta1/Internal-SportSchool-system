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
    public class User_in_groupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public User_in_groupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User_in_group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_in_group>>> GetUser_in_group()
        {
            return await _context.User_in_group.ToListAsync();
        }

        // GET: api/User_in_group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_in_group>> GetUser_in_group(int id)
        {
            var user_in_group = await _context.User_in_group.FindAsync(id);

            if (user_in_group == null)
            {
                return NotFound();
            }

            return user_in_group;
        }

        // PUT: api/User_in_group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_in_group(int id, User_in_group user_in_group)
        {
            if (id != user_in_group.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_in_group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_in_groupExists(id))
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

        // POST: api/User_in_group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_in_group>> PostUser_in_group(User_in_group user_in_group)
        {
            _context.User_in_group.Add(user_in_group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_in_group", new { id = user_in_group.Id }, user_in_group);
        }

        // DELETE: api/User_in_group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_in_group(int id)
        {
            var user_in_group = await _context.User_in_group.FindAsync(id);
            if (user_in_group == null)
            {
                return NotFound();
            }

            _context.User_in_group.Remove(user_in_group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_in_groupExists(int id)
        {
            return _context.User_in_group.Any(e => e.Id == id);
        }
    }
}
