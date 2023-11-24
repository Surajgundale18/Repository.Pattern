using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<UserResponseDTO> CreateUserAsync(UserRequestDTO userRequestDTO);
        Task<UserResponseDTO> DeleteUserAsync(int id);
        Task<List<UserResponseDTO>> GetAllUser();
        Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task<UserResponseDTO> UpdateUserAsync(int id, UpdateUserRequsetDTO updateUserRequsetDTO);
        Task<AuthenticateResponseDTO> AuthenticateAsync(AuthenticateRequestDTO authenticateRequestDTO);
    }
}
