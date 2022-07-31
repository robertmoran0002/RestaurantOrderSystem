using RestaurantOrderSystem.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RestaurantOrderSystemForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Create client connection to the API
            client.BaseAddress = new Uri("https://localhost:7011");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        public static HttpClient client = new HttpClient();
        CategoryForm categoryForm = new CategoryForm();
        MenuForm menuForm = new MenuForm();
        NewOrder newOrderForm = new NewOrder();
        ProcessOrders processOrders = new ProcessOrders();

        public static string successPostMessage = "Your submission was successful!";

        // Method to pull up Catagories form
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!categoryForm.IsDisposed) 
            { 
                categoryForm.MdiParent = this;
                categoryForm.Show();
            }
            else 
            {
                categoryForm.Dispose();
                categoryForm = new CategoryForm();
                categoriesToolStripMenuItem_Click(sender, e);
            }
        }

        // Method to pull up Menu form
        private async void menuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!menuForm.IsDisposed) 
            { 
                menuForm.MdiParent = this;
                await menuForm.getAllCategories(); // Initial population of menu categories
                menuForm.Show();
            }
            else 
            { 
                menuForm.Dispose();
                menuForm = new MenuForm();
                menuItemsToolStripMenuItem_Click(sender,e);
            }
        }

        // Method to pull up the New Order form
        private async void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!newOrderForm.IsDisposed) 
            { 
                // Initial population of Menu view and applicable payment options
                await newOrderForm.getAllMenu();
                await newOrderForm.getAllCategories();
                newOrderForm.fillMenuView();
                newOrderForm.FillPayMethods();

                newOrderForm.MdiParent = this;
                newOrderForm.Show();
            }
            else 
            {
                newOrderForm.Dispose();
                newOrderForm = new NewOrder();
                newOrderToolStripMenuItem_Click(sender, e);
            }
        }

        // Method to pull up the Process Orders form
        private void processOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!processOrders.IsDisposed) 
            { 
                processOrders.MdiParent = this;
                getAllMenu(ProcessOrders.kitchenMenu); // Initial population of applicable menu
                processOrders.Show();
            }
            else 
            {
                processOrders.Dispose();
                processOrders = new ProcessOrders();
                processOrdersToolStripMenuItem_Click(sender, e);
            }
        }

        // Method to pull Menu information from database
        public static async void getAllMenu(List<Menu> menuList)
        {
            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("api/Menus");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                menuList.Clear();
                var menuResponse = await response.Content.ReadFromJsonAsync<IEnumerable<Menu>>();

                foreach (var item in menuResponse)
                {
                    menuList.Add(item);
                }
            }
        }

        // Method to pull Order information from database
        public static async void getAllOrders(List<OrderMain> orderList)
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
                    orderList.Add(order);
                }
            }
        }

        // Method to delete Category from database
        public static async Task DeleteCategory(int tempCatId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/MenuCategories/{tempCatId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to delete menu from database
        public static async Task DeleteMenu(int tempItemId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Menus/{tempItemId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to delete location from database
        public static async Task DeleteLocation(int tempLocationId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Locations/{tempLocationId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to delete country from database
        public static async Task DeleteCountry(int tempCountryId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Countries/{tempCountryId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to delete region from database
        public static async Task DeleteRegion(int tempRegionId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Regions/{tempRegionId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to delete order from database
        public static async Task DeleteOrder(int tempOrderId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/OrderMains/{tempOrderId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
    }
}