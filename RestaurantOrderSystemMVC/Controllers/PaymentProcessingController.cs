using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;
using RestaurantOrderSystemMVC.Data;

namespace RestaurantOrderSystemMVC.Controllers
{
	public class PaymentProcessingController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly Dictionary<int, Menu> MenuItems = new Dictionary<int, Menu>();
		public PaymentProcessingController(ApplicationDbContext context)
		{
			_context = context;
			IEnumerable<Menu> MenuData = _context.Menus.ToList() as IEnumerable<Menu>;
			foreach (Menu item in MenuData)
			{
				MenuItems[item.ItemId] = item;
			}
		}
		public IActionResult Index()
		{
			List<OrderMain> unpaidOrders = new List<OrderMain>();
			List<OrderMain> orderList = new List<OrderMain>();

			foreach(OrderMain order in _context.OrderMains)
            {
				if (order.OrderStatus == "Unpaid")
					unpaidOrders.Add(order);
			}

			orderList = unpaidOrders.GroupBy(x => new {x.OrderNumber}).Select(x => x.First()).ToList();

			ViewData["MenuItems"] = MenuItems;
            ViewData["Orders"] = unpaidOrders;
			ViewData["OrderList"] = new SelectList(orderList, "OrderNumber", "OrderNumber");

			return View();
		}
	}
}