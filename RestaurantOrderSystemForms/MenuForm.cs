using RestaurantOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantOrderSystemForms
{
    // Helper object to use for casting purposes
    struct CategoryHelper
    {
        public CategoryHelper(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }

    }

    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        // Prepare list for use in later views
        Dictionary<int, MenuCategory> categories = new Dictionary<int, MenuCategory>();

        // Populate list
        private async void getAllMenu()
        {
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
                var menu = await response.Content.ReadFromJsonAsync<IEnumerable<Menu>>();

                foreach (var item in menu)
                {
                    menuViewListBox.Items.Add(item);
                }
            }
        }

        // Populate category list
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
                    categories.Add(category.CategoryId,category);
                }
            }
        }

        // Populate views for category information
        public void fillDropdown()
        {
            // Clear old information
            categoryCombo.Items.Clear();
            menuUpCombo.Items.Clear();
            foreach (var category in categories)
            {
                // Repopulate with applicable updates
                CategoryHelper categoryHelper = new CategoryHelper(category.Value.CategoryId,category.Value.CategoryName);
                categoryCombo.Items.Add(categoryHelper);
                menuUpCombo.Items.Add(categoryHelper);
            }
        }

        // When View Menu button is clicked .. 
        private void viewMenuButton_Click(object sender, EventArgs e)
        {
            menuViewListBox.Items.Clear();  // Empty the current view
            getAllMenu();                   // Repopulate with current information
        }

        // When a new item is clicked in the tabControl ribbon
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verify an appropriate tabe was clicked
            int indUpdate = tabControl1.TabPages.IndexOfKey("updateMenuTab");
            int indAdd = tabControl1.TabPages.IndexOfKey("addMenuTab");
            if (tabControl1.SelectedTab == tabControl1.TabPages[indUpdate] || tabControl1.SelectedTab == tabControl1.TabPages[indAdd]) 
            {
                // Get needed information and fill the view
                await getAllCategories();
                fillDropdown();
            }
        }

        // WHen Add Item button is clicked ..
        private async void menuPostButton_Click(object sender, EventArgs e)
        {
            // Pull information from input form
            Menu menu = new Menu();
            menu.Name = menuNameBox.Text;
            menu.Descrption = menuDescRBox.Text.Trim();
            menu.Notes = menuNotesRBox.Text.Trim();
            menu.Price = priceNumeric.Value;

            int id = ((CategoryHelper)categoryCombo.SelectedItem).Id;
            menu.CategoryId = categories[id].CategoryId;

            try
            {
                // Post new item to database
                Menu tempMenu = null;
                HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/Menus", menu);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    tempMenu = await response.Content.ReadFromJsonAsync<Menu>();
                }
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            // Return input fields to defaults
            MessageBox.Show(MainForm.successPostMessage);
            menuNameBox.Text = null;
            menuDescRBox.Text = null;
            menuNotesRBox.Text = null;
            priceNumeric.Value = 0;
        }

        // When Delete Item button is clicked .. 
        private async void menuDeleteButton_ClickAsync(object sender, EventArgs e)
        {
            Menu menu = new Menu();

            // Ensure a selection has been made, if so then grab the ID
            if (menuViewListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                return;
            }
            else
            {
                menu.ItemId = ((Menu)menuViewListBox.SelectedItem).ItemId;
            }   

            try
            {
                // Commit change to database
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/Menus/{menu.ItemId.ToString()}");
                response.EnsureSuccessStatusCode();
                menuViewListBox.Items.Clear();
                await getAllCategories();
                MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // When Update Item button on View Menu Items tab is clicked ..
        private async void updateMenuButton_Click(object sender, EventArgs e)
        {
            // Ensure an item has been selected, if so then switch to the update tab and populate the form
            if (menuViewListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                return;
            }
            else
            {
                Menu menu = new Menu();
                menu = (Menu) menuViewListBox.SelectedItem;
                menuUpCombo.SelectedItem = categories[menu.CategoryId].CategoryName;
                menuIdUpBox.Text = menu.ItemId.ToString();
                menuNameUpdateBox.Text = menu.Name;
                menuDescUpRBox.Text = menu.Descrption;
                menuNotesUpRBox.Text = menu.Notes;
                menuUpCombo.SelectedItem = menu.Category;
                menuUpNumeric.Value = menu.Price;
                await getAllCategories();
                tabControl1.SelectedIndex = 2;
            }
        }

        // When Update Item button on the Update Item tab is clicked ..
        private async void menuUpdateButton_Click(object sender, EventArgs e)
        {
            // Ensure required information is provided
            if (menuIdUpBox.Text == "" || !Char.IsDigit(menuIdUpBox.Text,0)) 
            {
                MessageBox.Show("Please enter an id!");
                return;
            }
            if (menuUpCombo.SelectedItem == null) 
            {
                MessageBox.Show("Please select a category");
                return;
            }

            // Pull information from the input form
            Menu menu = new Menu();
            menu.ItemId = Int32.Parse(menuIdUpBox.Text);
            menu.Name = menuNameUpdateBox.Text;
            menu.Descrption = menuDescUpRBox.Text;
            menu.Notes = menuNotesUpRBox.Text;
            menu.Price = Convert.ToDecimal(menuUpNumeric.Value);
            menu.CategoryId = categories[((CategoryHelper)menuUpCombo.SelectedItem).Id].CategoryId;

            try
            {
                // Commit change to the database
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/Menus/{menuIdUpBox.Text}", menu);
                response.EnsureSuccessStatusCode();
                menuViewListBox.Items.Clear();
                getAllMenu();
                MessageBox.Show("Update Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Takes user back to View tab
        private void backButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        // Takes user back to View tab
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        // Method to readjust screen layout
        private void SetPosition()
        {
            menuViewListBox.Height = (int)(this.Height * .83);
        }

        // Adjusts view box upon form resize
        private void MenuForm_SizeChanged(object sender, EventArgs e)
        {
            SetPosition();
        }

        // Deprecated
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
        }

        // Deprecated
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        // Deprecated
        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}