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
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserAtCompetitionController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly UserAtCompetitionMapper _mapper;

        public UserAtCompetitionController(ApplicationDbContext context, IAppBLL bll, IMapper autoMapper)
        {
            _bll = bll;
            _mapper = new UserAtCompetitionMapper(autoMapper);
        }

        // GET: api/UserAtCompetition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.UserAtCompetition>>> GetUserAtCompetition()
        {
            var data = await
                _bll.UserAtCompetitionService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();

            return res!;
        }

        // GET: api/UserAtCompetition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.UserAtCompetition>> GetUserAtCompetition(Guid id)
        {
          var userAtCompetition = await _bll.UserAtCompetitionService.FindAsync(id, User.GetUserId());

          if (userAtCompetition == null)
          {
              return NotFound();
          }
            
          var res = _mapper.Map(userAtCompetition);

          return res!;
        }

        // PUT: api/UserAtCompetition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAtCompetition(Guid id, Public.DTO.v1.v1.UserAtCompetition userAtCompetition)
        {
            if (id != userAtCompetition.Id)
            {
                return BadRequest();
            }
            
            var bllUserAtCompetition = _mapper.Map(userAtCompetition);

            _bll.UserAtCompetitionService.Update(bllUserAtCompetition!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/UserAtCompetition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Public.DTO.v1.v1.UserAtCompetition>> PostUserAtCompetition(Public.DTO.v1.v1.UserAtCompetition userAtCompetition)
        {
            var bllUserAtCompetition = _mapper.Map(userAtCompetition);

            _bll.UserAtCompetitionService.Add(bllUserAtCompetition!);
            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetUserAtCompetition", new { id = userAtCompetition.Id }, userAtCompetition);
        }

        // DELETE: api/UserAtCompetition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAtCompetition(Guid id)
        {
            var userAtCompetition = await _bll.UserAtCompetitionService.RemoveAsync(id, User.GetUserId());

            if (userAtCompetition == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
