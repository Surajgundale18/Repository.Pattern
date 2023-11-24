using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly IRoomServices roomServices;
        public RoomsController(IRoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms= await roomServices.GetAllRoomsAsync();     
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById([FromRoute]int id )
        {
            var room = await roomServices.GetRoomByIdAsync(id);
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync([FromBody] CreateRoomRequestDTO createRoomRequestDTO)
        {
            var room = await roomServices.CreateRoomAsync(createRoomRequestDTO);
            return Ok (room);
           
            
        }

        [HttpPut("{id}")]

        public  async Task<IActionResult> UpdateRoomAsync([FromRoute]int id, [FromBody] UpdateRoomRequestDTO updateRoomRequestDTO)
        {
           
            var newRoom = await roomServices.UpdateRoomAsync(id, updateRoomRequestDTO);
            return Ok(newRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAsync([FromRoute] int id)
        {
            var deleteRoom = await roomServices.DeletRoomAsync(id);
            if (deleteRoom == null)
            {
                return NotFound();
            }
            return Ok(deleteRoom);
        }
    }
}
