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
    public partial class ProcessOrders : Form
    {
        public ProcessOrders()
        {
            InitializeComponent();
        }

        List<OrderMain> incompleteOrders = new List<OrderMain>();
        public static List<Menu> kitchenMenu = new List<Menu>();
        
        int selectedIndex;
        //int location;

        private async

        Task getAllOrders()
        {
            HttpResponseMessage response;
            try
            {
                response = await MainForm.client.GetAsync("api/OrderMains");
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
                foreach (var order in orders)
                {
                    if (order.OrderStatus == "Placed")
                        incompleteOrders.Add(order);
                }
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            incompleteOrders.Clear();
            await getAllOrders();
            orderQueue.Items.Clear();
            orderQueue.Refresh();
            incompleteOrders.OrderBy(x => x.DateTimePlaced);

            foreach(var order in incompleteOrders)
            {
                Menu tempMenu = new Menu();
                tempMenu.ItemId = order.OrderId;

                var name = from menu in kitchenMenu
                           where menu.ItemId == order.ItemId
                           select new
                           {
                               name = menu.Name,
                               desc = menu.Descrption,
                               notes = menu.Notes
                           };

                name.OrderBy(x => x.name).ToList().ForEach(x => orderQueue.Items.Add($"Menu ID: {order.ItemId} \t Name: {x.name} \t Quantity: {order.Quantity} \t OrderNumber: {order.OrderNumber} \t Description: {x.desc} \t\t Notes: {x.notes} \t OrderID: {order.OrderId}"));
            }
        }

        public static void SetPositions(ProcessOrders pOrForm)
        {
            pOrForm.orderQueue.Width = (int)((int)(pOrForm.Width * .81));
            pOrForm.label1.Top = pOrForm.Top + 30;
            pOrForm.label1.Left = pOrForm.orderQueue.Right + 15;
            pOrForm.label2.Left = pOrForm.orderQueue.Right + 20;
            pOrForm.label2.Top = pOrForm.label1.Bottom + 10;
            pOrForm.completeButton.Left = pOrForm.orderQueue.Right + 20;
            pOrForm.completeButton.Top = pOrForm.label1.Bottom + 50;
            pOrForm.cancelButton.Left = pOrForm.orderQueue.Right + 20;
            pOrForm.cancelButton.Top = pOrForm.Bottom - 100;
        }

        private void ProcessOrders_ResizeEnd(object sender, EventArgs e)
        {
            //SetPositions(this);
        }

        private void ProcessOrders_SizeChanged(object sender, EventArgs e)
        {
            SetPositions(this);
        }

        private async void completeButton_Click(object sender, EventArgs e)
        {
            if (orderQueue.SelectedItem != null)
                await UpdateOrder("Unpaid");
        }

        private async void cancelButton_Click(object sender, EventArgs e)
        {
            if (orderQueue.SelectedItem != null)
                await UpdateOrder("Cancelled");
        }

        private int GetOrderId()
        {
            string temp;
            selectedIndex = orderQueue.SelectedIndex;
            temp = orderQueue.SelectedItem.ToString();
            temp = temp.Remove(0,temp.IndexOf("OrderID:")).Substring(8).Trim();
            
            return Int32.Parse(temp);
        }

        private async Task UpdateOrder(string orderStatus)
        {
            OrderMain orderMain = new OrderMain();
            OrderMain removeOrder = new OrderMain();
            Menu menu = new Menu();
            MenuCategory menuCategory = new MenuCategory();

            menu.Descrption = "string";
            menu.Name = "string";
            menu.Price = 0;
            menu.Notes = "string";

            menuCategory.CategoryName = "string";
            menuCategory.CategoryDescription = "string";

            menu.Category = menuCategory;

            int orderId = GetOrderId();

            foreach (var order in incompleteOrders)
            {
                if (order.OrderId.Equals(orderId))
                {
                    removeOrder = order;
                    orderMain = order;
                    orderMain.OrderStatus = orderStatus;
                    orderMain.DateTimeComplete = DateTime.Now;
                    orderMain.Menu = menu;
                }
            }
            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/OrderMains/{orderId}", orderMain);
                response.EnsureSuccessStatusCode();
                if(orderStatus == "Unpaid")
                    MessageBox.Show("Order Complete.");
                if (orderStatus == "Cancelled")
                    MessageBox.Show("Order Cancelled.");
                orderQueue.Items.Remove(removeOrder);
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }


    }
    //public class OrderMenuJoin
    //{
    //    public int ItemId { get; set; }
    //    public string Name { get; set; } = null!;
    //    public string Descrption { get; set; } = null!;
    //    public string? Notes { get; set; }
    //    public int CategoryId { get; set; }
    //    public MenuCategory Category { get; set; }
    //    public decimal Price { get; set; }

    //    public int OrderId { get; set; }
    //    public Menu Menu { get; set; }
    //    public int Quantity { get; set; }
    //    public DateTime? DateTimePlaced { get; set; }
    //    public DateTime? DateTimeComplete { get; set; }
    //    public int OrderNumber { get; set; }
    //    public string OrderStatus { get; set; } = null!;
    //}
}
