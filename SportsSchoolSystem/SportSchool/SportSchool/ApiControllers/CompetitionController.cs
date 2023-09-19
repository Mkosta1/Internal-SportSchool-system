using AutoMapper;
using BLL.Contracts.Base;
using Microsoft.AspNetCore.Mvc;
using DAL.EF.APP;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.v1.Mappers;

namespace SportSchool.ApiControllers
{
    /// <summary>
    /// Controller for the Competition API
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CompetitionController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CompetitionMapper _mapper;

        /// <summary>
        /// Constructor for competitionController
        /// Using bll layer and autoMapper for mapping
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bll"></param>
        /// <param name="autoMapper"></param>
        public CompetitionController(ApplicationDbContext context, IAppBLL bll, IMapper? autoMapper)
        {
            _bll = bll;
            _mapper = new CompetitionMapper(autoMapper);
        }

        // GET: api/Competition
        /// <summary>
        /// For the API to get the data from bll layer
        /// </summary>
        /// <returns>
        /// Returns competition table data
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.Competition>>> GetCompetition()
        {
            var data = await
                _bll.CompetitionService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();

            return res!;
        }

        // GET: api/Competition/5
        /// <summary>
        /// Find user competitions with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns competition with selected id
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.Competition>> GetCompetition(Guid id)
        {
            var competition = await _bll.CompetitionService.FindAsync(id, User.GetUserId());

            if (competition == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(competition);

            return res!;
        }

        // PUT: api/Competition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Adds competition to database with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="competition"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(Guid id, Public.DTO.v1.v1.Competition competition)
        {
            if (id != competition.Id)
            {
                return BadRequest();
            }

           

            var bllCompetition = _mapper.Map(competition);

            _bll.CompetitionService.Update(bllCompetition!);

            await _bll.SaveChangesAsync();


            return NoContent();

        }

        // POST: api/Competition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Send post request with wanted competition
        /// </summary>
        /// <param name="competition"></param>
        /// <returns>
        /// Returns selected competition id
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Public.DTO.v1.v1.Competition>> PostCompetition(Public.DTO.v1.v1.Competition competition)
        {
            var bllCompetition = _mapper.Map(competition);

            _bll.CompetitionService.Add(bllCompetition!);
            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetCompetition", new { id = competition.Id }, competition);
        }

        // DELETE: api/Competition/5
        /// <summary>
        /// Deletes competition with selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            var competition = await _bll.CompetitionService.RemoveAsync(id, User.GetUserId());

            if (competition == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();

        }
        
    }
}