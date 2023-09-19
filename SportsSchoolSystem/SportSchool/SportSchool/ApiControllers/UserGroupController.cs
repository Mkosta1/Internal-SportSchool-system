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
    /// User group controller for api
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserGroupController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly UserGroupMapper _mapper;

        /// <summary>
        /// User group controller constructor
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public UserGroupController(IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new UserGroupMapper(autoMapper);
        }

        // GET: api/UserGroup
        /// <summary>
        /// GET request for user group
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.UserGroup>>> GetUserGroup()
        {
            var data = await 
                _bll.UserGroupService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/UserGroup/5
        /// <summary>
        /// GET request with id for user group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.UserGroup>> GetUserGroup(Guid id)
        {
            var userGroup = await _bll.UserGroupService.FindAsync(id, User.GetUserId());

            if (userGroup == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(userGroup);

            return res!;
        }

        // PUT: api/UserGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add line to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup(Guid id, Public.DTO.v1.v1.UserGroup userGroup)
        {
            if (id != userGroup.Id)
            {
                return BadRequest();
            }
            


            var bllUserGroup = _mapper.Map(userGroup);
            

            _bll.UserGroupService.Update(bllUserGroup!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/UserGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request for user group table
        /// </summary>
        /// <param name="userGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(Public.DTO.v1.v1.UserGroup userGroup)
        {
            var bllUserGroup = _mapper.Map(userGroup);
            

            _bll.UserGroupService.Add(bllUserGroup!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetUserGroup", new { id = userGroup.Id }, userGroup);
        }

        // DELETE: api/UserGroup/5
        /// <summary>
        /// Delete from table user group with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup(Guid id)
        {
            var userGroup = await _bll.UserGroupService.RemoveAsync(id, User.GetUserId());

            if (userGroup == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
