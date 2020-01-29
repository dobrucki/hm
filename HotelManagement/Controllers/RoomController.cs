using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> Get()
        {
            return Ok(await _unitOfWork.Room.GetAllRoomsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Room>> Get(Guid id)
        {
            var room = await _unitOfWork.Room.GetRoomByIdAsync(id);
            if (room is null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Room room)
        {
            if (room is null)
            {
                return BadRequest("Room object is null");
            }
            _unitOfWork.Room.CreateRoom(room);
            await _unitOfWork.SaveAsync();
            
            var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(room.Id.ToString()));
            return Created(resourceUrl, room);
        }
    }
}