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
        List<MenuAndCategory> menuAndCategoriesList = new List<MenuAndCategory>();

        public static int currentOrderNumber;
        public static decimal total = 0;
        private int tempItemId;
        private int tempOrderId;
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
            menuViewListBox.Items.Clear();
            FillMenuAndCategoriesList();

            foreach (var item in menuAndCategoriesList)
            {
                if (item.Category == categorySearchComboBox.Text)
                {
                    menuViewListBox.Items.Add($"Id: {item.ItemId} \t Name: {item.Name} \t Description: {item.Description} \t\t" +
                            $"Notes: {item.Notes} \t\t Category: {item.Category} \t Price: ${item.Price}");
                }
            }
            if (categorySearchComboBox.Text == "All" || categorySearchComboBox.Text == "")
            menuAndCategoriesList.ForEach(x => menuViewListBox.Items.Add($"Id: {x.ItemId} \t Name: {x.Name} \t Description: {x.Description} \t\t" +
                            $"Notes: {x.Notes} \t\t Category: {x.Category} \t Price: ${x.Price}"));
        }

        // Clears and fills the MenuAndCategory list and organizes it by category name. Populates the category search combo box.
        public void FillMenuAndCategoriesList()
        {
            menuAndCategoriesList.Clear();
            categorySearchComboBox.Items.Clear();
            categorySearchComboBox.Items.Add("All");
            categories.OrderBy(x => x.CategoryName);
            categories.ForEach(x => categorySearchComboBox.Items.Add(x.CategoryName));

            foreach (var item in menu)
            {
                foreach (var category in categories)
                {
                    if (item.CategoryId == category.CategoryId)
                    {
                        MenuAndCategory menuAndCategory = new MenuAndCategory();

                        menuAndCategory.ItemId = item.ItemId;
                        menuAndCategory.Name = item.Name;
                        menuAndCategory.Description = item.Descrption;
                        menuAndCategory.Notes = item.Notes;
                        menuAndCategory.Category = category.CategoryName;
                        menuAndCategory.Price = item.Price;

                        menuAndCategoriesList.Add(menuAndCategory);
                    }
                }
            }
            menuAndCategoriesList.OrderBy(x => x.Category);
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
                        //payOrderListBox.Items.Add(item);
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

                try
                {
                    // Add pending order to database
                    HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/OrderMains", newOrder);
                    response.EnsureSuccessStatusCode();
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
            menuViewListBox.Width = (int)(this.Width * .65);
            orderViewListBox.Width = (int)(this.Width * .28);
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

                foreach (var item in payOrderListBox.Items)
                {
                    if (item != null)
                        tempOrderList.Add(item.ToString());  // Create list of orders to calculate
                }

                foreach (string item in tempOrderList)
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
                    if (selectedNum == ordNum)
                    {

                        payOrderInfoBox.Items.Add($"ItemID: {itemId} \t Name: {name} \t Quantity: {quantity} \t Price: ${price}");
                        totalGross += price * quantity;
                        taxAmount = totalGross * (decimal)taxPercentage;

                        totalNet = totalGross + taxAmount + tipNumeric.Value;

                        taxBox.Text = taxAmount.ToString();
                        amountBox.Text = totalNet.ToString();

                        foreach (var b in payOrders)
                        {
                            if (b.OrderId == orderId)
                                finalOrders.Add(b);
                        }

                    }
                    payOrderInfoBox.Refresh();
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
            if (methodCombo.SelectedItem != null) // Ensures a payment method is selected
            {
                foreach (OrderMain order in finalOrders)
                {
                    // Prepare relevant details of each order
                    int count = finalOrders.Count();
                    Payment payment = new Payment();
                    Payment tempPaymentObject = new Payment();

                    order.OrderStatus = "Complete";
                    payment.Method = methodCombo.SelectedItem.ToString();
                    payment.Amount = totalNet;
                    payment.PaymentTimeStamp = DateTime.Now;
                    payment.OrderNumber = order.OrderNumber;
                    payment.OrderId = order.OrderId;

                    //*** THIS IS A TEMPORARY FIX*** LocationId should be the store's location Id
                    payment.LocationId = 1;

                    tempOrderId = order.OrderId;

                    try
                    {
                        // Post payment record to database
                        HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/Payments", payment);
                        response.EnsureSuccessStatusCode();
                        MessageBox.Show("Transaction Successful.");

                        // Make relevant changes to order lists
                        await UpdateOrder(order);

                        creditCardBox.Text = "";
                        taxBox.Text = "";
                        tipNumeric.Value = 0;
                        amountBox.Text = "0";
                        totalGross = 0;
                        totalNet = 0;
                        tipAmount = 0;
                        taxAmount = 0;
                        payOrderInfoBox.Items.Clear();
                        await FillPayOrders(); // Refresh list of unpaid orders
                    }
                    catch (HttpRequestException error)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                }
            }
            else MessageBox.Show("Please select a payment method.");
        }

        // Update payment record in database
        private async Task UpdatePayment(Payment payment)
        {
            payment.OrderId = tempOrderId;

            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/Payments/{payment.PaymentId}", payment);
                response.EnsureSuccessStatusCode();
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
            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/OrderMains/{order.OrderId}", order);
                response.EnsureSuccessStatusCode();
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

        // Refreshes the order view when a tab is clicked
        private async void tabControl1_Click(object sender, EventArgs e)
        {
            await FillPayOrders();
        }

        // Repopulates the menu view list box when a category is selected
        private void categorySearchComboBox_TextChanged(object sender, EventArgs e)
        {
            fillMenuView();
        }

        private void orderViewListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    // Uses relevant data members from the Menu and MenuCategory classes for convienience
    public class MenuAndCategory
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
