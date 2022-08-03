using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystemMVC.Data;

namespace RestaurantOrderSystemMVC.Controllers
{
	public class KitchenProcessingController : Controller
	{
        private readonly ApplicationDbContext _context;
        public KitchenProcessingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OrderProcess()
        {
            ViewData["MenuData"] = _context.Menus.ToList();
            ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
            ViewData["OrderData"] = _context.OrderMains.ToList();
            ViewData["OrderList"] = new SelectList(_context.OrderMains, "ItemId", "Quantity", "DateTimePlaced", "OrderNumber");
            ViewData["blah"] = new MultiSelectList(_context.OrderMains, "ItemId", "Quantity", "DateTimePlaced", "OrderNumber");
            ViewData["test"] = ViewData["OrderList"];
            //ViewData["OrderList"] = new List<OrderMain>(_context.OrderMains);
            return View();
        }
  //      public IActionResult Index()
		//{
		//	return View();
		//}
	}
}


