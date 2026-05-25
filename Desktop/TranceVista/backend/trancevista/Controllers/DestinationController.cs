using Microsoft.AspNetCore.Mvc;
using TranceVista.Interfaces;
using TranceVista.Models;
using TranceVista.DTOs;

namespace TranceVista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _repository;

        public DestinationController(IDestinationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/destination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        {
            var destinations = await _repository.GetAllAsync();

            return Ok(destinations);
        }

        // GET: api/destination/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _repository.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination);
        }

        // SEARCH: api/destination/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Destination>>> SearchDestinations(
            [FromQuery] string? city,
            [FromQuery] string? country,
            [FromQuery] decimal? maxBudget)
        {
            var results = await _repository.SearchAsync(city, country, maxBudget);

            return Ok(results);
        }

        // POST: api/destination
        [HttpPost]
        public async Task<ActionResult<Destination>> CreateDestination(CreateDestinationDto dto)
        {
            var destination = new Destination
            {
                Name = dto.Name,
                Country = dto.Country,
                City = dto.City,
                EstimatedBudget = dto.EstimatedBudget,
                Description = dto.Description
            };

            var createdDestination = await _repository.AddAsync(destination);

            return CreatedAtAction(nameof(GetDestination),
                new { id = createdDestination.Id },
                createdDestination);
        }

        // PUT: api/destination/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDestination(int id, UpdateDestinationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var existingDestination = await _repository.GetByIdAsync(id);

            if (existingDestination == null)
            {
                return NotFound();
            }

            existingDestination.Name = dto.Name;
            existingDestination.Country = dto.Country;
            existingDestination.City = dto.City;
            existingDestination.EstimatedBudget = dto.EstimatedBudget;
            existingDestination.Description = dto.Description;

            await _repository.UpdateAsync(existingDestination);

            return NoContent();
        }

        // DELETE: api/destination/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}