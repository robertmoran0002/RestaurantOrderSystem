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
            ViewData["Success"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ordering(IFormCollection values)
        {
            Decimal total = Decimal.Parse(values["total"][0]);
            if (total > 0) 
            { 
                Dictionary<int, int> orderDict = new Dictionary<int, int>();
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
 
                OrderMain lastOrderMain = _context.OrderMains.OrderByDescending(p => p.OrderNumber).FirstOrDefault<OrderMain>();
                int newOrderNumber = lastOrderMain.OrderNumber + 1;
                foreach (var item in orderDict) 
                {
                    OrderMain newOrder = new OrderMain();
                    newOrder.OrderNumber = newOrderNumber;
                    newOrder.ItemId = item.Key;
                    newOrder.Quantity = item.Value;
                    newOrder.DateTimePlaced = DateTime.Now;
                    newOrder.OrderStatus = "Placed";
                    _context.OrderMains.Add(newOrder);
                }

                _context.SaveChanges();

                ViewData["MenuItem"] = MenuItems;
                ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
                ViewData["Success"] = true;
                return View();
            
            }
            else 
            {
                ViewData["MenuItem"] = MenuItems;
                ViewData["MenuList"] = new SelectList(_context.Menus, "ItemId", "Name");
                ViewData["Success"] = false;
                return View();
            }
        }
    }
}
