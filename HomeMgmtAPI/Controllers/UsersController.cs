using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await userService.GetAllUser();

            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var userDetails = await userService.GetUserByIdAsync(id);

            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRequestDTO userRequestDTO)
        {
            try
            {
                var newuser = await userService.CreateUserAsync(userRequestDTO);
                return Ok(newuser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserRequsetDTO updateUserRequsetDTO)
        {
            if (id != updateUserRequsetDTO?.Id)
            {
                return BadRequest("IDs do not match");
            }

            var updatedUser = await userService.UpdateUserAsync(id, updateUserRequsetDTO);

            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUserAysnc([FromRoute] int id)
        {
            var deletedUser = await userService.DeleteUserAsync(id);

            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticateRequestDTO authenticateRequestDTO)
        {
            try
            {
                var authenticateResponse = await userService.AuthenticateAsync(authenticateRequestDTO);
                return Ok(authenticateResponse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
