using Microsoft.AspNetCore.Mvc;
using MDispenser.Application.Abstractions;
using MDispenser.Application.DTOs;

namespace MDispenser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService dispenserService)
        {
            _deviceService = dispenserService;
        }

        // GET: api/dispenser/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeviceDto>> GetDevice(int id)
        {
            var dispenser = await _deviceService.GetByIdAsync(id);
            if (dispenser == null)
                return NotFound();

            return Ok(dispenser);
        }

        // POST: api/dispenser/{id}/dispense
        [HttpPost("{id:int}/dispense")]
        public async Task<IActionResult> Dispense(int id)
        {
            var result = await _deviceService.DispenseFoodAsync(id);
            if (!result)
                return NotFound();

            return Ok(new { Message = "Food dispensed!" });
        }

        // PUT: api/dispenser/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDevice(int id, [FromBody] DeviceDto deviceDto)
        {
            if (id != deviceDto.DeviceId)
                return BadRequest("Device ID mismatch.");
            var existingDevice = await _deviceService.GetByIdAsync(id);
            if (existingDevice == null)
                return NotFound("Device not found.");

            var result = await _deviceService.UpdateDeviceAsync(deviceDto);
            if (!result)
                return BadRequest("Failed to update device.");

            return Ok();
        }

        // DELETE: api/dispenser/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var result = await _deviceService.DeleteDeviceAsync(id);

            return Ok();
        }

        // GET: api/device/all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            if (devices == null || !devices.Any())
                return NotFound("No devices found.");

            return Ok(devices);
        }

        //POST: api/device
        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] DeviceDto deviceDto)
        {
            if (deviceDto == null)
                return BadRequest("Device data is required.");
             var result = await _deviceService.CreateDevice(deviceDto);
            
            if (result == 0)
                return BadRequest("Failed to create device.");
            return Ok(result);
        }
    }

}