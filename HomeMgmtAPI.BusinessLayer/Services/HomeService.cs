using AutoMapper;
using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Exceptions;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using HomeMgmtAPI.DataLayer.DataEntities;
using HomeMgmtAPI.DataLayer.Repositories;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository homeRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateHomeRequestDTO> createHomeValidator;
        private readonly IValidator<UpdateHomeRequestDTO> updateHomeValidator;
       
        public HomeService(IHomeRepository homeRepository,
            IMapper mapper,
            IValidator<CreateHomeRequestDTO> createHomeValidator, IValidator<UpdateHomeRequestDTO> updateHomeValidator)
        {
            this.homeRepository = homeRepository;
            this.mapper = mapper;
            this.createHomeValidator = createHomeValidator;
            this.updateHomeValidator = updateHomeValidator;
        }

        public async Task<List<HomeResponseDTO>> GetAllHomesAsync()
        {
            var homes = await homeRepository.GetAllHomesAsync();

            return mapper.Map<List<HomeResponseDTO>>(homes);
        }

        public async Task<HomeResponseDTO> GetHomesByIdAsync(int id)
        {
            var home = await homeRepository.GetHomesByIdAsync(id);
            if (home == null)
            {
                throw new ResourceNotFoundException("Home not found..");
            }
            return mapper.Map<HomeResponseDTO>(home);
        }

        public async Task<HomeResponseDTO> CreateHomeAsync(CreateHomeRequestDTO createHomeRequestDTO)
        {
            var validationResult = await createHomeValidator.ValidateAsync(createHomeRequestDTO);

            if (!validationResult.IsValid)
            {
                throw new BusinessRuleException(validationResult.Errors);
            }

            var request = mapper.Map<Home>(createHomeRequestDTO);

            var home = await homeRepository.CreateHomeAsync(request);

            return mapper.Map<HomeResponseDTO>(home);
        }

        public async Task<HomeResponseDTO> UpdateHomeAsync(int id, UpdateHomeRequestDTO updateHomeRequestDTO)
        {
            var validationResult = await updateHomeValidator.ValidateAsync(updateHomeRequestDTO);

            if (!validationResult.IsValid)
            {
                throw new BusinessRuleException(validationResult.Errors);
            }
            var existingHome = await GetHomesByIdAsync(id);
            if (existingHome == null)
            {
                throw new ResourceNotFoundException("Home not found");
            }
            var request = mapper.Map<Home>(updateHomeRequestDTO);
            var home = await homeRepository.UpdateHomeAsync(id, request);
           
            return mapper.Map<HomeResponseDTO>(home);
        }

        public async Task<HomeResponseDTO> DeleteHomeAsync(int id)
        {
            var existingHome = await GetHomesByIdAsync(id);
            if (existingHome == null)
            {
                throw new ResourceNotFoundException("Home not found");
            }
            var home = await homeRepository.DeleteHomeAsync(id);
            return (mapper.Map<HomeResponseDTO>(home));
        }

    }
}
