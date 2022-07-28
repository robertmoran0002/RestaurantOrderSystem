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

        //List<MenuCategory> categories = new List<MenuCategory>();
        Dictionary<int, MenuCategory> categories = new Dictionary<int, MenuCategory>();
        bool initialized = false;
        //int tempCatId;

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
                    //menuViewListBox.Items.Add($"Id: {item.ItemId} \t\t Name: {item.Name} \t\t Description: {item.Descrption} \t\t" +
                    //    $"Notes: {item.Notes} \t\t CategoryId: {item.CategoryId} \t\t Price: ${item.Price}");
                    menuViewListBox.Items.Add(item);
                }
            }
        }

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

        public void fillDropdown()
        {
            
            categoryCombo.Items.Clear();
            menuUpCombo.Items.Clear();
            foreach (var category in categories)
            {
                CategoryHelper categoryHelper = new CategoryHelper(category.Value.CategoryId,category.Value.CategoryName);
                categoryCombo.Items.Add(categoryHelper);
                menuUpCombo.Items.Add(categoryHelper);
            }
        }

        private void viewMenuButton_Click(object sender, EventArgs e)
        {
            menuViewListBox.Items.Clear();
            getAllMenu();
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!initialized)
            //{
            //    await getAllCategories();
            //    //fillDropdown();
            //    initialized = true;
            //}
            int indUpdate = tabControl1.TabPages.IndexOfKey("updateMenuTab");
            int indAdd = tabControl1.TabPages.IndexOfKey("addMenuTab");
            if (tabControl1.SelectedTab == tabControl1.TabPages[indUpdate] || tabControl1.SelectedTab == tabControl1.TabPages[indAdd]) 
            {
                await getAllCategories();
                fillDropdown();
            }
        }



        private async void menuPostButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Name = menuNameBox.Text;
            menu.Descrption = menuDescRBox.Text.Trim();
            menu.Notes = menuNotesRBox.Text.Trim();
            menu.Price = priceNumeric.Value;

            int id = ((CategoryHelper)categoryCombo.SelectedItem).Id;
            menu.CategoryId = categories[id].CategoryId;

            try
            {
                Menu tempMenu = null;
                HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/Menus", menu);
                response.EnsureSuccessStatusCode();
                //label15.Text = response.Content.ToString();
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



            MessageBox.Show(MainForm.successPostMessage);
            menuNameBox.Text = null;
            menuDescRBox.Text = null;
            menuNotesRBox.Text = null;
            priceNumeric.Value = 0;
        }

        private async void menuDeleteButton_ClickAsync(object sender, EventArgs e)
        {
            if (menuViewListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                //tabControl1.SelectedIndex = 2;
                return;
            }

            Menu menu = new Menu();

            if (menuViewListBox.SelectedItem != null)
                menu.ItemId = ((Menu) menuViewListBox.SelectedItem).ItemId;
            //menu.ItemId = Int32.Parse(menuViewListBox.SelectedItem.ToString().Trim()
            //    .Remove(menuViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));

            try
            {
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

        private async void updateMenuButton_Click(object sender, EventArgs e)
        {
            if (menuViewListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                //tabControl1.SelectedIndex = 2;
                return;
            }
            else{
                    Menu menu = new Menu();
                    menu = (Menu) menuViewListBox.SelectedItem;
                //string temp1;
                //string temp2;
                //menu.ItemId = Int32.Parse(menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(menuViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));

                //menu.Name = menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(menuViewListBox.SelectedItem.ToString().LastIndexOf("Description:"));
                //menu.Name = menu.Name
                //    .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Name:") + "Name: ".Length).Trim();

                //menu.Descrption = menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Description:") + "Description:".Length).Substring(1);
                //menu.Descrption = menu.Descrption
                //    .Remove(menu.Descrption.IndexOf("Notes:")).Trim();


                //menu.Notes = menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Notes:") + "Notes:".Length).Substring(1);
                //menu.Notes = menu.Notes.Remove(menu.Notes.IndexOf("CategoryId:")).Trim();

                //temp1 = menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("CategoryId:") + "CategoryId:".Length).Substring(1);
                //temp1 = temp1.Remove(temp1.IndexOf("Price: $")).Trim();
                //menu.CategoryId = Int32.Parse(temp1);

                //temp2 = menuViewListBox.SelectedItem.ToString().Trim()
                //    .Remove(0, menuViewListBox.SelectedItem.ToString().IndexOf("Price: $") + "Price: $".Length).Substring(0);
                //menu.Price = Convert.ToDecimal(temp2);

                     menuUpCombo.SelectedItem = categories[menu.CategoryId].CategoryName;

                //foreach (var category in categories)
                //    {
                //        if (category.CategoryId == menu.CategoryId)
                //        {
                //            menuUpCombo.SelectedItem = category.CategoryName;
                //        }
                //    }

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

        private async void menuUpdateButton_Click(object sender, EventArgs e)
        {
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
            Menu menu = new Menu();
            //MenuCategory menuCategory = new MenuCategory();

            menu.ItemId = Int32.Parse(menuIdUpBox.Text);
            menu.Name = menuNameUpdateBox.Text;
            menu.Descrption = menuDescUpRBox.Text;
            menu.Notes = menuNotesUpRBox.Text;
            //menuCategory.CategoryName = "string";

            //if (categoryCombo.SelectedItem != null)
            //    menuCategory.CategoryDescription = categoryCombo.SelectedItem.ToString();
            //else menuCategory.CategoryDescription = "Unassigned";

            //menu.Category = menuCategory;
            menu.Price = Convert.ToDecimal(menuUpNumeric.Value);


            menu.CategoryId = categories[((CategoryHelper)menuUpCombo.SelectedItem).Id].CategoryId;
            //foreach (var category in categories)
            //{
            //    if (category.Value.CategoryName == menuUpCombo.Text)
            //    {
            //        menu.CategoryId = category.Value.CategoryId;
            //        //menuCategory.CategoryId = category.Value.CategoryId;
            //    }
            //}

            try
            {
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

        //private async Task changeMenu(Menu correctMenu)
        //{
        //    tempCatId = correctMenu.CategoryId;
        //    foreach(var item in categories)
        //    {
        //        if(categoryCombo.SelectedItem.ToString() == item.CategoryName)
        //        {
        //            correctMenu.CategoryId = item.CategoryId;
        //            correctMenu.Category.CategoryId = item.CategoryId;
        //        }
        //    }

        //    try
        //    {
        //        HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/Menus/{correctMenu.ItemId}", correctMenu);
        //        response.EnsureSuccessStatusCode();
        //        //MessageBox.Show("Update Successful!");
        //    }
        //    catch (HttpRequestException error)
        //    {
        //        MessageBox.Show(error.Message);
        //        return;
        //    }
        //}

        //private async Task deleteCategory()
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/MenuCategories/{tempCatId}");
        //        response.EnsureSuccessStatusCode();
        //        //MessageBox.Show("Deletion Successful!");
        //        tempCatId = 0;
        //    }
        //    catch (HttpRequestException error)
        //    {
        //        MessageBox.Show(error.Message);
        //        return;
        //    }
        //}

        private void backButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
