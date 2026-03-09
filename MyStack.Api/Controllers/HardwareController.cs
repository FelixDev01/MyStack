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
        public async Task<ActionResult<IEnumerable<HardwareItem>>> GetItems()
        {
            return await _context.HardwareItems.ToListAsync();
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
            };
            _context.HardwareItems.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        } 
    }
}
