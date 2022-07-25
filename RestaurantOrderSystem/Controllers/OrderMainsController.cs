using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Data;
using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMainsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderMains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMain>>> GetOrderMains()
        {
          if (_context.OrderMains == null)
          {
              return NotFound();
          }
            return await _context.OrderMains.ToListAsync();
        }

        // GET: api/OrderMains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMain>> GetOrderMain(int id)
        {
          if (_context.OrderMains == null)
          {
              return NotFound();
          }
            var orderMain = await _context.OrderMains.FindAsync(id);

            if (orderMain == null)
            {
                return NotFound();
            }

            return orderMain;
        }

        // PUT: api/OrderMains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMain(int id, OrderMain orderMain)
        {
            if (id != orderMain.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderMain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMainExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderMains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderMain>> PostOrderMain(OrderMain orderMain)
        {
          if (_context.OrderMains == null)
          {
              return Problem("Entity set 'ApplicationDbContext.OrderMains'  is null.");
          }
            _context.OrderMains.Add(orderMain);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMain", new { id = orderMain.OrderId }, orderMain);
        }

        // DELETE: api/OrderMains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMain(int id)
        {
            if (_context.OrderMains == null)
            {
                return NotFound();
            }
            var orderMain = await _context.OrderMains.FindAsync(id);
            if (orderMain == null)
            {
                return NotFound();
            }

            _context.OrderMains.Remove(orderMain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderMainExists(int id)
        {
            return (_context.OrderMains?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
