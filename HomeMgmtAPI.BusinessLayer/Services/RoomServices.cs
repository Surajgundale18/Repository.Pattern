using AutoMapper;
using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Exceptions;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using HomeMgmtAPI.BusinessLayer.Validators;
using HomeMgmtAPI.DataLayer.DataEntities;
using HomeMgmtAPI.DataLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateRoomRequestDTO> createRoomValidator;
        private readonly IValidator<UpdateRoomRequestDTO> updateRoomValidator;

        public RoomServices(IRoomRepository roomRepository,
            IMapper mapper, IValidator<CreateRoomRequestDTO> createRoomValidator, IValidator<UpdateRoomRequestDTO> updateRoomValidator)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;   
            this.createRoomValidator = createRoomValidator;
            this.updateRoomValidator = updateRoomValidator;
        }

        public async Task<List<RoomResponseDTO>> GetAllRoomsAsync()
        {
            var rooms = await roomRepository.GetAllRoomsAsync();
            return(mapper.Map<List<RoomResponseDTO>>(rooms));      
        }

        public async Task<RoomResponseDTO> GetRoomByIdAsync(int id)
        {
            var room = await roomRepository.GetRoomByIdAsync(id);
            if (room == null)
            {
                throw new ResourceNotFoundException("Room not found..");
            }
            return (mapper.Map<RoomResponseDTO>(room));
        }

        public async Task<RoomResponseDTO> CreateRoomAsync(CreateRoomRequestDTO createRoomRequestDTO)
        {
            var validatorResult = await createRoomValidator.ValidateAsync(createRoomRequestDTO);
            if(!validatorResult.IsValid) 
            {
               throw new BusinessRuleException(validationFailures: validatorResult.Errors);
            }
            var room = mapper.Map<Room>(createRoomRequestDTO);
            var createdRoom = await roomRepository.CreateRoomAsync(room);
            
            return (mapper.Map<RoomResponseDTO>(createdRoom));
        }

        public async Task<RoomResponseDTO> UpdateRoomAsync(int id, UpdateRoomRequestDTO updateRoomRequestDTO)
        {
            var validationResult = await updateRoomValidator.ValidateAsync(updateRoomRequestDTO);
            if (!validationResult.IsValid)
            {
                throw new BusinessRuleException(validationResult.Errors);
            }
            var existingRoom = await GetRoomByIdAsync(id);
            if (existingRoom == null)
            {
                throw new ResourceNotFoundException("Room not found");
            }
            var updatedRoom = mapper.Map<Room>(updateRoomRequestDTO);
            var updateRoom = await roomRepository.UpdateRoomAsync(id, updatedRoom);
           
            return (mapper.Map<RoomResponseDTO>(updateRoom));
        }

        public async Task<RoomResponseDTO> DeletRoomAsync(int id)
        {
            var existingRoom = await GetRoomByIdAsync(id);
            if(existingRoom == null)
            {
                throw new ResourceNotFoundException("room not found");
            }
            var room = await roomRepository.DeletRoomAsync(id);   
            return (mapper.Map<RoomResponseDTO>(room));
        }
    }
}
