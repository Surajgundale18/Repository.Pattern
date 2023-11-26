﻿using HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs;
using HomeMgmtAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmtAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService addressService;
        public AddressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        //fdbdfjd
        [HttpGet] //Get/api/Addresses?filteron=city?filterquery=pune
        public async Task<IActionResult> GetAddressAsync()
        {
            var address = await addressService.GetAddressAsync();
            return Ok(address);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] int id)
        {
            var address = await addressService.GetAddressByIdAsync(id);
            return Ok(address);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateAddressAsync([FromBody] CreateAddresssRequestDTO createAddresssRequest)
        {
            var address = await addressService.CreateAddressAsync(createAddresssRequest);
            return Ok(address);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddressAsync([FromRoute] int id, [FromBody] UpdateAddressRequestDTO updateAddressRequestDTO)
        {

            var address = await addressService.UpdateAddressAsync(id, updateAddressRequestDTO);
            return Ok(address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] int id)
        {
            var address = await addressService.DeleteAddressAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }
    }
}
