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
    /// Trainig controller for api
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TrainingController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly TrainingMapper _mapper;

        /// <summary>
        /// Training controler constructor
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public TrainingController(IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new TrainingMapper(autoMapper);
        }

        // GET: api/Training
        /// <summary>
        /// GET request for trainings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.Training>>> GetTraining()
        {
            var data = await 
                _bll.TrainingService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/Training/5
        /// <summary>
        /// GET request with selected id for trainings list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.Training>> GetTraining(Guid id)
        {
            var training = await _bll.TrainingService.FindAsync(id, User.GetUserId());

            if (training == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(training);

            return res!;
        }

        // PUT: api/Training/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Put training to db with id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(Guid id, Public.DTO.v1.v1.Training training)
        {
            if (id != training.Id)
            {
                return BadRequest();
            }
            

            var bllTraining = _mapper.Map(training);
            

            _bll.TrainingService.Update(bllTraining!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Training
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request for training
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Public.DTO.v1.v1.Training training)
        {
            var bllTraining = _mapper.Map(training);
            

            _bll.TrainingService.Add(bllTraining!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetTraining", new { id = training.Id }, training);
        }

        // DELETE: api/Training/5
        /// <summary>
        /// Delete training from database with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(Guid id)
        {
            var training = await _bll.TrainingService.RemoveAsync(id, User.GetUserId());

            if (training == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }

        
    }
}
