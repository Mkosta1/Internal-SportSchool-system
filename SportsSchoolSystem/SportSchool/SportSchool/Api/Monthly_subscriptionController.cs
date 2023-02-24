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
    public class Monthly_subscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Monthly_subscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Monthly_subscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monthly_subscription>>> GetMonthly_subscription()
        {
            return await _context.Monthly_subscription.ToListAsync();
        }

        // GET: api/Monthly_subscription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monthly_subscription>> GetMonthly_subscription(int id)
        {
            var monthly_subscription = await _context.Monthly_subscription.FindAsync(id);

            if (monthly_subscription == null)
            {
                return NotFound();
            }

            return monthly_subscription;
        }

        // PUT: api/Monthly_subscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthly_subscription(int id, Monthly_subscription monthly_subscription)
        {
            if (id != monthly_subscription.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthly_subscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Monthly_subscriptionExists(id))
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

        // POST: api/Monthly_subscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monthly_subscription>> PostMonthly_subscription(Monthly_subscription monthly_subscription)
        {
            _context.Monthly_subscription.Add(monthly_subscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthly_subscription", new { id = monthly_subscription.Id }, monthly_subscription);
        }

        // DELETE: api/Monthly_subscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthly_subscription(int id)
        {
            var monthly_subscription = await _context.Monthly_subscription.FindAsync(id);
            if (monthly_subscription == null)
            {
                return NotFound();
            }

            _context.Monthly_subscription.Remove(monthly_subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Monthly_subscriptionExists(int id)
        {
            return _context.Monthly_subscription.Any(e => e.Id == id);
        }
    }
}
