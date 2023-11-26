using AutoMapper;
using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Exceptions;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using HomeMgmtAPI.DataLayer.DataEntities;
using HomeMgmtAPI.DataLayer.Repositories;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateAddresssRequestDTO> createAddressValidator;
        private readonly IValidator<UpdateAddressRequestDTO> updateAddressValidator;

        public AddressService(IAddressRepository addressRepository, IMapper mapper, 
            IValidator<UpdateAddressRequestDTO> updateAddressValidator, IValidator<CreateAddresssRequestDTO> createAddressValidator)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
            this.updateAddressValidator = updateAddressValidator;
            this.createAddressValidator = createAddressValidator;
        }

        public async Task<List<AddressResponseDTO>> GetAddressAsync(string? filetron = null, string? filterquery = null)
        {
            var address = await addressRepository.GetAddressAsync(filetron,filterquery);
            
            return (mapper.Map<List<AddressResponseDTO>>(address));
        }

        public async Task<AddressResponseDTO> GetAddressByIdAsync(int id)
        {
            var address = await addressRepository.GetAddressByIdAsync(id);
            if(address == null)
            {
                throw new ResourceNotFoundException("Address not found.");
            }
            return (mapper.Map<AddressResponseDTO>(address));
        }

        public async Task<AddressResponseDTO> CreateAddressAsync(CreateAddresssRequestDTO createAddresssRequest)
        {
            var validatorResult= await createAddressValidator.ValidateAsync(createAddresssRequest);

            if (!validatorResult.IsValid)
            {
                throw new BusinessRuleException(validatorResult.Errors);
            }
            
            var address = mapper.Map<Address>(createAddresssRequest);
            var createdaddress = await addressRepository.CreateAddressAsync(address);
            return (mapper.Map<AddressResponseDTO>(createdaddress));
        }

        public async Task<AddressResponseDTO> UpdateAddressAsync(int id, UpdateAddressRequestDTO updateAddressRequestDTO)
        {
            var validatorResult = await updateAddressValidator.ValidateAsync(updateAddressRequestDTO);

            if (!validatorResult.IsValid)
            {
                throw new BusinessRuleException(validatorResult.Errors);
            }

            var existingAddress = await GetAddressByIdAsync(id);
            if (existingAddress == null)
            {
                throw new ResourceNotFoundException("Address is not found");
            }
            var address = mapper.Map<Address>(updateAddressRequestDTO);
            var updatedAddress = await addressRepository.UpdateAddressAsync(id, address);
            return (mapper.Map<AddressResponseDTO>(updatedAddress));
        }

        public async Task<AddressResponseDTO> DeleteAddressAsync(int id)
        {
            var existingAddress= await GetAddressByIdAsync(id);
            if (existingAddress == null)
            {
                throw new ResourceNotFoundException("Address not found");
            }
            var address = await addressRepository.DeleteAddressAsync(id);
            return (mapper.Map<AddressResponseDTO>(address));
        }

    }
}
