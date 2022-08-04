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
		List<OrderMain> unpaidOrders = new List<OrderMain>();
		List<OrderMain> orderList = new List<OrderMain>();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Index(IFormCollection values)
        {
			Decimal total = Decimal.Parse(values["total"][0].Substring(1));
			int orderNumber = int.Parse(values["orderNumber"][0]);
			string payMethod = values["payMethod"][0];
			Payment payment = new Payment();

			foreach(OrderMain order in _context.OrderMains)
            {
				if(order.OrderNumber == orderNumber)
                {
					payment.OrderId = order.OrderId;
					order.OrderStatus = "Paid";

					_context.OrderMains.Update(order);
				}
            }

			payment.OrderNumber = orderNumber;
			payment.Method = payMethod;
			payment.Amount = total;
			payment.LocationId = 1;
			payment.PaymentTimeStamp = DateTime.Now;
			
			_context.Payments.Add(payment);
			_context.SaveChanges();

			ViewData["MenuItems"] = MenuItems;
			ViewData["Orders"] = unpaidOrders;
			ViewData["OrderList"] = new SelectList(orderList, "OrderNumber", "OrderNumber");

			return View();
        }
	}
}