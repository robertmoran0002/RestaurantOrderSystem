using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystemMVC.Data;

namespace RestaurantOrderSystemMVC.Controllers
{
    public class AddToOrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AddToOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Ordering()
        {
            ViewData["MenuData"] = _context.Menus.ToList();
            ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
            return View();
        }
    }
}
