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
    /// Sportsschool API controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SportsSchoolController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly SportsSchoolMapper _mapper;

        /// <summary>
        /// Sportschool controller constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public SportsSchoolController(ApplicationDbContext context, IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new SportsSchoolMapper(autoMapper);
        }

        // GET: api/Sportschool
        /// <summary>
        /// GET request sportschool from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.SportsSchool>>> GetSportsSchool()
        {
            var data = await 
                _bll.SportsSchoolService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/Sportschool/5
        /// <summary>
        /// GET request with selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.SportsSchool>> GetSportsSchool(Guid id)
        {
            var sportSchool = await _bll.SportsSchoolService.FindAsync(id, User.GetUserId());

            if (sportSchool == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(sportSchool);

            return res!;
        }

        // PUT: api/Sportschool/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Put sportschool with id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sportsSchool"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportsSchool(Guid id, Public.DTO.v1.v1.SportsSchool sportsSchool)
        {
            if (id != sportsSchool.Id)
            {
                return BadRequest();
            }


            var bllSportsSchool = _mapper.Map(sportsSchool);
            

            _bll.SportsSchoolService.Update(bllSportsSchool!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Sportschool
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request for sportschool
        /// </summary>
        /// <param name="sportsSchool"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SportsSchool>> PostSportsSchool(Public.DTO.v1.v1.SportsSchool sportsSchool)
        {
            var bllSportsSchool = _mapper.Map(sportsSchool);
            

            _bll.SportsSchoolService.Add(bllSportsSchool!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetSportsSchool", new { id = sportsSchool.Id }, sportsSchool);
        }

        // DELETE: api/Sportschool/5
        /// <summary>
        /// Delete sprtchool from database with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportsSchool(Guid id)
        {
            var sportsSchool = await _bll.SportsSchoolService.RemoveAsync(id, User.GetUserId());

            if (sportsSchool == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }

       
    }
}
