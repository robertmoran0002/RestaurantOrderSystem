using Microsoft.AspNetCore.Mvc;
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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        // When Add Category button is clicked ..
        private async void categoryPostButton_Click(object sender, EventArgs e)
        {
            // Pull information from form
            MenuCategory menuCat = new MenuCategory();
            menuCat.CategoryName = categoryNameBox.Text;
            menuCat.CategoryDescription = categoryDescRBox.Text;


            try
            {
                // Commit change to database
                HttpResponseMessage response = await MainForm.client.PostAsJsonAsync("api/MenuCategories", menuCat);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            MessageBox.Show(MainForm.successPostMessage);
            categoryNameBox.Text = null;
            categoryDescRBox.Text = null;
        }

        // When View Categories button is clicked .. 
        private async void viewCategoriesButton_Click(object sender, EventArgs e)
        {
            menuCatViewListBox.Items.Clear();   // Clear current view
            await getAllCategories();           // Repopulate view
        }

        // Method to populate category view
        private async Task getAllCategories()
        {
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
                    menuCatViewListBox.Items.Add(category);
                }
            }
        }

        // When Update Category button on View Categories tab is clicked..
        private void catUpdateButton_Click(object sender, EventArgs e)
        {
            MenuCategory menuCat = new MenuCategory();

            // Ensure an item has been selected
            if (menuCatViewListBox.SelectedItem == null) 
            {
                MessageBox.Show("Please select an item!");
                return;
            }
            menuCat = (MenuCategory) menuCatViewListBox.SelectedItem;
            // Switch tabs and populate form
            catUpdateIdField.Text = menuCat.CategoryId.ToString();
            catNameUpdateField.Text = menuCat.CategoryName.ToString();
            catUpdateDescRBox.Text = menuCat.CategoryDescription.ToString();
            tabControl1.SelectedIndex = 2;
        }

        // When Update Category button on Update Category tab is clicked ..
        private async void updateCatButton_Click(object sender, EventArgs e)
        {
            // Ensure required information is provided
            if (catUpdateIdField.Text == "" || !Char.IsDigit(catUpdateIdField.Text, 0))
            {
                MessageBox.Show("Please enter an id!");
                return;
            }
            // Pull information from the input form
            MenuCategory menuCat = new MenuCategory();
            menuCat.CategoryId = Int32.Parse(catUpdateIdField.Text);
            menuCat.CategoryName = catNameUpdateField.Text;
            menuCat.CategoryDescription = catUpdateDescRBox.Text;

            try
            {
                // Commit changr to database
                HttpResponseMessage response = await MainForm.client.PutAsJsonAsync($"api/MenuCategories/{catUpdateIdField.Text}", menuCat);
                response.EnsureSuccessStatusCode();
                menuCatViewListBox.Items.Clear();
                await getAllCategories();
                MessageBox.Show("Update Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        // When Delete Category button is clicked
        private async void catDeleteButton_Click(object sender, EventArgs e)
        {
            MenuCategory menuCat = new MenuCategory();
            // Ensure an item has been selected
            if (menuCatViewListBox.SelectedItem == null) 
            {
                MessageBox.Show("Please select an item");
                return;
            }
            // Pull needed information
            menuCat.CategoryId = ((MenuCategory) menuCatViewListBox.SelectedItem).CategoryId;

            try
            {
                // Commit change to database
                HttpResponseMessage response = await MainForm.client.DeleteAsync($"api/MenuCategories/{menuCat.CategoryId.ToString()}");
                response.EnsureSuccessStatusCode();
                menuCatViewListBox.Items.Clear();
                await getAllCategories();
                MessageBox.Show("Deletion Successful!");
            }
            catch (HttpRequestException error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
    }
}
