namespace RestaurantOrderSystemForms
{
    partial class CategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.viewCatTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.menuCatViewListBox = new System.Windows.Forms.ListBox();
            this.catDeleteButton = new System.Windows.Forms.Button();
            this.catUpdateButton = new System.Windows.Forms.Button();
            this.viewCategoriesButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addCatTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.categoryPostButton = new System.Windows.Forms.Button();
            this.categoryDescRBox = new System.Windows.Forms.RichTextBox();
            this.categoryNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateCatTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.catNameUpdateField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updateCatButton = new System.Windows.Forms.Button();
            this.catUpdateDescRBox = new System.Windows.Forms.RichTextBox();
            this.catUpdateIdField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.viewCatTab.SuspendLayout();
            this.addCatTab.SuspendLayout();
            this.updateCatTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.viewCatTab);
            this.tabControl1.Controls.Add(this.addCatTab);
            this.tabControl1.Controls.Add(this.updateCatTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1793, 952);
            this.tabControl1.TabIndex = 0;
            // 
            // viewCatTab
            // 
            this.viewCatTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.viewCatTab.Controls.Add(this.label5);
            this.viewCatTab.Controls.Add(this.menuCatViewListBox);
            this.viewCatTab.Controls.Add(this.catDeleteButton);
            this.viewCatTab.Controls.Add(this.catUpdateButton);
            this.viewCatTab.Controls.Add(this.viewCategoriesButton);
            this.viewCatTab.Controls.Add(this.label6);
            this.viewCatTab.Location = new System.Drawing.Point(4, 24);
            this.viewCatTab.Name = "viewCatTab";
            this.viewCatTab.Padding = new System.Windows.Forms.Padding(3);
            this.viewCatTab.Size = new System.Drawing.Size(1785, 924);
            this.viewCatTab.TabIndex = 4;
            this.viewCatTab.Text = "View Categories";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(43, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 40);
            this.label5.TabIndex = 11;
            this.label5.Text = "View Categories";
            // 
            // menuCatViewListBox
            // 
            this.menuCatViewListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuCatViewListBox.FormattingEnabled = true;
            this.menuCatViewListBox.ItemHeight = 15;
            this.menuCatViewListBox.Location = new System.Drawing.Point(3, 107);
            this.menuCatViewListBox.Name = "menuCatViewListBox";
            this.menuCatViewListBox.Size = new System.Drawing.Size(1779, 814);
            this.menuCatViewListBox.TabIndex = 10;
            // 
            // catDeleteButton
            // 
            this.catDeleteButton.BackColor = System.Drawing.Color.Red;
            this.catDeleteButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.catDeleteButton.Location = new System.Drawing.Point(1018, 56);
            this.catDeleteButton.Name = "catDeleteButton";
            this.catDeleteButton.Size = new System.Drawing.Size(118, 23);
            this.catDeleteButton.TabIndex = 8;
            this.catDeleteButton.Text = "Delete Category";
            this.catDeleteButton.UseVisualStyleBackColor = false;
            this.catDeleteButton.Click += new System.EventHandler(this.catDeleteButton_Click);
            // 
            // catUpdateButton
            // 
            this.catUpdateButton.BackColor = System.Drawing.Color.Gold;
            this.catUpdateButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.catUpdateButton.Location = new System.Drawing.Point(842, 56);
            this.catUpdateButton.Name = "catUpdateButton";
            this.catUpdateButton.Size = new System.Drawing.Size(118, 23);
            this.catUpdateButton.TabIndex = 7;
            this.catUpdateButton.Text = "Update Category";
            this.catUpdateButton.UseVisualStyleBackColor = false;
            this.catUpdateButton.Click += new System.EventHandler(this.catUpdateButton_Click);
            // 
            // viewCategoriesButton
            // 
            this.viewCategoriesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.viewCategoriesButton.Location = new System.Drawing.Point(665, 56);
            this.viewCategoriesButton.Name = "viewCategoriesButton";
            this.viewCategoriesButton.Size = new System.Drawing.Size(118, 23);
            this.viewCategoriesButton.TabIndex = 5;
            this.viewCategoriesButton.Text = "View Categories";
            this.viewCategoriesButton.UseVisualStyleBackColor = true;
            this.viewCategoriesButton.Click += new System.EventHandler(this.viewCategoriesButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(43, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 40);
            this.label6.TabIndex = 0;
            // 
            // addCatTab
            // 
            this.addCatTab.BackColor = System.Drawing.Color.LightGreen;
            this.addCatTab.Controls.Add(this.button1);
            this.addCatTab.Controls.Add(this.categoryPostButton);
            this.addCatTab.Controls.Add(this.categoryDescRBox);
            this.addCatTab.Controls.Add(this.categoryNameBox);
            this.addCatTab.Controls.Add(this.label3);
            this.addCatTab.Controls.Add(this.label2);
            this.addCatTab.Controls.Add(this.label1);
            this.addCatTab.Location = new System.Drawing.Point(4, 24);
            this.addCatTab.Name = "addCatTab";
            this.addCatTab.Padding = new System.Windows.Forms.Padding(3);
            this.addCatTab.Size = new System.Drawing.Size(1785, 924);
            this.addCatTab.TabIndex = 0;
            this.addCatTab.Text = "Add Categories";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(491, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Back to View";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // categoryPostButton
            // 
            this.categoryPostButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.categoryPostButton.Location = new System.Drawing.Point(162, 348);
            this.categoryPostButton.Name = "categoryPostButton";
            this.categoryPostButton.Size = new System.Drawing.Size(118, 23);
            this.categoryPostButton.TabIndex = 5;
            this.categoryPostButton.Text = "Add Category";
            this.categoryPostButton.UseVisualStyleBackColor = true;
            this.categoryPostButton.Click += new System.EventHandler(this.categoryPostButton_Click);
            // 
            // categoryDescRBox
            // 
            this.categoryDescRBox.Location = new System.Drawing.Point(166, 222);
            this.categoryDescRBox.Name = "categoryDescRBox";
            this.categoryDescRBox.Size = new System.Drawing.Size(432, 96);
            this.categoryDescRBox.TabIndex = 4;
            this.categoryDescRBox.Text = "";
            // 
            // categoryNameBox
            // 
            this.categoryNameBox.Location = new System.Drawing.Point(162, 122);
            this.categoryNameBox.Name = "categoryNameBox";
            this.categoryNameBox.Size = new System.Drawing.Size(263, 23);
            this.categoryNameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(43, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(85, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Categories";
            // 
            // updateCatTab
            // 
            this.updateCatTab.BackColor = System.Drawing.Color.Wheat;
            this.updateCatTab.Controls.Add(this.button2);
            this.updateCatTab.Controls.Add(this.catNameUpdateField);
            this.updateCatTab.Controls.Add(this.label4);
            this.updateCatTab.Controls.Add(this.updateCatButton);
            this.updateCatTab.Controls.Add(this.catUpdateDescRBox);
            this.updateCatTab.Controls.Add(this.catUpdateIdField);
            this.updateCatTab.Controls.Add(this.label7);
            this.updateCatTab.Controls.Add(this.label8);
            this.updateCatTab.Controls.Add(this.label9);
            this.updateCatTab.Location = new System.Drawing.Point(4, 24);
            this.updateCatTab.Name = "updateCatTab";
            this.updateCatTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateCatTab.Size = new System.Drawing.Size(1785, 924);
            this.updateCatTab.TabIndex = 5;
            this.updateCatTab.Text = "Update Categories";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(491, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Back to View";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // catNameUpdateField
            // 
            this.catNameUpdateField.Location = new System.Drawing.Point(166, 165);
            this.catNameUpdateField.Name = "catNameUpdateField";
            this.catNameUpdateField.Size = new System.Drawing.Size(263, 23);
            this.catNameUpdateField.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(100, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // updateCatButton
            // 
            this.updateCatButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.updateCatButton.Location = new System.Drawing.Point(166, 348);
            this.updateCatButton.Name = "updateCatButton";
            this.updateCatButton.Size = new System.Drawing.Size(118, 23);
            this.updateCatButton.TabIndex = 6;
            this.updateCatButton.Text = "Update Category";
            this.updateCatButton.UseVisualStyleBackColor = true;
            this.updateCatButton.Click += new System.EventHandler(this.updateCatButton_Click);
            // 
            // catUpdateDescRBox
            // 
            this.catUpdateDescRBox.Location = new System.Drawing.Point(166, 222);
            this.catUpdateDescRBox.Name = "catUpdateDescRBox";
            this.catUpdateDescRBox.Size = new System.Drawing.Size(432, 96);
            this.catUpdateDescRBox.TabIndex = 5;
            this.catUpdateDescRBox.Text = "";
            // 
            // catUpdateIdField
            // 
            this.catUpdateIdField.Location = new System.Drawing.Point(166, 122);
            this.catUpdateIdField.Name = "catUpdateIdField";
            this.catUpdateIdField.Size = new System.Drawing.Size(263, 23);
            this.catUpdateIdField.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(58, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(129, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(43, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 40);
            this.label9.TabIndex = 0;
            this.label9.Text = "Update Categories";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1793, 952);
            this.Controls.Add(this.tabControl1);
            this.Name = "CategoryForm";
            this.Text = "Category Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.CategoryForm_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.viewCatTab.ResumeLayout(false);
            this.viewCatTab.PerformLayout();
            this.addCatTab.ResumeLayout(false);
            this.addCatTab.PerformLayout();
            this.updateCatTab.ResumeLayout(false);
            this.updateCatTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage addCatTab;
        private Button categoryPostButton;
        private RichTextBox categoryDescRBox;
        private TextBox categoryNameBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage updateCatTab;
        private Button updateCatButton;
        private RichTextBox catUpdateDescRBox;
        private TextBox catUpdateIdField;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox catNameUpdateField;
        private Label label4;
        private TabPage viewCatTab;
        private ListBox menuCatViewListBox;
        private Button catDeleteButton;
        private Button catUpdateButton;
        private Button viewCategoriesButton;
        private Label label6;
        private Label label5;
        private Button button1;
        private Button button2;
    }
}