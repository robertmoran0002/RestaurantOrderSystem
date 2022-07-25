namespace RestaurantOrderSystemForms
{
    partial class MenuForm
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
            this.viewMenuTab = new System.Windows.Forms.TabPage();
            this.menuViewListBox = new System.Windows.Forms.ListBox();
            this.menuDeleteButton = new System.Windows.Forms.Button();
            this.updateMenuButton = new System.Windows.Forms.Button();
            this.viewMenuButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addMenuTab = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.priceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.menuNotesRBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuPostButton = new System.Windows.Forms.Button();
            this.menuDescRBox = new System.Windows.Forms.RichTextBox();
            this.menuNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateMenuTab = new System.Windows.Forms.TabPage();
            this.backButton1 = new System.Windows.Forms.Button();
            this.menuIdUpBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuUpNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.menuUpCombo = new System.Windows.Forms.ComboBox();
            this.menuNotesUpRBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.menuUpdateButton = new System.Windows.Forms.Button();
            this.menuDescUpRBox = new System.Windows.Forms.RichTextBox();
            this.menuNameUpdateBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.deleteMenuTab = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.viewMenuTab.SuspendLayout();
            this.addMenuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).BeginInit();
            this.updateMenuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuUpNumeric)).BeginInit();
            this.deleteMenuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.viewMenuTab);
            this.tabControl1.Controls.Add(this.addMenuTab);
            this.tabControl1.Controls.Add(this.updateMenuTab);
            this.tabControl1.Controls.Add(this.deleteMenuTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1805, 939);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // viewMenuTab
            // 
            this.viewMenuTab.BackColor = System.Drawing.Color.LightSteelBlue;
            this.viewMenuTab.Controls.Add(this.menuViewListBox);
            this.viewMenuTab.Controls.Add(this.menuDeleteButton);
            this.viewMenuTab.Controls.Add(this.updateMenuButton);
            this.viewMenuTab.Controls.Add(this.viewMenuButton);
            this.viewMenuTab.Controls.Add(this.label6);
            this.viewMenuTab.Location = new System.Drawing.Point(4, 24);
            this.viewMenuTab.Name = "viewMenuTab";
            this.viewMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.viewMenuTab.Size = new System.Drawing.Size(1797, 911);
            this.viewMenuTab.TabIndex = 4;
            this.viewMenuTab.Text = "View Menu Items";
            // 
            // menuViewListBox
            // 
            this.menuViewListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuViewListBox.FormattingEnabled = true;
            this.menuViewListBox.HorizontalScrollbar = true;
            this.menuViewListBox.ItemHeight = 15;
            this.menuViewListBox.Location = new System.Drawing.Point(3, 109);
            this.menuViewListBox.Name = "menuViewListBox";
            this.menuViewListBox.Size = new System.Drawing.Size(1791, 799);
            this.menuViewListBox.TabIndex = 10;
            // 
            // menuDeleteButton
            // 
            this.menuDeleteButton.Location = new System.Drawing.Point(1017, 60);
            this.menuDeleteButton.Name = "menuDeleteButton";
            this.menuDeleteButton.Size = new System.Drawing.Size(118, 23);
            this.menuDeleteButton.TabIndex = 8;
            this.menuDeleteButton.Text = "Delete Item";
            this.menuDeleteButton.UseVisualStyleBackColor = true;
            this.menuDeleteButton.Click += new System.EventHandler(this.menuDeleteButton_ClickAsync);
            // 
            // updateMenuButton
            // 
            this.updateMenuButton.Location = new System.Drawing.Point(841, 60);
            this.updateMenuButton.Name = "updateMenuButton";
            this.updateMenuButton.Size = new System.Drawing.Size(118, 23);
            this.updateMenuButton.TabIndex = 7;
            this.updateMenuButton.Text = "Update Item";
            this.updateMenuButton.UseVisualStyleBackColor = true;
            this.updateMenuButton.Click += new System.EventHandler(this.updateMenuButton_Click);
            // 
            // viewMenuButton
            // 
            this.viewMenuButton.Location = new System.Drawing.Point(664, 60);
            this.viewMenuButton.Name = "viewMenuButton";
            this.viewMenuButton.Size = new System.Drawing.Size(118, 23);
            this.viewMenuButton.TabIndex = 5;
            this.viewMenuButton.Text = "View Menu";
            this.viewMenuButton.UseVisualStyleBackColor = true;
            this.viewMenuButton.Click += new System.EventHandler(this.viewMenuButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(46, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(255, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "View Menu Items";
            // 
            // addMenuTab
            // 
            this.addMenuTab.BackColor = System.Drawing.Color.LightGreen;
            this.addMenuTab.Controls.Add(this.label15);
            this.addMenuTab.Controls.Add(this.label14);
            this.addMenuTab.Controls.Add(this.priceNumeric);
            this.addMenuTab.Controls.Add(this.label13);
            this.addMenuTab.Controls.Add(this.categoryCombo);
            this.addMenuTab.Controls.Add(this.menuNotesRBox);
            this.addMenuTab.Controls.Add(this.label5);
            this.addMenuTab.Controls.Add(this.menuPostButton);
            this.addMenuTab.Controls.Add(this.menuDescRBox);
            this.addMenuTab.Controls.Add(this.menuNameBox);
            this.addMenuTab.Controls.Add(this.label3);
            this.addMenuTab.Controls.Add(this.label2);
            this.addMenuTab.Controls.Add(this.label1);
            this.addMenuTab.Location = new System.Drawing.Point(4, 24);
            this.addMenuTab.Name = "addMenuTab";
            this.addMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.addMenuTab.Size = new System.Drawing.Size(1797, 911);
            this.addMenuTab.TabIndex = 0;
            this.addMenuTab.Text = "Add Item";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(107, 440);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "Price:";
            // 
            // priceNumeric
            // 
            this.priceNumeric.DecimalPlaces = 2;
            this.priceNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.priceNumeric.Location = new System.Drawing.Point(165, 440);
            this.priceNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.priceNumeric.Name = "priceNumeric";
            this.priceNumeric.Size = new System.Drawing.Size(97, 23);
            this.priceNumeric.TabIndex = 11;
            this.priceNumeric.ThousandsSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(72, 401);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 21);
            this.label13.TabIndex = 10;
            this.label13.Text = "Category:";
            // 
            // categoryCombo
            // 
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Location = new System.Drawing.Point(162, 401);
            this.categoryCombo.MaxDropDownItems = 100;
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(150, 23);
            this.categoryCombo.Sorted = true;
            this.categoryCombo.TabIndex = 9;
            // 
            // menuNotesRBox
            // 
            this.menuNotesRBox.Location = new System.Drawing.Point(162, 284);
            this.menuNotesRBox.Name = "menuNotesRBox";
            this.menuNotesRBox.Size = new System.Drawing.Size(432, 96);
            this.menuNotesRBox.TabIndex = 7;
            this.menuNotesRBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(97, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Notes:";
            // 
            // menuPostButton
            // 
            this.menuPostButton.Location = new System.Drawing.Point(307, 502);
            this.menuPostButton.Name = "menuPostButton";
            this.menuPostButton.Size = new System.Drawing.Size(118, 23);
            this.menuPostButton.TabIndex = 5;
            this.menuPostButton.Text = "Add Item";
            this.menuPostButton.UseVisualStyleBackColor = true;
            this.menuPostButton.Click += new System.EventHandler(this.menuPostButton_Click);
            // 
            // menuDescRBox
            // 
            this.menuDescRBox.Location = new System.Drawing.Point(162, 165);
            this.menuDescRBox.Name = "menuDescRBox";
            this.menuDescRBox.Size = new System.Drawing.Size(432, 96);
            this.menuDescRBox.TabIndex = 4;
            this.menuDescRBox.Text = "";
            // 
            // menuNameBox
            // 
            this.menuNameBox.Location = new System.Drawing.Point(162, 122);
            this.menuNameBox.Name = "menuNameBox";
            this.menuNameBox.Size = new System.Drawing.Size(263, 23);
            this.menuNameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(54, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(97, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Item";
            // 
            // updateMenuTab
            // 
            this.updateMenuTab.BackColor = System.Drawing.Color.Wheat;
            this.updateMenuTab.Controls.Add(this.backButton1);
            this.updateMenuTab.Controls.Add(this.menuIdUpBox);
            this.updateMenuTab.Controls.Add(this.label18);
            this.updateMenuTab.Controls.Add(this.label4);
            this.updateMenuTab.Controls.Add(this.menuUpNumeric);
            this.updateMenuTab.Controls.Add(this.label7);
            this.updateMenuTab.Controls.Add(this.menuUpCombo);
            this.updateMenuTab.Controls.Add(this.menuNotesUpRBox);
            this.updateMenuTab.Controls.Add(this.label8);
            this.updateMenuTab.Controls.Add(this.menuUpdateButton);
            this.updateMenuTab.Controls.Add(this.menuDescUpRBox);
            this.updateMenuTab.Controls.Add(this.menuNameUpdateBox);
            this.updateMenuTab.Controls.Add(this.label16);
            this.updateMenuTab.Controls.Add(this.label17);
            this.updateMenuTab.Controls.Add(this.label9);
            this.updateMenuTab.Location = new System.Drawing.Point(4, 24);
            this.updateMenuTab.Name = "updateMenuTab";
            this.updateMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateMenuTab.Size = new System.Drawing.Size(1797, 911);
            this.updateMenuTab.TabIndex = 5;
            this.updateMenuTab.Text = "Update Item";
            // 
            // backButton1
            // 
            this.backButton1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.backButton1.Location = new System.Drawing.Point(480, 515);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(118, 23);
            this.backButton1.TabIndex = 26;
            this.backButton1.Text = "Back To View";
            this.backButton1.UseVisualStyleBackColor = false;
            this.backButton1.Click += new System.EventHandler(this.backButton1_Click);
            // 
            // menuIdUpBox
            // 
            this.menuIdUpBox.Location = new System.Drawing.Point(166, 100);
            this.menuIdUpBox.Name = "menuIdUpBox";
            this.menuIdUpBox.Size = new System.Drawing.Size(263, 23);
            this.menuIdUpBox.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(101, 100);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 21);
            this.label18.TabIndex = 24;
            this.label18.Text = "ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(111, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Price:";
            // 
            // menuUpNumeric
            // 
            this.menuUpNumeric.DecimalPlaces = 2;
            this.menuUpNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.menuUpNumeric.Location = new System.Drawing.Point(169, 456);
            this.menuUpNumeric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.menuUpNumeric.Name = "menuUpNumeric";
            this.menuUpNumeric.Size = new System.Drawing.Size(97, 23);
            this.menuUpNumeric.TabIndex = 22;
            this.menuUpNumeric.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(76, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Category:";
            // 
            // menuUpCombo
            // 
            this.menuUpCombo.FormattingEnabled = true;
            this.menuUpCombo.Location = new System.Drawing.Point(166, 417);
            this.menuUpCombo.MaxDropDownItems = 100;
            this.menuUpCombo.Name = "menuUpCombo";
            this.menuUpCombo.Size = new System.Drawing.Size(150, 23);
            this.menuUpCombo.Sorted = true;
            this.menuUpCombo.TabIndex = 20;
            // 
            // menuNotesUpRBox
            // 
            this.menuNotesUpRBox.Location = new System.Drawing.Point(166, 300);
            this.menuNotesUpRBox.Name = "menuNotesUpRBox";
            this.menuNotesUpRBox.Size = new System.Drawing.Size(432, 96);
            this.menuNotesUpRBox.TabIndex = 19;
            this.menuNotesUpRBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(101, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Notes:";
            // 
            // menuUpdateButton
            // 
            this.menuUpdateButton.BackColor = System.Drawing.Color.LawnGreen;
            this.menuUpdateButton.Location = new System.Drawing.Point(169, 515);
            this.menuUpdateButton.Name = "menuUpdateButton";
            this.menuUpdateButton.Size = new System.Drawing.Size(118, 23);
            this.menuUpdateButton.TabIndex = 17;
            this.menuUpdateButton.Text = "Update Item";
            this.menuUpdateButton.UseVisualStyleBackColor = false;
            this.menuUpdateButton.Click += new System.EventHandler(this.menuUpdateButton_Click);
            // 
            // menuDescUpRBox
            // 
            this.menuDescUpRBox.Location = new System.Drawing.Point(166, 181);
            this.menuDescUpRBox.Name = "menuDescUpRBox";
            this.menuDescUpRBox.Size = new System.Drawing.Size(432, 96);
            this.menuDescUpRBox.TabIndex = 16;
            this.menuDescUpRBox.Text = "";
            // 
            // menuNameUpdateBox
            // 
            this.menuNameUpdateBox.Location = new System.Drawing.Point(166, 138);
            this.menuNameUpdateBox.Name = "menuNameUpdateBox";
            this.menuNameUpdateBox.Size = new System.Drawing.Size(263, 23);
            this.menuNameUpdateBox.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(58, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 21);
            this.label16.TabIndex = 14;
            this.label16.Text = "Description:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(101, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 21);
            this.label17.TabIndex = 13;
            this.label17.Text = "Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(46, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 40);
            this.label9.TabIndex = 0;
            this.label9.Text = "Update Item";
            // 
            // deleteMenuTab
            // 
            this.deleteMenuTab.BackColor = System.Drawing.Color.MistyRose;
            this.deleteMenuTab.Controls.Add(this.button3);
            this.deleteMenuTab.Controls.Add(this.richTextBox3);
            this.deleteMenuTab.Controls.Add(this.textBox3);
            this.deleteMenuTab.Controls.Add(this.label10);
            this.deleteMenuTab.Controls.Add(this.label11);
            this.deleteMenuTab.Controls.Add(this.label12);
            this.deleteMenuTab.Location = new System.Drawing.Point(4, 24);
            this.deleteMenuTab.Name = "deleteMenuTab";
            this.deleteMenuTab.Padding = new System.Windows.Forms.Padding(3);
            this.deleteMenuTab.Size = new System.Drawing.Size(1797, 911);
            this.deleteMenuTab.TabIndex = 6;
            this.deleteMenuTab.Text = "Delete Item";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(307, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add Category";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(166, 222);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(432, 96);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(162, 122);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(263, 23);
            this.textBox3.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(46, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "Description:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(63, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(46, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(259, 40);
            this.label12.TabIndex = 0;
            this.label12.Text = "Delete Categories";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(584, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "label15";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1805, 939);
            this.Controls.Add(this.tabControl1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.tabControl1.ResumeLayout(false);
            this.viewMenuTab.ResumeLayout(false);
            this.viewMenuTab.PerformLayout();
            this.addMenuTab.ResumeLayout(false);
            this.addMenuTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumeric)).EndInit();
            this.updateMenuTab.ResumeLayout(false);
            this.updateMenuTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuUpNumeric)).EndInit();
            this.deleteMenuTab.ResumeLayout(false);
            this.deleteMenuTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage viewMenuTab;
        private ListBox menuViewListBox;
        private Button menuDeleteButton;
        private Button updateMenuButton;
        private Button viewMenuButton;
        private Label label6;
        private TabPage addMenuTab;
        private Button menuPostButton;
        private RichTextBox menuDescRBox;
        private TextBox menuNameBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage updateMenuTab;
        private Label label9;
        private TabPage deleteMenuTab;
        private Button button3;
        private RichTextBox richTextBox3;
        private TextBox textBox3;
        private Label label10;
        private Label label11;
        private Label label12;
        private RichTextBox menuNotesRBox;
        private Label label5;
        private Label label13;
        private ComboBox categoryCombo;
        private Label label14;
        private NumericUpDown priceNumeric;
        private Label label4;
        private NumericUpDown menuUpNumeric;
        private Label label7;
        private ComboBox menuUpCombo;
        private RichTextBox menuNotesUpRBox;
        private Label label8;
        private Button menuUpdateButton;
        private RichTextBox menuDescUpRBox;
        private TextBox menuNameUpdateBox;
        private Label label16;
        private Label label17;
        private TextBox menuIdUpBox;
        private Label label18;
        private Button backButton1;
        private Label label15;
    }
}