using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderSystemMVC.Controllers
{
	public class KitchenProcessingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
