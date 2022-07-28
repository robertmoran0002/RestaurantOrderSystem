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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        
        // Prepare list for use in later views and some needed variables
        List<MenuCategory> categories = new List<MenuCategory>();
        bool initialized = false;
        int tempCatId;

        // Populate list and add formatting for the view
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
                    menuViewListBox.Items.Add($"Id: {item.ItemId} \t\t Name: {item.Name} \t\t Description: {item.Descrption} \t\t" +
                        $"Notes: {item.Notes} \t\t CategoryId: {item.CategoryId} \t\t Price: ${item.Price}");
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
                    categories.Add(category);
                }
            }
        }

        // Populate views for category information
        public void fillDropdown()
        {
            foreach (var category in categories)
            {
                categoryCombo.Items.Add(category.CategoryName);
                menuUpCombo.Items.Add(category.CategoryName);
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
            if (!initialized)               // Check component initialization status, if not initialized ..
            {
                await getAllCategories();   // Pull category information
                fillDropdown();             // Populate view
                initialized = true;         // Set initialization status to true
            }
        }


        // WHen Add Item button is clicked ..
        private async void menuPostButton_Click(object sender, EventArgs e)
        {
            // Prepare variebles
            Menu menu = new Menu();
            MenuCategory menuCat = new MenuCategory();
            menuCat.CategoryName = "Unassigned";

            // Ensure a category has been selected for the item to be added
            if (categoryCombo.SelectedItem != null)
                menuCat.CategoryName = categoryCombo.SelectedItem.ToString();

            // Populate other details needed from the input provided on the form
            menuCat.CategoryDescription = "string";
            menu.Name = menuNameBox.Text;
            menu.Descrption = menuDescRBox.Text.Trim();
            menu.Notes = menuNotesRBox.Text.Trim();
            menu.Price = priceNumeric.Value;
            menu.Category = menuCat;

            foreach (var category in categories)
            {
                if (category.CategoryName == categoryCombo.SelectedItem.ToString() && categoryCombo.SelectedItem != null)
                {
                    menu.CategoryId = category.CategoryId;   
                    menu.Category.CategoryName = category.CategoryName;
                }
            }

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

                await changeMenu(tempMenu);
                await deleteCategory();
                
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

            // Ensure an item has been selected from the view, parse it for relevant information
            if (menuViewListBox.SelectedItem != null) 
            menu.ItemId = Int32.Parse(menuViewListBox.SelectedItem.ToString().Trim()
                .Remove(menuViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));

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
            if (menuViewListBox.SelectedItem == null) // If no item is selected
            {
                tabControl1.SelectedIndex = 2; // Just switch to Update Item tab
            }
            else{
                    // Otherwise, pull information from the selected item and trim excess to populate the form, then switch tabs
                    Menu menu = new Menu();
                    string temp1;
                    string temp2;
                    menu.ItemId = Int32.Parse(menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(menuViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));

                    menu.Name = menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(menuViewListBox.SelectedItem.ToString().LastIndexOf("Description:"));
                    menu.Name = menu.Name
                        .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Name:") + "Name: ".Length).Trim();

                    menu.Descrption = menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Description:") + "Description:".Length).Substring(1);
                    menu.Descrption = menu.Descrption
                        .Remove(menu.Descrption.IndexOf("Notes:")).Trim();


                    menu.Notes = menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Notes:") + "Notes:".Length).Substring(1);
                    menu.Notes = menu.Notes.Remove(menu.Notes.IndexOf("CategoryId:")).Trim();

                    temp1 = menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("CategoryId:") + "CategoryId:".Length).Substring(1);
                    temp1 = temp1.Remove(temp1.IndexOf("Price: $")).Trim();
                    menu.CategoryId = Int32.Parse(temp1);

                    temp2 = menuViewListBox.SelectedItem.ToString().Trim()
                        .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Price: $") + "Price: $".Length).Substring(0);
                    menu.Price = Convert.ToDecimal(temp2);

                    foreach (var category in categories)
                    {
                        if (category.CategoryId == menu.CategoryId)
                        {
                            menuUpCombo.SelectedItem = category.CategoryName;
                        }
                    }

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
            // Pull information from the form
            Menu menu = new Menu();
            MenuCategory menuCategory = new MenuCategory();

            menu.ItemId = Int32.Parse(menuIdUpBox.Text);
            menu.Name = menuNameUpdateBox.Text;
            menu.Descrption = menuDescUpRBox.Text;
            menu.Notes = menuNotesUpRBox.Text;
            menuCategory.CategoryName = "string";

            if (categoryCombo.SelectedItem != null)
                menuCategory.CategoryDescription = categoryCombo.SelectedItem.ToString();
            else menuCategory.CategoryDescription = "Unassigned";

            menu.Category = menuCategory;
            menu.Price = Convert.ToDecimal(menuUpNumeric.Value);

            foreach (var category in categories)
            {
                if (category.CategoryName == menuUpCombo.Text)
                {
                    menu.CategoryId = category.CategoryId;
                    menuCategory.CategoryId = category.CategoryId;
                }
            }

            try
            {
                // Commit change to database
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

        // Method to commit new Item to database
        private async Task changeMenu(Menu correctMenu)
        {
            tempCatId = correctMenu.CategoryId;
            foreach(var item in categories)
            {
                if(categoryCombo.SelectedItem.ToString() == item.CategoryName)
                {
                    correctMenu.CategoryId = item.CategoryId;
                    correctMenu.Category.CategoryId = item.CategoryId;
                }
            }

            try
            {
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/Menus/{correctMenu.ItemId}", correctMenu);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Method to remove category from database
        private async Task deleteCategory()
        {
            try
            {
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/MenuCategories/{tempCatId}");
                response.EnsureSuccessStatusCode();
                tempCatId = 0;
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // Deprecated
        private void backButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        // Deprecated
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
        }

        // Deprecated
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
