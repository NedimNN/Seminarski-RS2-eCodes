namespace eCodes.WinUI
{
    partial class MDIEmployees
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuShowOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.sellersToolStripMenuItem,
            this.myProfileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(158, 697);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuShowOrders});
            this.fileMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(141, 26);
            this.fileMenu.Text = "&Orders";
            // 
            // toolStripMenuShowOrders
            // 
            this.toolStripMenuShowOrders.Name = "toolStripMenuShowOrders";
            this.toolStripMenuShowOrders.Size = new System.Drawing.Size(194, 26);
            this.toolStripMenuShowOrders.Text = "Show Orders";
            this.toolStripMenuShowOrders.Click += new System.EventHandler(this.toolStripMenuShowOrders_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShowProducts,
            this.toolStripSeparator1});
            this.editMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(141, 26);
            this.editMenu.Text = "&Products";
            // 
            // toolStripShowProducts
            // 
            this.toolStripShowProducts.Name = "toolStripShowProducts";
            this.toolStripShowProducts.Size = new System.Drawing.Size(211, 26);
            this.toolStripShowProducts.Text = "Show Products";
            this.toolStripShowProducts.Click += new System.EventHandler(this.toolStripShowProducts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.myProfileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.myProfileToolStripMenuItem.Text = "&My Profile";
            this.myProfileToolStripMenuItem.Click += new System.EventHandler(this.myProfileToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(158, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(757, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // sellersToolStripMenuItem
            // 
            this.sellersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchSellersToolStripMenuItem,
            this.toolStripSeparator2});
            this.sellersToolStripMenuItem.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sellersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sellersToolStripMenuItem.Name = "sellersToolStripMenuItem";
            this.sellersToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.sellersToolStripMenuItem.Text = "&Sellers";
            // 
            // searchSellersToolStripMenuItem
            // 
            this.searchSellersToolStripMenuItem.Name = "searchSellersToolStripMenuItem";
            this.searchSellersToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.searchSellersToolStripMenuItem.Text = "Search Sellers";
            this.searchSellersToolStripMenuItem.Click += new System.EventHandler(this.searchSellersToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // MDIEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDIEmployees";
            this.Text = "eCodes Employees";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem toolStripMenuShowOrders;
        private ToolStripMenuItem toolStripShowProducts;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem myProfileToolStripMenuItem;
        private ToolStripMenuItem sellersToolStripMenuItem;
        private ToolStripMenuItem searchSellersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
    }
}



