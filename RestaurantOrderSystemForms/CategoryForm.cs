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

        private async void categoryPostButton_Click(object sender, EventArgs e)
        {

            MenuCategory menuCat = new MenuCategory();
            menuCat.CategoryName = categoryNameBox.Text;
            menuCat.CategoryDescription = categoryDescRBox.Text;


            try
            {
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

        private async void viewCategoriesButton_Click(object sender, EventArgs e)
        {
            menuCatViewListBox.Items.Clear();
            await getAllCategories();
        }

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
                    menuCatViewListBox.Items.Add($"Id: {category.CategoryId} \t\t Name: {category.CategoryName} \t\t Description: {category.CategoryDescription}");
                }
            }
        }

        private void catUpdateButton_Click(object sender, EventArgs e)
        {
            MenuCategory menuCat = new MenuCategory();
            if (menuCatViewListBox.SelectedItem == null) 
            {
                MessageBox.Show("Please select an item!");
                return;
            }

            menuCat.CategoryId = Int32.Parse(menuCatViewListBox.SelectedItem.ToString().Trim()
                .Remove(menuCatViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));
            menuCat.CategoryName = menuCatViewListBox.SelectedItem.ToString().Trim()
                .Remove(menuCatViewListBox.SelectedItem.ToString().LastIndexOf("Description:"));
            menuCat.CategoryName = menuCat.CategoryName
                .Remove(0, menuCatViewListBox.SelectedItem.ToString().IndexOf("Name:") + "Name: ".Length).Trim();
            menuCat.CategoryDescription = menuCatViewListBox.SelectedItem.ToString().Trim()
                .Remove(0, menuCatViewListBox.SelectedItem.ToString().LastIndexOf(":")).Substring(2);


            catUpdateIdField.Text = menuCat.CategoryId.ToString();
            catNameUpdateField.Text = menuCat.CategoryName.ToString();
            catUpdateDescRBox.Text = menuCat.CategoryDescription.ToString();
            tabControl1.SelectedIndex = 2;
        }

        private async void updateCatButton_Click(object sender, EventArgs e)
        {
            if (catUpdateIdField.Text == "" || !Char.IsDigit(catUpdateIdField.Text, 0))
            {
                MessageBox.Show("Please enter an id!");
                return;
            }
            MenuCategory menuCat = new MenuCategory();
            menuCat.CategoryId = Int32.Parse(catUpdateIdField.Text);
            menuCat.CategoryName = catNameUpdateField.Text;
            menuCat.CategoryDescription = catUpdateDescRBox.Text;

            try
            {
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

        private async void catDeleteButton_Click(object sender, EventArgs e)
        {
            MenuCategory menuCat = new MenuCategory();

            if (menuCatViewListBox.SelectedItem == null) 
            {
                MessageBox.Show("Please select an item");
                return;
            }
            menuCat.CategoryId = Int32.Parse(menuCatViewListBox.SelectedItem.ToString().Trim()
                .Remove(menuCatViewListBox.SelectedItem.ToString().IndexOf("N")).Substring("Id:".Length));

            try
            {
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

    internal record struct NewStruct(object Item1, object Item2)
    {
        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
