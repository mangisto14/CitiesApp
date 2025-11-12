using Microsoft.AspNetCore.Mvc;
using CitiesApp.Api.Models;
using CitiesApp.Api.Services;

namespace CitiesApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _service;

        public CitiesController(ICityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            await _service.AddAsync(city);
            return CreatedAtAction(nameof(Get), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, City city)
        {
            if (id != city.Id) return BadRequest("ID mismatch");
            await _service.UpdateAsync(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
