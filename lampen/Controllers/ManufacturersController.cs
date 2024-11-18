﻿using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerData _manufacturerService;

        // Constructor to inject service
        public ManufacturersController(IManufacturerData manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manufacturer>>> GetAll()
        {
            var manufacturers = await _manufacturerService.GetAllAsync();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetById(int id)
        {
            var manufacturer = await _manufacturerService.GetByIdAsync(id);
            if (manufacturer == null) return NotFound();
            return manufacturer;
        }
    }
}
