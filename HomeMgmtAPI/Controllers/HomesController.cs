using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomesController : ControllerBase
    {
        private readonly IHomeService homeService;

        public HomesController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHomesAsync()
        {
            var homes = await homeService.GetAllHomesAsync();

            return Ok(homes);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomesByIdAsync([FromRoute] int id)
        {
            var HomeDetails = await homeService.GetHomesByIdAsync(id);

            return Ok(HomeDetails);
        }

        [HttpPost]

        public async Task<IActionResult> CreateHomeAsync([FromBody] CreateHomeRequestDTO createHomeRequestDTO)
        {
            try
            {
                var newHome = await homeService.CreateHomeAsync(createHomeRequestDTO);
                return Ok(newHome);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHomeAsync(int id, [FromBody] UpdateHomeRequestDTO updateHomeRequestDTO)
        {
            if (id != updateHomeRequestDTO?.HomeId)
            {
                return BadRequest("IDs do not match");
            }

            var updatedHomeRequest = await homeService.UpdateHomeAsync(id, updateHomeRequestDTO);

            if (updatedHomeRequest == null)
            {
                return NotFound();
            }
            return Ok(updatedHomeRequest);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeAysnc([FromRoute] int id)
        {
            var DeletedHome = await homeService.DeleteHomeAsync(id);

            if (DeletedHome == null)
            {
                return NotFound();
            }
            return Ok(DeletedHome);
        }

    }
}
