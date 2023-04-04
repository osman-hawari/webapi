using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _context.Customers.FirstOrDefaultAsync(c => c.Id == id));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Customers.ToListAsync());
        }
    }
}
