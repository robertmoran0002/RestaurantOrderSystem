using RestaurantOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantOrderSystemForms
{
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
        }

        List<MenuCategory> categories = new List<MenuCategory>();
        public static List<Menu> menu = new List<Menu>();
        public List<OrderMain> placeOrder = new List<OrderMain>();
        public List<OrderMain> orderMaster = new List<OrderMain>();
        OrderMain tempOrder = new OrderMain();
        List<OrderMain> payOrders = new List<OrderMain>();
        List<OrderMain> finalOrders = new List<OrderMain>();

        public static int currentOrderNumber;
        public static decimal total = 0;
        private int tempItemId;
        private int tempOrderId;
        private int tempLocationId;
        private decimal totalGross = 0;
        private decimal totalNet = 0;
        private const double taxPercentage = 0.029;
        private decimal taxAmount = 0;
        private decimal tipAmount = 0;


        // Pull menu from database to populate a list of available items.
        public async Task getAllMenu()
        {
            menu.Clear();

            HttpResponseMessage response;
            try
            {
                response = await MainForm.client.GetAsync("api/Menus");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var menuResponse = await response.Content.ReadFromJsonAsync<IEnumerable<Menu>>();

                foreach (var item in menuResponse)
                {
                    menu.Add(item);
                }
            }
        }

        // Use the compiled list of items to fill the screen with available items, separated by Category information.
        public void fillMenuView()
        {
            string categoryName;
            foreach(var item in menu)
            {
                foreach (var category in categories)
                {
                    if (item.CategoryId == category.CategoryId)
                    {
                        categoryName = category.CategoryName;
                        menuViewListBox.Items.Add($"Id: {item.ItemId} \t Name: {item.Name} \t Description: {item.Descrption} \t\t" +
                            $"Notes: {item.Notes} \t\t Category: {categoryName} \t Price: ${item.Price}");
                    }
                }
            }
        }

        // Pull categories from the database to compile a list of available categories.
        public async Task getAllCategories()
        {
            categories.Clear();
            HttpResponseMessage response;
            try
            {
                response = await MainForm.client.GetAsync("api/MenuCategories");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var menuCategories = await response.Content.ReadFromJsonAsync<IEnumerable<MenuCategory>>();

                foreach (var category in menuCategories)
                {
                    categories.Add(category);
                }
            }
        }


        // When refresh menu is clicked, perform these actions
        private async void menuButton_Click(object sender, EventArgs e)
        {
            menuViewListBox.Items.Clear();  // Clear current view
            await getAllCategories();       // Populate category listing
            await getAllMenu();             // Populate item listing
            fillMenuView();                 // Create new view
            menuViewListBox.Refresh();      // Redraw borders
        }

        // When Add button is clicked, perform these actions
        private void addButton_Click(object sender, EventArgs e)
        {
            if (menuViewListBox.SelectedItems.Count != 0)  // Ensure an item has been selected from the menu view
            {
                OrderMain orderItem = new OrderMain();
                string menuItem;
                string itemId = "";
                string price = "";

                menuItem = menuViewListBox.SelectedItem.ToString();  // Get selected Item name
                menuItem = menuItem.Remove(menuItem.IndexOf("Name:")).Substring(3).Trim(); // Trim ecxess characters from menu view

                // Get relevent item information
                orderItem.ItemId = Int32.Parse(menuItem);
                orderItem.Quantity = Int32.Parse(quantityBox.Text);
                orderItem.DateTimePlaced = DateTime.Now;
                orderItem.OrderStatus = "Placed";
                orderItem.OrderNumber = 0;

                // Add item to current order
                placeOrder.Add(orderItem);

                // Calculate item subtotal based on item price and quantity ordered.
                foreach (var item in menu)
                {
                    if (item.ItemId == Int32.Parse(menuItem))
                    {
                        itemId = item.ItemId.ToString();
                        price = item.Price.ToString();
                        menuItem = item.Name;
                        total += item.Price * orderItem.Quantity;
                        break;
                    }
                }

                // Display current list of ordered items and current subtotal
                totalBox.Text = total.ToString();
                orderViewListBox.Items.Add($"ID: {itemId} \t Name: {menuItem} \t Quantity: {quantityBox.Text} \t Price: ${price}");
            }
        }

        // When Remove Item button is clicked, perform these actions
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (orderViewListBox.SelectedItems.Count != 0)  // Ensure an item has been selected from the menu view
            {
                string menuItem;
                string price;
                int ID;

                // Get the item price and trim excess text
                price = orderViewListBox.SelectedItem.ToString();
                price = price.Remove(0, price.IndexOf("Price: $")).Substring(8).Trim();

                // Get item name, remove excess text, parse for item id
                menuItem = orderViewListBox.SelectedItem.ToString();
                menuItem = menuItem.Remove(menuItem.IndexOf("Name:")).Substring(3).Trim();
                ID = Int32.Parse(menuItem);

                // Adjust order subtotal and list of ordered items
                foreach (OrderMain item in placeOrder.ToList())
                {
                    if (item.ItemId == ID)
                    {
                        payOrderListBox.Items.Add(item);
                        total -= Convert.ToDecimal(price) * item.Quantity;
                        placeOrder.Remove(item);
                        ID = 0;
                    }
                }

                // Display new list of ordered items and current subtotal
                totalBox.Text = total.ToString();
                orderViewListBox.Items.Remove(orderViewListBox.SelectedItem);
            }
        }

        // Populate list of current orders.
        private async Task getAllOrders()
        {
            orderMaster.Clear(); // Clear the current list.
            HttpResponseMessage response;
            try
            {
                response = await MainForm.client.GetAsync("api/OrderMains"); // Get list of all orders
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var orders = await response.Content.ReadFromJsonAsync<IEnumerable<OrderMain>>();
                int x = 0;
                foreach (var order in orders)
                {
                    // Add relevant orders to the new list, discard ones that are no longer needed.
                    if (order.OrderNumber > x) x = order.OrderNumber;
                    orderMaster.Add(order);
                }
                currentOrderNumber = x + 1;  // Increment counter for the current order number.
            }
        }

        // When Submit Order button is clicked, perform these actions
        private async void reviewButton_Click(object sender, EventArgs e)
        {
            if (placeOrder.Count != 0)  // Ensure there is no other order to be places
                await postOrders();     // Place current order

            // Clear current order and subtotal views, reset values to defaults.
            placeOrder.Clear();
            orderViewListBox.Items.Clear();
            total = 0;
            totalBox.Text = "";
        }

        private async Task postOrders()
        {
            await getAllOrders();  // Pull currently placed orders

            Menu menu = new Menu();
            MenuCategory category = new MenuCategory();
            menu.Name = "string";
            menu.Descrption = "string";
            menu.Notes = "string";
            menu.Price = 0;
            category.CategoryName = "string";
            category.CategoryDescription = "string";

            // Check list of pending orders
            foreach (var order in placeOrder)
            {
                OrderMain newOrder = new OrderMain();

                // Get relevant information from each pending order
                newOrder.OrderStatus = order.OrderStatus;
                newOrder.DateTimePlaced = DateTime.Now;
                newOrder.OrderStatus = order.OrderStatus;
                newOrder.Quantity = order.Quantity;
                newOrder.DateTimeComplete = null;
                newOrder.OrderNumber = currentOrderNumber;
                newOrder.ItemId = order.ItemId;
                tempItemId = newOrder.ItemId;

                newOrder.Menu = menu;
                newOrder.Menu.Category = category;

                try
                {
                    // Add pending order to database
                    HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/OrderMains", newOrder);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        tempOrder = await response.Content.ReadFromJsonAsync<OrderMain>();
                    }
                    await UpdateOrder(tempOrder); // Update list of current orders.

                    // Remove placeholder information
                    await MainForm.DeleteMenu(tempOrder.Menu.ItemId);
                    await MainForm.DeleteCategory(tempOrder.Menu.Category.CategoryId);

                }
                catch (HttpRequestException error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
            }
            currentOrderNumber = 0;
            MessageBox.Show("Order submitted succesfully.");
        }

        // Add new order to database
        private async Task UpdateOrder(OrderMain orderUpdate)
        {
            orderUpdate.ItemId = tempItemId;

            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/OrderMains/{orderUpdate.OrderId}", orderUpdate);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Update Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to readjust screen layout
        private void SetPositions()
        {
            menuViewListBox.Width = (int)(this.Width * .70);
            orderViewListBox.Width = (int)(this.Width * .23);
            orderViewListBox.Left = menuViewListBox.Right + 20;
            label2.Left = menuViewListBox.Right + 20;
            quantityBox.Left = menuViewListBox.Right + 20;
            addButton.Left = quantityBox.Right + 20;
            totalBox.Left = orderViewListBox.Right - totalBox.Width;
            reviewButton.Left = orderViewListBox.Right - reviewButton.Width;
            label4.Left = totalBox.Left - label4.Width - 15;
            removeButton.Left = menuViewListBox.Right + 20;
            toPayButton.Left = menuViewListBox.Right - toPayButton.Width;
        }

        // When NewOrder element is manually resized, adjust positions of other elements
        private void NewOrder_SizeChanged(object sender, EventArgs e)
        {
            SetPositions();
        }

        // Deprecated method
        private async void button2_Click(object sender, EventArgs e)
        {
            await FillPayOrders();
            tabControl1.SelectedIndex = 1;
        }

        // Deprecated method
        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private async Task FillPayOrders()
        {
            payOrderListBox.Items.Clear();  // Clear view of orders pending payment
            payOrders.Clear();              // Clear log of orders pending payment
            await getAllOrders();           // Pull all orders

            orderMaster.ForEach(x => {
                if (x.OrderStatus == "Unpaid")
                    payOrders.Add(x);       // Add orders currently pending payment to list
            });
            payOrders.OrderBy(x => x.DateTimeComplete).GroupBy(x => x.OrderNumber); // Organize list

            // Add list of unpaid orders to view with formatting
            foreach (var order in payOrders)
            {
                Menu tempMenu = new Menu();
                tempMenu.ItemId = order.OrderId;

                var name = from menu in menu
                           where menu.ItemId == order.ItemId
                           select new
                           {
                               name = menu.Name,
                               menu.Price

                           };

                name.ToList().ForEach(x => payOrderListBox.Items.Add($"OrderID: {order.OrderId} \t ItemID: {order.ItemId} \t Name: {x.name} \t Quantity: {order.Quantity} \t Price: ${x.Price} \t Order#: {order.OrderNumber}"));
            }
        }

        // When item in orders pending payment view is clicked, perform these actions
        private void payOrderListBox_Click(object sender, EventArgs e)
        {
            finalOrders.Clear();    // Clear list of finalized orders

            List<string> tempOrderList = new List<string>();
            totalGross = 0;
            totalNet = 0;
            taxAmount = 0;

            if (payOrderListBox.SelectedItems.Count != 0) // Ensure an item in the view has been selected
            {
                payOrderInfoBox.Items.Clear(); // Clear current unpaid order view

                foreach(var item in payOrderListBox.Items)
                {
                    if (item != null)
                        tempOrderList.Add(item.ToString());  // Create list of orders to calculate
                }

                foreach(string item in tempOrderList)
                {
                    string tempId;
                    string tempNum;
                    string tempItemId;
                    string tempPrice;
                    string tempQuantity;
                    string name;
                    int id;
                    int ordNum;
                    int selectedNum;
                    int itemId;
                    decimal price;
                    int quantity;
                    int orderId;

                    // Prepare relevant information
                    tempId = item.ToString().Remove(item.ToString().IndexOf("ItemID:")).Substring(8).Trim();

                    orderId = Int32.Parse(item.ToString().Remove(item.IndexOf("ItemID:")).Substring(9).Trim());
                    id = Int32.Parse(tempId);
                    tempNum = item.ToString().Remove(0, item.ToString().IndexOf("Order#:")).Substring(7).Trim();
                    ordNum = Int32.Parse(tempNum);
                    selectedNum = Int32.Parse(payOrderListBox.SelectedItem.ToString().Remove(0, payOrderListBox.SelectedItem.ToString().IndexOf("Order#:")).Substring(7).Trim());
                    tempItemId = item.ToString().Remove(0, item.ToString().IndexOf("ItemID:")).Substring(8).Trim();
                    itemId = Int32.Parse(tempItemId.Remove(tempItemId.IndexOf("Name:")).Trim());
                    tempPrice = item.ToString().Remove(0, item.ToString().IndexOf("Price: $")).Substring(8).Trim();
                    price = Convert.ToDecimal(tempPrice.Remove(tempPrice.IndexOf("Order#:")).Trim());
                    tempQuantity = item.ToString().Remove(0, item.ToString().IndexOf("Quantity:")).Substring(10);
                    quantity = Int32.Parse(tempQuantity.Remove(tempQuantity.IndexOf("Price:")).Trim());
                    name = item.Remove(0, item.IndexOf("Name:")).Substring(5).Trim();
                    name = name.Remove(name.IndexOf("Quantity:")).Trim();

                    // Tabulate order total
                    if (selectedNum == ordNum) {

                        payOrderInfoBox.Items.Add($"ItemID: {itemId} \t Name: {name} \t Quantity: {quantity} \t Price: ${price}");
                        totalGross += price * quantity;
                        taxAmount = totalGross * (decimal)taxPercentage;

                        totalNet = totalGross + taxAmount + tipNumeric.Value;

                        taxBox.Text = taxAmount.ToString();
                        amountBox.Text = totalNet.ToString();

                        foreach(var b in payOrders)
                        {
                            if (b.OrderId == orderId)
                                finalOrders.Add(b);
                        }
                            
                    }
                }
            }
        }

        // Deprecated
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        // Deprecated
        private void orderSelectTab_Click(object sender, EventArgs e)
        {
        }

        // Deprecated
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Deprecated
        private void tipBox_KeyUp(object sender, KeyEventArgs e)
        {
        }

        // When key is released while focused on tipNumeric element, recalculate total due based on tip amount
        private void tipNumeric_KeyUp(object sender, KeyEventArgs e)
        {
            tipAmount = tipNumeric.Value;
            totalNet = totalGross + taxAmount + tipAmount;

            amountBox.Text = totalNet.ToString();
        }

        // When tipNumeric element is clicked, recalculate total due based on tip amount
        private void tipNumeric_Click(object sender, EventArgs e)
        {
            tipAmount = tipNumeric.Value;
            totalNet = totalGross + taxAmount + tipAmount;

            amountBox.Text = totalNet.ToString();
        }

        // Populate the dropdown for payment methods
        public void FillPayMethods()
        {
            methodCombo.Items.Clear();
            methodCombo.Items.Add("Credit Card");
            methodCombo.Items.Add("Cash");
        }

        // Process payment on finalized orders
        private async Task PaymentPost()
        {
            foreach (OrderMain order in finalOrders)
            {
                // Prepare relevant details of each order
                int count = finalOrders.Count();
                Payment payment = new Payment();
                Payment tempPaymentObject = new Payment();
                OrderMain orderMain = new OrderMain();
                Menu menu = new Menu();
                MenuCategory category = new MenuCategory();
                Location location = new Location();
                Country country = new Country();
                RestaurantOrderSystem.Models.Region region = new RestaurantOrderSystem.Models.Region();

                region.RegionId = 0;
                region.RegionName = "string";

                country.CountryName = "string";
                country.RegionId = 0;

                location.LocationId = 0;
                location.LocationName = "string";
                location.StateProvince = "string";
                location.Address = "string";
                location.City = 0;
                location.PostalCode = 0;

                category.CategoryName = "string";
                category.CategoryDescription = "string";

                menu.Name = "string";
                menu.Descrption = "string";
                menu.Notes = "string";
                menu.Price = 0;

                order.OrderStatus = "Complete";
                orderMain.OrderId = 0;
                orderMain.ItemId = 0;
                orderMain.DateTimePlaced = DateTime.Now;
                orderMain.DateTimeComplete = DateTime.Now;
                orderMain.OrderNumber = 0;
                orderMain.OrderStatus = "string";

                payment.Method = methodCombo.SelectedText.ToString();
                payment.Method = "Cash";
                payment.Amount = totalNet;
                payment.PaymentTimeStamp = DateTime.Now;
                payment.OrderNumber = order.OrderNumber;
                
                payment.Location = location;
                payment.Location.Country = country;
                payment.Location.Country.Region = region;
                payment.OrderMain = orderMain;
                payment.OrderMain.Menu = menu;
                payment.OrderMain.Menu.Category = category;
                
                tempOrderId = order.OrderId;

                order.Menu = menu;
                order.Menu.Category = category;

                try
                {
                    // Post payment record to database
                    HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/Payments", payment);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        tempPaymentObject = await response.Content.ReadFromJsonAsync<Payment>();
                    }
                    tempPaymentObject.LocationId = 1;
                    tempItemId = order.ItemId;
                    order.ItemId = order.ItemId;
                    order.OrderNumber = order.OrderNumber;
                    order.OrderStatus = order.OrderStatus;
                    order.Quantity = order.Quantity;
                    order.DateTimeComplete = order.DateTimeComplete;
                    order.DateTimePlaced = order.DateTimePlaced;

                    // Make relevant changes to order lists
                    await UpdatePayment(tempPaymentObject);
                    await SecondaryUpdateOrder(order);

                    // Remove placeholder information
                    await MainForm.DeleteOrder(tempPaymentObject.OrderMain.OrderId);
                    await MainForm.DeleteMenu(tempPaymentObject.OrderMain.Menu.ItemId);
                    await MainForm.DeleteCategory(tempPaymentObject.OrderMain.Menu.Category.CategoryId);
                    await MainForm.DeleteLocation(tempPaymentObject.Location.LocationId);
                    await MainForm.DeleteCountry(tempPaymentObject.Location.Country.CountryId);
                    await MainForm.DeleteRegion(tempPaymentObject.Location.Country.Region.RegionId);

                    creditCardBox.Text = "";
                    taxBox.Text = "";
                    tipNumeric.Value = 0;
                    amountBox.Text = "0";
                    totalGross = 0;
                    totalNet = 0;
                    tipAmount = 0;
                    taxAmount = 0;
                    await FillPayOrders(); // Refresh list of unpaid orders
                }
                catch (HttpRequestException error)
                {
                    MessageBox.Show(error.Message);
                    return;
                }
            }
        }

        // Update payment record in database
        private async Task UpdatePayment(Payment payment)
        {
            payment.OrderId = tempOrderId;

            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/Payments/{payment.PaymentId}", payment);
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Update Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Update order record in database
        private async Task SecondaryUpdateOrder(OrderMain order)
        {
            OrderMain orderMain = new OrderMain();
            orderMain.OrderId = order.OrderId;
            orderMain.OrderNumber = order.OrderNumber;
            orderMain.OrderStatus = order.OrderStatus;
            orderMain.Quantity = order.Quantity;
            orderMain.DateTimeComplete = order.DateTimeComplete;
            orderMain.DateTimePlaced = order.DateTimePlaced;
            orderMain.ItemId = order.ItemId;

            Menu menu = new Menu();
            MenuCategory category = new MenuCategory();
            menu.Name = "string";
            menu.Descrption = "string";
            menu.Notes = "string";
            menu.Price = 0;
            category.CategoryName = "string";
            category.CategoryDescription = "string";

            orderMain.Menu = menu;
            orderMain.Menu.Category = category;

            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/OrderMains/{orderMain.OrderId}", orderMain);
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Update Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Process order payment when Submit button is clicked
        private async void submit_Click(object sender, EventArgs e)
        {
            await PaymentPost();
        }

        // Manually refresh list and view of unpaid orders
        private async void refreshPayButton_Click(object sender, EventArgs e)
        {
            await FillPayOrders();
        }
    }
}
