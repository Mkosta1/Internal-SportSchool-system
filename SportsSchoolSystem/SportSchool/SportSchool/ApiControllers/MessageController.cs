using AutoMapper;
using BLL.Contracts.Base;
using DAL.Contracts.App;
using DAL.EF.APP;
using Domain;
using Domain.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Public.DTO.v1.Mappers;

namespace SportSchool.ApiControllers
{
    /// <summary>
    /// Message controler for message API
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MessageController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly MessageMapper _mapper;

        /// <summary>
        /// Message controller constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public MessageController(ApplicationDbContext context, IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new MessageMapper(autoMapper);
        }

        // GET: api/Message
        /// <summary>
        /// Get messages from db 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Public.DTO.v1.v1.Message>>> GetMessage()
        {
            var data = await 
                _bll.MessageService.AllAsync(User.GetUserId());

            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();

            return res!;
        }

        // GET: api/Message/5
        /// <summary>
        /// GET request from database with id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Public.DTO.v1.v1.Message>> GetMessage(Guid id)
        {
            var message = await _bll.MessageService.FindAsync(id, User.GetUserId());

            if (message == null)
            {
                return NotFound();
            }
            
            var res = _mapper.Map(message);

            return res!;
        }

        // PUT: api/Message/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Get Message with user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(Guid id, Public.DTO.v1.v1.Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }
            

            var bllMessage = _mapper.Map(message);
            

            _bll.MessageService.Update(bllMessage!);

            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Message
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// POST request for message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Public.DTO.v1.v1.Message message)
        {
            var bllMessage = _mapper.Map(message);
            

            _bll.MessageService.Add(bllMessage!);

            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Message/5
        /// <summary>
        /// Delete message with selected id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            var message = await _bll.MessageService.RemoveAsync(id, User.GetUserId());

            if (message == null) return NotFound();


            await _bll.SaveChangesAsync();


            return NoContent();
        }
        
    }
}
