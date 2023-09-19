using AutoMapper;
using BLL.Contracts.Base;
using DAL.Contracts.App;
using DAL.EF.APP;
using Domain;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Public.DTO.v1.Mappers;

namespace SportSchool.ApiControllers
{
    /// <summary>
    /// LocationController for the location API
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly LocationMapper _mapper;

        /// <summary>
        /// LocationController constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public LocationController(ApplicationDbContext context, IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;

            _mapper = new LocationMapper(autoMapper);
        }

        // GET: api/Location
        /// <summary>
        /// Gets location with GET request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.Location>>> GetLocation()
        {
            var data = await 
                _bll.LocationService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/Location/5
        /// <summary>
        /// Gets location with GET request and selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.Location>> GetLocation(Guid id)
        {
            var location = await _bll.LocationService.FindAsync(id, User.GetUserId());

            if (location == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(location);

            return res!;
        }

        // PUT: api/Location/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Adds location to db with selected id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(Guid id, Public.DTO.v1.v1.Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }
            


            var bllLocation = _mapper.Map(location);
            

            _bll.LocationService.Update(bllLocation!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Location
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request from database
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Public.DTO.v1.v1.Location location)
        {
            var bllLocation = _mapper.Map(location);
            


            _bll.LocationService.Add(bllLocation!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Location/5
        /// <summary>
        /// Deletes selected location with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            var location = await _bll.LocationService.RemoveAsync(id, User.GetUserId());

            if (location == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
