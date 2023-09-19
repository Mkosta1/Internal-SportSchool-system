using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Contracts.Base;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.EF.APP;
using Domain;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.v1.Mappers;

namespace SportSchool.Api
{
    /// <summary>
    /// User at training controller for api
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserAtTrainingController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly UserAtTrainingMapper _mapper;

        /// <summary>
        /// User at training constructor
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public UserAtTrainingController(IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new UserAtTrainingMapper(autoMapper);
            
        }

        // GET: api/UserAtTraining
        /// <summary>
        /// Get table content from user at training
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.UserAtTraining>>> GetUserAtTraining()
        {
            var data = await 
                _bll.UserAtTrainingService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/UserAtTraining/5
        /// <summary>
        /// GET request from db with it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.UserAtTraining>> GetUserAtTraining(Guid id)
        {
            var userAtTraining = await _bll.UserAtTrainingService.FindAsync(id, User.GetUserId());

            if (userAtTraining == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(userAtTraining);

            return res!;
        }

        // PUT: api/UserAtTraining/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add to table with id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userAtTraining"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAtTraining(Guid id, Public.DTO.v1.v1.UserAtTraining userAtTraining)
        {
            if (id != userAtTraining.Id)
            {
                return BadRequest();
            }
            


            var bllUserAtTraining = _mapper.Map(userAtTraining);
           

            _bll.UserAtTrainingService.Update(bllUserAtTraining!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/UserAtTraining
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request from table 
        /// </summary>
        /// <param name="userAtTraining"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserAtTraining>> PostUserAtTraining(Public.DTO.v1.v1.UserAtTraining userAtTraining)
        {
            var bllUserAtTraining = _mapper.Map(userAtTraining);
            

            _bll.UserAtTrainingService.Add(bllUserAtTraining!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetUserAtTraining", new { id = userAtTraining.Id }, userAtTraining);
        }

        // DELETE: api/UserAtTraining/5
        /// <summary>
        /// Delete from table with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAtTraining(Guid id)
        {
            var userAtTraining = await _bll.UserAtTrainingService.RemoveAsync(id, User.GetUserId());

            if (userAtTraining == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }

        
    }
}
