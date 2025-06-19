using Microsoft.AspNetCore.Mvc;
using MDispenser.Application.Abstractions;
using MDispenser.Application.DTOs;

namespace MDispenser.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispenserController : ControllerBase
    {
        private readonly IDispenserService _dispenserService;

        public DispenserController(IDispenserService dispenserService)
        {
            _dispenserService = dispenserService;
        }

        // GET: api/dispenser/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DispenserDto>> GetDispenser(Guid id)
        {
            var dispenser = await _dispenserService.GetByIdAsync(id);
            if (dispenser == null)
                return NotFound();

            return Ok(dispenser);
        }

        // POST: api/dispenser/{id}/dispense
        [HttpPost("{id:guid}/dispense")]
        public async Task<IActionResult> Dispense(Guid id)
        {
            var result = await _dispenserService.DispenseFoodAsync(id);
            if (!result)
                return NotFound();

            return Ok(new { Message = "Food dispensed!" });
        }
    }
}
