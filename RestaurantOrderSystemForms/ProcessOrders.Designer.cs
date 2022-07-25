namespace RestaurantOrderSystemForms
{
    partial class ProcessOrders
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.orderQueue = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.completeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // orderQueue
            // 
            this.orderQueue.Dock = System.Windows.Forms.DockStyle.Left;
            this.orderQueue.FormattingEnabled = true;
            this.orderQueue.HorizontalScrollbar = true;
            this.orderQueue.ItemHeight = 15;
            this.orderQueue.Location = new System.Drawing.Point(0, 0);
            this.orderQueue.Name = "orderQueue";
            this.orderQueue.Size = new System.Drawing.Size(1374, 880);
            this.orderQueue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1404, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kitchen Orders";
            // 
            // completeButton
            // 
            this.completeButton.BackColor = System.Drawing.Color.Lime;
            this.completeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.completeButton.Location = new System.Drawing.Point(1404, 110);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(122, 47);
            this.completeButton.TabIndex = 2;
            this.completeButton.Text = "COMPLETE";
            this.completeButton.UseVisualStyleBackColor = false;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Red;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.Location = new System.Drawing.Point(1404, 298);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(122, 47);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1414, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "(Prioritize orders at the top of the list)";
            // 
            // ProcessOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1767, 880);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderQueue);
            this.Name = "ProcessOrders";
            this.Text = "Process Orders (Kitchen)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeEnd += new System.EventHandler(this.ProcessOrders_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.ProcessOrders_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private ListBox orderQueue;
        private Label label1;
        private Button completeButton;
        private Button cancelButton;
        private Label label2;
    }
}