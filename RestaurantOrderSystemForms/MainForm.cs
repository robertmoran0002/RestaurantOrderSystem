using RestaurantOrderSystem.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RestaurantOrderSystemForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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

        private async void menuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!menuForm.IsDisposed)
            {
                menuForm.MdiParent = this;
                await menuForm.getAllCategories();
                menuForm.fillDropdown();
                menuForm.Show();
            }
            else
            {
                menuForm.Dispose();
                menuForm = new MenuForm();
                menuItemsToolStripMenuItem_Click(sender, e);
            }
        }

        private async void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!newOrderForm.IsDisposed)
            {
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

        private void processOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!processOrders.IsDisposed)
            {
                processOrders.MdiParent = this;
                getAllMenu(ProcessOrders.kitchenMenu);
                processOrders.Show();
                //ProcessOrders.SetPositions(processOrders);

            }
            else
            {
                processOrders.Dispose();
                processOrders = new ProcessOrders();
                processOrdersToolStripMenuItem_Click(sender, e);
            }
        }

        public static async void getAllMenu(List<Menu> menuList)
        {

            string categoryName;

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
                    menuList.Add(item);
                }
            }
        }

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
                //int x = 0;
                foreach (var order in orders)
                {
                    //if(order.LocationId == location)
                    orderList.Add(order);
                }
            }
        }

        public static async Task DeleteCategory(int tempCatId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/MenuCategories/{tempCatId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        public static async Task DeleteMenu(int tempItemId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Menus/{tempItemId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        public static async Task DeleteLocation(int tempLocationId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Locations/{tempLocationId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        public static async Task DeleteCountry(int tempCountryId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Countries/{tempCountryId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        public static async Task DeleteRegion(int tempRegionId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Regions/{tempRegionId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        public static async Task DeleteOrder(int tempOrderId)
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/OrderMains/{tempOrderId}");
                response.EnsureSuccessStatusCode();
                //MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
    }
}