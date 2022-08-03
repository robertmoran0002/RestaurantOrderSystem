using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystemMVC.Data;

namespace RestaurantOrderSystemMVC.Controllers
{
    public class OrderMainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderMainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderMains
        public async Task<IActionResult> Index()
        {
              return _context.OrderMains != null ? 
                          View(await _context.OrderMains.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OrderMains'  is null.");
        }

        // GET: OrderMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderMains == null)
            {
                return NotFound();
            }

            var orderMain = await _context.OrderMains
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderMain == null)
            {
                return NotFound();
            }

            return View(orderMain);
        }

        // GET: OrderMains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderMains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ItemId,Quantity,DateTimePlaced,DateTimeComplete,OrderNumber,OrderStatus")] OrderMain orderMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderMain);
        }

        // GET: OrderMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderMains == null)
            {
                return NotFound();
            }

            var orderMain = await _context.OrderMains.FindAsync(id);
            if (orderMain == null)
            {
                return NotFound();
            }
            return View(orderMain);
        }

        // POST: OrderMains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ItemId,Quantity,DateTimePlaced,DateTimeComplete,OrderNumber,OrderStatus")] OrderMain orderMain)
        {
            if (id != orderMain.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderMainExists(orderMain.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderMain);
        }

        // GET: OrderMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderMains == null)
            {
                return NotFound();
            }

            var orderMain = await _context.OrderMains
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderMain == null)
            {
                return NotFound();
            }

            return View(orderMain);
        }

        // POST: OrderMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderMains == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderMains'  is null.");
            }
            var orderMain = await _context.OrderMains.FindAsync(id);
            if (orderMain != null)
            {
                _context.OrderMains.Remove(orderMain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderMainExists(int id)
        {
          return (_context.OrderMains?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
