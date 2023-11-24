using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public interface IAddressService
    {
        Task<AddressResponseDTO> CreateAddressAsync(CreateAddresssRequestDTO createAddresssRequest);
        Task<AddressResponseDTO> DeleteAddressAsync(int id);
        Task<List<AddressResponseDTO>> GetAddressAsync();
        Task<AddressResponseDTO> GetAddressByIdAsync(int id);
        Task<AddressResponseDTO> UpdateAddressAsync(int id, UpdateAddressRequestDTO updateAddressRequestDTO);
    }
}
