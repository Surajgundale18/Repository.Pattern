﻿using HomeMgmtAPI.DataLayer.DataEntities;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> DeleteAddressAsync(int id);
        Task<List<Address>> GetAddressAsync(string? filetron = null, string? filterquery = null);
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> UpdateAddressAsync(int id, Address address);
    }
}
