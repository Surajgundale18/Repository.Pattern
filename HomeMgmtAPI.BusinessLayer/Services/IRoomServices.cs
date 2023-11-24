using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public interface IRoomServices
    {
        Task<RoomResponseDTO> CreateRoomAsync(CreateRoomRequestDTO createRoomRequestDTO);
        Task<RoomResponseDTO> DeletRoomAsync(int id);
        Task<List<RoomResponseDTO>> GetAllRoomsAsync();
        Task<RoomResponseDTO> GetRoomByIdAsync(int id);
        Task<RoomResponseDTO> UpdateRoomAsync(int id, UpdateRoomRequestDTO updateRoomRequestDTO);
    }
}
