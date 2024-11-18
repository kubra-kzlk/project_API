﻿using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LampsController : Controller
    {

        private readonly ILampData _lampService;
        private readonly IManufacturerData _manufacturerService;
        private readonly IStyleData _styleService;

        // Constructor to inject services
        //Inject the services via Dependency Injection (DI) instead of creating new instances directly inside the controllers.
        public LampsController(ILampData lampService, IManufacturerData manufacturerService, IStyleData styleService)
        { //Inject the interfaces (ILampData, IManufacturerData, IStyleData) in the controller constructor.
            _lampService = lampService;
            _manufacturerService = manufacturerService;
            _styleService = styleService;
        }
        //Change method signatures to use async and await for asynchronous operations, based on your service methods that return Task<T>
        [HttpGet]
        public async Task<ActionResult<List<Lamp>>> GetAll()
        {
            var lamps = await _lampService.GetAllAsync();
            return Ok(lamps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var lamp = await _lampService.GetByIdAsync(id);
            if (lamp == null) return NotFound();

            var fabrikant = await _manufacturerService.GetByIdAsync(lamp.FabrikantId);
            var stijlen = (await _styleService.GetAllAsync()).Where(s => lamp.StijlIds.Contains(s.Id)).ToList();

            return new
            {
                Lamp = lamp,
                Fabrikant = fabrikant,
                Stijlen = stijlen
            };
        }
    }

}
