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
        private readonly Dictionary<int, Menu> MenuItems = new Dictionary<int, Menu>();

    public AddToOrderController(ApplicationDbContext context)
        {
            _context = context;
            IEnumerable<Menu> MenuData = _context.Menus.ToList() as IEnumerable<Menu>;
            foreach (Menu item in MenuData)
            {
                MenuItems[item.ItemId] = item;
            }
        }

        public IActionResult Ordering()
        {
            ViewData["MenuItem"] = MenuItems;
            ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ordering(IFormCollection values)
        {
            Dictionary<int, int> orderDict = new Dictionary<int, int>();
            Decimal total = Decimal.Parse(values["total"][0]);
            var orderedItems = values["OrderedItems"];
            foreach (var item in orderedItems) 
            {
                int temp = int.Parse(item);
                if (orderDict.ContainsKey(temp)) 
                {
                    orderDict[temp] += 1;
                }
                else 
                { 
                    orderDict.Add(temp,1);
                }
            }
           // OrderMain prod = _context.OrderMains.LastOrDefault<OrderMain>();
            foreach (var item in orderDict) 
            { 
                
            
            }
            //ViewData["MenuData"] = _context.Menus.ToList();
            //ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
            //return View();
            return RedirectToAction("Ordering");
        }
    }
}
