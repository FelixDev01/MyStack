using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStack.Api.Data;
using MyStack.Api.DTOs;
using MyStack.Api.Models;

namespace MyStack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HardwareController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HardwareController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardwareResponseDTO>>> GetItems()
        {
            var items = await _context.HardwareItems
                .Where(x => x.IsActive)
                .Select(item => new HardwareResponseDTO(
                    item.Id,
                    item.Name,
                    item.Brand,
                    item.Price,
                    item.CreatedAt,
                    item.LastUpdatedAt
            ))
             .ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<HardwareItem>> CreateItem(CreateHardwareItem dto)
        {
            var newItem = new HardwareItem
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Brand = dto.Brand,
                Price = dto.Price,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            _context.HardwareItems.Add(newItem);
            await _context.SaveChangesAsync();

            var response = new HardwareResponseDTO(
                newItem.Id,
                newItem.Name,
                newItem.Brand,
                newItem.Price,
                newItem.CreatedAt,
                newItem.LastUpdatedAt 
            );

            return CreatedAtAction(nameof(GetItemById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HardwareItem>> GetItemById(Guid id)
        {
            var item = await _context.HardwareItems
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            if (item == null)
            {
                return NotFound();
            }
            var response = new HardwareResponseDTO(
                item.Id,
                item.Name,
                item.Brand,
                item.Price,
                item.CreatedAt,
                item.LastUpdatedAt
            );

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.HardwareItems.FindAsync(id);
            if (item == null) return NotFound();

            item.IsActive = false;
            item.LastUpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
