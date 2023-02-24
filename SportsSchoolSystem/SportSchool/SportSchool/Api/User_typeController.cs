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
    public class User_typeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public User_typeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User_type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_type>>> GetUser_type()
        {
            return await _context.User_type.ToListAsync();
        }

        // GET: api/User_type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_type>> GetUser_type(int id)
        {
            var user_type = await _context.User_type.FindAsync(id);

            if (user_type == null)
            {
                return NotFound();
            }

            return user_type;
        }

        // PUT: api/User_type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_type(int id, User_type user_type)
        {
            if (id != user_type.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_typeExists(id))
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

        // POST: api/User_type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_type>> PostUser_type(User_type user_type)
        {
            _context.User_type.Add(user_type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_type", new { id = user_type.Id }, user_type);
        }

        // DELETE: api/User_type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_type(int id)
        {
            var user_type = await _context.User_type.FindAsync(id);
            if (user_type == null)
            {
                return NotFound();
            }

            _context.User_type.Remove(user_type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_typeExists(int id)
        {
            return _context.User_type.Any(e => e.Id == id);
        }
    }
}
