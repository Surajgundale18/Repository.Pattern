using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public interface IHomeService
    {
        Task<List<HomeResponseDTO>> GetAllHomesAsync();
        Task<HomeResponseDTO> GetHomesByIdAsync(int id);
        Task<HomeResponseDTO> CreateHomeAsync(CreateHomeRequestDTO createHomeRequestDTO);
        Task<HomeResponseDTO> UpdateHomeAsync(int id, UpdateHomeRequestDTO updateHomeRequestDTO);
        Task<HomeResponseDTO> DeleteHomeAsync(int id);
    }
}