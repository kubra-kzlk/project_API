﻿using lampen.Models;

namespace lampen.Services
{
    public interface IManufacturerData
    {
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer?> GetManufacturerById(int id);
        Task<Manufacturer> CreateManufacturer(Manufacturer manufacturer);
        Task UpdateManufacturer(Manufacturer manufacturer); 
        Task DeleteManufacturer(int id); 
    }
}
