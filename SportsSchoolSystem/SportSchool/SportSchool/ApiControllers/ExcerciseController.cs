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
    /// Controller for excercise api
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExcerciseController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ExcerciseMapper _mapper;

        /// <summary>
        /// ExcerciseController constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uow"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public ExcerciseController(ApplicationDbContext context, IAppUOW uow, IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new ExcerciseMapper(autoMapper);
        }

        // GET: api/Excercise
        /// <summary>
        /// Get all Excercises from the table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.Excercise>>> GetExcercise()
        {
            var data = await 
                _bll.ExcerciseService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/Excercise/5
        /// <summary>
        /// Get selected excercise with wanted id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.Excercise>> GetExcercise(Guid id)
        {
            var excercise = await _bll.ExcerciseService.FindAsync(id, User.GetUserId());

            if (excercise == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(excercise);

            return res!;
        }

        // PUT: api/Excercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Get excercise by user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="excercise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcercise(Guid id, Public.DTO.v1.v1.Excercise excercise)
        {
            if (id != excercise.Id)
            {
                return BadRequest();
            }


            var bllExcercise = _mapper.Map(excercise);
            

            _bll.ExcerciseService.Update(bllExcercise!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Excercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Send exercise with post request 
        /// </summary>
        /// <param name="excercise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Excercise>> PostExcercise(Public.DTO.v1.v1.Excercise excercise)
        {
            var bllExcercise = _mapper.Map(excercise);
            

            _bll.ExcerciseService.Add(bllExcercise!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetExcercise", new { id = excercise.Id }, excercise);
        }

        // DELETE: api/Excercise/5
        /// <summary>
        /// Delete exercise with selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcercise(Guid id)
        {
            var excercise = await _bll.ExcerciseService.RemoveAsync(id, User.GetUserId());

            if (excercise == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
