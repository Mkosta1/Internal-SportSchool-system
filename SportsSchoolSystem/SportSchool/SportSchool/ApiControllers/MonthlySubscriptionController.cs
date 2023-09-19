using AutoMapper;
using BLL.Contracts.Base;
using DAL.Contracts.App;
using DAL.EF.APP;
using Domain;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Public.DTO.v1.Mappers;

namespace SportSchool.ApiControllers
{
    /// <summary>
    /// Monthly subscription API controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MonthlySubscriptionController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly MonthlySubscriptionMapper _mapper;

        /// <summary>
        /// Monthly subscription controller constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public MonthlySubscriptionController(ApplicationDbContext context, IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new MonthlySubscriptionMapper(autoMapper);
        }

        // GET: api/MonthlySubscription
        /// <summary>
        /// Get monthly subscriptions from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.MonthlySubscription>>> GetMonthlySubscription()
        {
            var data = await 
                _bll.MonthlySubscriptionService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/MonthlySubscription/5
        /// <summary>
        /// GET request with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.MonthlySubscription>> GetMonthlySubscription(Guid id)
        {
            var monthlySubscription = await _bll.MonthlySubscriptionService.FindAsync(id, User.GetUserId());

            if (monthlySubscription == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(monthlySubscription);

            return res!;
        }

        // PUT: api/MonthlySubscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add monthly subscription to database with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monthlySubscription"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlySubscription(Guid id, Public.DTO.v1.v1.MonthlySubscription monthlySubscription)
        {
            if (id != monthlySubscription.Id)
            {
                return BadRequest();
            }
            


            var bllMonthlySubscription = _mapper.Map(monthlySubscription);
            

            _bll.MonthlySubscriptionService.Update(bllMonthlySubscription!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/MonthlySubscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request for monthly subscription
        /// </summary>
        /// <param name="monthlySubscription"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MonthlySubscription>> PostMonthlySubscription(Public.DTO.v1.v1.MonthlySubscription monthlySubscription)
        {
            var bllMonthlySubscription = _mapper.Map(monthlySubscription);
            

            _bll.MonthlySubscriptionService.Add(bllMonthlySubscription!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetMonthlySubscription", new { id = monthlySubscription.Id }, monthlySubscription);
        }

        // DELETE: api/MonthlySubscription/5
        /// <summary>
        /// Delete selected with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthlySubscription(Guid id)
        {
            var monthlySubscription = await _bll.MonthlySubscriptionService.RemoveAsync(id, User.GetUserId());

            if (monthlySubscription == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
