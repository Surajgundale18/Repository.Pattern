using AutoMapper;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using HomeMgmtAPI.DataLayer.DataEntities;

namespace HomeMgmtAPI.BusinessLayer.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Homes
            CreateMap<Home, HomeResponseDTO>().ReverseMap();
            CreateMap<CreateHomeRequestDTO,Home >().ReverseMap();
            CreateMap<UpdateHomeRequestDTO,Home >().ReverseMap();

            // Addresses
            CreateMap<Address, AddressResponseDTO>().ReverseMap();
            CreateMap<CreateAddresssRequestDTO,Address>().ReverseMap();
            CreateMap<UpdateAddressRequestDTO,Address>().ReverseMap();


            //Rooms
            CreateMap<Room, RoomResponseDTO>();
            CreateMap<CreateRoomRequestDTO,Room>().ReverseMap();
            CreateMap<UpdateRoomRequestDTO,Room>().ReverseMap();

            //Users
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<UserRequestDTO,User>().ReverseMap();
            CreateMap<UpdateUserRequsetDTO,User>().ReverseMap();
        }
    }
}
