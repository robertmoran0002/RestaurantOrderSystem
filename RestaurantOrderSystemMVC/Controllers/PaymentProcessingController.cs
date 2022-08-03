using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderSystemMVC.Controllers
{
	public class PaymentProcessingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
