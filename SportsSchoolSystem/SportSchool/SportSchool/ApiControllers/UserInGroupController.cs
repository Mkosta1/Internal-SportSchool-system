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
    /// User in group api controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserInGroupController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly UserInGroupMapper _mapper;

        /// <summary>
        /// User in group controller constructor
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public UserInGroupController(IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new UserInGroupMapper(autoMapper);;
        }

        // GET: api/UserInGroup
        /// <summary>
        /// GET request from user in group table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.UserInGroup>>> GetUserInGroup()
        {
            var data = await 
                _bll.UserInGroupService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/UserInGroup/5
        /// <summary>
        /// GET request with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.UserInGroup>> GetUserInGroup(Guid id)
        {
            var userInGroup = await _bll.UserInGroupService.FindAsync(id, User.GetUserId());

            if (userInGroup == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(userInGroup);

            return res!;
        }

        // PUT: api/UserInGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add to table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userInGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInGroup(Guid id, Public.DTO.v1.v1.UserInGroup userInGroup)
        {
            if (id != userInGroup.Id)
            {
                return BadRequest();
            }


            var bllUserInGroup = _mapper.Map(userInGroup);
            

            _bll.UserInGroupService.Update(bllUserInGroup!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/UserInGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request from table
        /// </summary>
        /// <param name="userInGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserInGroup>> PostUserInGroup(Public.DTO.v1.v1.UserInGroup userInGroup)
        {
            var bllUserInGroup = _mapper.Map(userInGroup);
            

            _bll.UserInGroupService.Add(bllUserInGroup!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetUserInGroup", new { id = userInGroup.Id }, userInGroup);
        }

        // DELETE: api/UserInGroup/5
        /// <summary>
        /// Delete from table with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInGroup(Guid id)
        {
            var userInGroup = await _bll.UserInGroupService.RemoveAsync(id, User.GetUserId());

            if (userInGroup == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
