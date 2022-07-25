namespace RestaurantOrderSystemForms
{
    partial class NewOrder
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
            this.orderSelectTab = new System.Windows.Forms.TabPage();
            this.toPayButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.reviewButton = new System.Windows.Forms.Button();
            this.orderViewListBox = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.menuButton = new System.Windows.Forms.Button();
            this.menuViewListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paymentTab = new System.Windows.Forms.TabPage();
            this.tipNumeric = new System.Windows.Forms.NumericUpDown();
            this.toOrderButton = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.taxBox = new System.Windows.Forms.TextBox();
            this.creditCardBox = new System.Windows.Forms.TextBox();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.methodCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.payOrderInfoBox = new System.Windows.Forms.ListBox();
            this.refreshPayButton = new System.Windows.Forms.Button();
            this.payOrderListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.orderSelectTab.SuspendLayout();
            this.paymentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.orderSelectTab);
            this.tabControl1.Controls.Add(this.paymentTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1809, 940);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // orderSelectTab
            // 
            this.orderSelectTab.BackColor = System.Drawing.Color.Silver;
            this.orderSelectTab.Controls.Add(this.toPayButton);
            this.orderSelectTab.Controls.Add(this.label4);
            this.orderSelectTab.Controls.Add(this.totalBox);
            this.orderSelectTab.Controls.Add(this.reviewButton);
            this.orderSelectTab.Controls.Add(this.orderViewListBox);
            this.orderSelectTab.Controls.Add(this.removeButton);
            this.orderSelectTab.Controls.Add(this.addButton);
            this.orderSelectTab.Controls.Add(this.label2);
            this.orderSelectTab.Controls.Add(this.quantityBox);
            this.orderSelectTab.Controls.Add(this.menuButton);
            this.orderSelectTab.Controls.Add(this.menuViewListBox);
            this.orderSelectTab.Controls.Add(this.label1);
            this.orderSelectTab.Location = new System.Drawing.Point(4, 24);
            this.orderSelectTab.Name = "orderSelectTab";
            this.orderSelectTab.Padding = new System.Windows.Forms.Padding(3);
            this.orderSelectTab.Size = new System.Drawing.Size(1801, 912);
            this.orderSelectTab.TabIndex = 0;
            this.orderSelectTab.Text = "Order Selection";
            this.orderSelectTab.Click += new System.EventHandler(this.orderSelectTab_Click);
            // 
            // toPayButton
            // 
            this.toPayButton.BackColor = System.Drawing.Color.Orange;
            this.toPayButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toPayButton.Location = new System.Drawing.Point(1221, 19);
            this.toPayButton.Name = "toPayButton";
            this.toPayButton.Size = new System.Drawing.Size(98, 61);
            this.toPayButton.TabIndex = 11;
            this.toPayButton.Text = "To Payment";
            this.toPayButton.UseVisualStyleBackColor = false;
            this.toPayButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1578, 692);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total:";
            // 
            // totalBox
            // 
            this.totalBox.Enabled = false;
            this.totalBox.Location = new System.Drawing.Point(1636, 692);
            this.totalBox.Name = "totalBox";
            this.totalBox.Size = new System.Drawing.Size(100, 23);
            this.totalBox.TabIndex = 9;
            // 
            // reviewButton
            // 
            this.reviewButton.BackColor = System.Drawing.Color.Yellow;
            this.reviewButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.reviewButton.Location = new System.Drawing.Point(1640, 758);
            this.reviewButton.Name = "reviewButton";
            this.reviewButton.Size = new System.Drawing.Size(96, 61);
            this.reviewButton.TabIndex = 8;
            this.reviewButton.Text = "Submit Order";
            this.reviewButton.UseVisualStyleBackColor = false;
            this.reviewButton.Click += new System.EventHandler(this.reviewButton_Click);
            // 
            // orderViewListBox
            // 
            this.orderViewListBox.FormattingEnabled = true;
            this.orderViewListBox.HorizontalScrollbar = true;
            this.orderViewListBox.ItemHeight = 15;
            this.orderViewListBox.Location = new System.Drawing.Point(1350, 163);
            this.orderViewListBox.Name = "orderViewListBox";
            this.orderViewListBox.Size = new System.Drawing.Size(386, 514);
            this.orderViewListBox.TabIndex = 7;
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.OrangeRed;
            this.removeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.removeButton.Location = new System.Drawing.Point(1350, 758);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(96, 61);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove Item";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.LawnGreen;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(1466, 111);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 32);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1350, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity:";
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(1350, 119);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(100, 23);
            this.quantityBox.TabIndex = 3;
            this.quantityBox.Text = "1";
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuButton.Location = new System.Drawing.Point(309, 19);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(98, 61);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Refresh Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // menuViewListBox
            // 
            this.menuViewListBox.FormattingEnabled = true;
            this.menuViewListBox.HorizontalScrollbar = true;
            this.menuViewListBox.ItemHeight = 15;
            this.menuViewListBox.Location = new System.Drawing.Point(40, 95);
            this.menuViewListBox.Name = "menuViewListBox";
            this.menuViewListBox.Size = new System.Drawing.Size(1279, 769);
            this.menuViewListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Selection";
            // 
            // paymentTab
            // 
            this.paymentTab.BackColor = System.Drawing.Color.Silver;
            this.paymentTab.Controls.Add(this.tipNumeric);
            this.paymentTab.Controls.Add(this.toOrderButton);
            this.paymentTab.Controls.Add(this.submit);
            this.paymentTab.Controls.Add(this.label10);
            this.paymentTab.Controls.Add(this.label9);
            this.paymentTab.Controls.Add(this.label8);
            this.paymentTab.Controls.Add(this.label7);
            this.paymentTab.Controls.Add(this.label6);
            this.paymentTab.Controls.Add(this.taxBox);
            this.paymentTab.Controls.Add(this.creditCardBox);
            this.paymentTab.Controls.Add(this.amountBox);
            this.paymentTab.Controls.Add(this.methodCombo);
            this.paymentTab.Controls.Add(this.label5);
            this.paymentTab.Controls.Add(this.payOrderInfoBox);
            this.paymentTab.Controls.Add(this.refreshPayButton);
            this.paymentTab.Controls.Add(this.payOrderListBox);
            this.paymentTab.Controls.Add(this.label3);
            this.paymentTab.Location = new System.Drawing.Point(4, 24);
            this.paymentTab.Name = "paymentTab";
            this.paymentTab.Padding = new System.Windows.Forms.Padding(3);
            this.paymentTab.Size = new System.Drawing.Size(1801, 912);
            this.paymentTab.TabIndex = 1;
            this.paymentTab.Text = "Payment";
            // 
            // tipNumeric
            // 
            this.tipNumeric.DecimalPlaces = 2;
            this.tipNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tipNumeric.Location = new System.Drawing.Point(1338, 299);
            this.tipNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tipNumeric.Name = "tipNumeric";
            this.tipNumeric.Size = new System.Drawing.Size(120, 23);
            this.tipNumeric.TabIndex = 18;
            this.tipNumeric.Click += new System.EventHandler(this.tipNumeric_Click);
            this.tipNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tipNumeric_KeyUp);
            // 
            // toOrderButton
            // 
            this.toOrderButton.BackColor = System.Drawing.Color.Orange;
            this.toOrderButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toOrderButton.Location = new System.Drawing.Point(615, 18);
            this.toOrderButton.Name = "toOrderButton";
            this.toOrderButton.Size = new System.Drawing.Size(98, 61);
            this.toOrderButton.TabIndex = 17;
            this.toOrderButton.Text = "To Order Selection";
            this.toOrderButton.UseVisualStyleBackColor = false;
            this.toOrderButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.Lime;
            this.submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.submit.Location = new System.Drawing.Point(1338, 405);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(83, 35);
            this.submit.TabIndex = 16;
            this.submit.Text = "Submit Payment";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(1338, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(1338, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tip";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(1338, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1338, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Credit Card #";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(1338, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Payment Method";
            // 
            // taxBox
            // 
            this.taxBox.Location = new System.Drawing.Point(1338, 253);
            this.taxBox.Name = "taxBox";
            this.taxBox.ReadOnly = true;
            this.taxBox.Size = new System.Drawing.Size(100, 23);
            this.taxBox.TabIndex = 10;
            // 
            // creditCardBox
            // 
            this.creditCardBox.Location = new System.Drawing.Point(1338, 178);
            this.creditCardBox.Name = "creditCardBox";
            this.creditCardBox.Size = new System.Drawing.Size(151, 23);
            this.creditCardBox.TabIndex = 9;
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(1338, 358);
            this.amountBox.Name = "amountBox";
            this.amountBox.ReadOnly = true;
            this.amountBox.Size = new System.Drawing.Size(100, 23);
            this.amountBox.TabIndex = 7;
            // 
            // methodCombo
            // 
            this.methodCombo.FormattingEnabled = true;
            this.methodCombo.Location = new System.Drawing.Point(1338, 117);
            this.methodCombo.Name = "methodCombo";
            this.methodCombo.Size = new System.Drawing.Size(121, 23);
            this.methodCombo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(916, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 47);
            this.label5.TabIndex = 5;
            this.label5.Text = "Info";
            // 
            // payOrderInfoBox
            // 
            this.payOrderInfoBox.BackColor = System.Drawing.SystemColors.Info;
            this.payOrderInfoBox.FormattingEnabled = true;
            this.payOrderInfoBox.HorizontalScrollbar = true;
            this.payOrderInfoBox.ItemHeight = 15;
            this.payOrderInfoBox.Location = new System.Drawing.Point(740, 94);
            this.payOrderInfoBox.Name = "payOrderInfoBox";
            this.payOrderInfoBox.Size = new System.Drawing.Size(577, 619);
            this.payOrderInfoBox.TabIndex = 4;
            // 
            // refreshPayButton
            // 
            this.refreshPayButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.refreshPayButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.refreshPayButton.Location = new System.Drawing.Point(197, 19);
            this.refreshPayButton.Name = "refreshPayButton";
            this.refreshPayButton.Size = new System.Drawing.Size(98, 61);
            this.refreshPayButton.TabIndex = 3;
            this.refreshPayButton.Text = "Refresh Payments";
            this.refreshPayButton.UseVisualStyleBackColor = false;
            this.refreshPayButton.Click += new System.EventHandler(this.refreshPayButton_Click);
            // 
            // payOrderListBox
            // 
            this.payOrderListBox.FormattingEnabled = true;
            this.payOrderListBox.ItemHeight = 15;
            this.payOrderListBox.Location = new System.Drawing.Point(26, 94);
            this.payOrderListBox.Name = "payOrderListBox";
            this.payOrderListBox.Size = new System.Drawing.Size(687, 619);
            this.payOrderListBox.TabIndex = 2;
            this.payOrderListBox.Click += new System.EventHandler(this.payOrderListBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 47);
            this.label3.TabIndex = 1;
            this.label3.Text = "Payment";
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1809, 940);
            this.Controls.Add(this.tabControl1);
            this.Name = "NewOrder";
            this.Text = "Order and Payment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.NewOrder_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.orderSelectTab.ResumeLayout(false);
            this.orderSelectTab.PerformLayout();
            this.paymentTab.ResumeLayout(false);
            this.paymentTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage orderSelectTab;
        private ListBox menuViewListBox;
        private Label label1;
        private TabPage paymentTab;
        private Button menuButton;
        private Button reviewButton;
        private ListBox orderViewListBox;
        private Button removeButton;
        private Button addButton;
        private Label label2;
        private TextBox quantityBox;
        private ListBox payOrderListBox;
        private Label label3;
        private Label label4;
        private TextBox totalBox;
        private Button refreshPayButton;
        private Label label5;
        private ListBox payOrderInfoBox;
        private TextBox creditCardBox;
        private TextBox amountBox;
        private ComboBox methodCombo;
        private Button submit;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox taxBox;
        private Button toPayButton;
        private Button toOrderButton;
        private NumericUpDown tipNumeric;
    }
}