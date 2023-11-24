using AutoMapper;
using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Exceptions;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs;
using HomeMgmtAPI.DataLayer.DataEntities;
using HomeMgmtAPI.DataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeMgmtAPI.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoy userRepositoy;
        private readonly IMapper mapper;
        private readonly IValidator<UserRequestDTO> createUserRequestValidator;
        private readonly IValidator<UpdateUserRequsetDTO> updateUserRequsetValidator;
        private readonly IConfiguration configuration;

        public UserService(IUserRepositoy userRepositoy,
            IMapper mapper,
            IValidator<UserRequestDTO> createUserRequestValidator,
            IValidator<UpdateUserRequsetDTO> updateUserRequsetValidator,
            IConfiguration configuration)
        {
            this.userRepositoy = userRepositoy;
            this.mapper = mapper;
            this.createUserRequestValidator = createUserRequestValidator;
            this.updateUserRequsetValidator = updateUserRequsetValidator;
            this.configuration = configuration;
        }

        public async Task<List<UserResponseDTO>> GetAllUser()
        {
            var users = await userRepositoy.GetAllUser();
            return (mapper.Map<List<UserResponseDTO>>(users));
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            var user = await userRepositoy.GetUserByIdAsync(id);
            return (mapper.Map<UserResponseDTO>(user));
        }

        public async Task<UserResponseDTO> CreateUserAsync(UserRequestDTO userRequestDTO)
        {
            var validationResult = await createUserRequestValidator.ValidateAsync(userRequestDTO);

            if (!validationResult.IsValid)
            {
                throw new BusinessRuleException(validationResult.Errors);
            }
            var user = mapper.Map<User>(userRequestDTO);
            var createduser = await userRepositoy.CreateUserAsync(user);

            return (mapper.Map<UserResponseDTO>(createduser));
        }

        public async Task<UserResponseDTO> UpdateUserAsync(int id, UpdateUserRequsetDTO updateUserRequsetDTO)
        {
            var validationResult = await updateUserRequsetValidator.ValidateAsync(updateUserRequsetDTO);

            if (!validationResult.IsValid)
            {
                throw new BusinessRuleException(validationResult.Errors);
            }

            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
            {
                throw new ResourceNotFoundException("User not found..");
            }

            var user = mapper.Map<User>(updateUserRequsetDTO);
            var updatedUser = await userRepositoy.UpdateUserAsync(id, user);

            return (mapper.Map<UserResponseDTO>(updatedUser));
        }

        public async Task<UserResponseDTO> DeleteUserAsync(int id)
        {
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
            {
                throw new ResourceNotFoundException("User not found..");
            }

            var user = await userRepositoy.DeleteUserAsync(id);

            return (mapper.Map<UserResponseDTO>(user));
        }

        public async Task<AuthenticateResponseDTO> AuthenticateAsync(AuthenticateRequestDTO authenticateRequestDTO)
        {
            var isSuccess = await userRepositoy.AuthenticateAsync(authenticateRequestDTO.UserName, authenticateRequestDTO.Password);

            var response = new AuthenticateResponseDTO
            {
                IsAuthenticated = isSuccess,
            };

            if (isSuccess)
            {
                // Generate JWT token
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(new[]
                {
                   new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, authenticateRequestDTO.UserName),
                });

                var expires = DateTime.UtcNow.AddMinutes(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.AccessToken = tokenHandler.WriteToken(token);
            }

            return response;
        }
    }
}
