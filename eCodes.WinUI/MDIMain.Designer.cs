namespace eCodes.WinUI
{
    partial class MDIMain
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
            this.UserMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.searchProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSellers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripDropDownMenu();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.UserMenu,
            this.ProductMenu,
            this.sellersToolStripMenuItem,
            this.employeesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(158, 697);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // UserMenu
            // 
            this.UserMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchUsersToolStripMenuItem,
            this.toolStripSeparator1,
            this.addUserToolStripMenuItem});
            this.UserMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UserMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.UserMenu.Name = "UserMenu";
            this.UserMenu.Size = new System.Drawing.Size(102, 26);
            this.UserMenu.Text = "&Users";
            // 
            // searchUsersToolStripMenuItem
            // 
            this.searchUsersToolStripMenuItem.Name = "searchUsersToolStripMenuItem";
            this.searchUsersToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.searchUsersToolStripMenuItem.Text = "Search Users";
            this.searchUsersToolStripMenuItem.Click += new System.EventHandler(this.searchUsersToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // ProductMenu
            // 
            this.ProductMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchProductsToolStripMenuItem,
            this.toolStripSeparator2,
            this.addProductToolStripMenuItem});
            this.ProductMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProductMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductMenu.Name = "ProductMenu";
            this.ProductMenu.Size = new System.Drawing.Size(141, 26);
            this.ProductMenu.Text = "&Products";
            // 
            // searchProductsToolStripMenuItem
            // 
            this.searchProductsToolStripMenuItem.Name = "searchProductsToolStripMenuItem";
            this.searchProductsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.searchProductsToolStripMenuItem.Text = "Search Products";
            this.searchProductsToolStripMenuItem.Click += new System.EventHandler(this.searchProductsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // sellersToolStripMenuItem
            // 
            this.sellersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchSellers,
            this.toolStripSeparator3});
            this.sellersToolStripMenuItem.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sellersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sellersToolStripMenuItem.Name = "sellersToolStripMenuItem";
            this.sellersToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.sellersToolStripMenuItem.Text = "&Sellers";
            // 
            // searchSellers
            // 
            this.searchSellers.Name = "searchSellers";
            this.searchSellers.Size = new System.Drawing.Size(224, 26);
            this.searchSellers.Text = "Search Sellers";
            this.searchSellers.Click += new System.EventHandler(this.searchSellers_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchEmployeesToolStripMenuItem,
            this.toolStripSeparator4,
            this.addEmployeeToolStripMenuItem});
            this.employeesToolStripMenuItem.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.employeesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.employeesToolStripMenuItem.Text = "&Employees";
            // 
            // searchEmployeesToolStripMenuItem
            // 
            this.searchEmployeesToolStripMenuItem.Name = "searchEmployeesToolStripMenuItem";
            this.searchEmployeesToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.searchEmployeesToolStripMenuItem.Text = "Search Employees";
            this.searchEmployeesToolStripMenuItem.Click += new System.EventHandler(this.searchEmployeesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(233, 6);
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.addEmployeeToolStripMenuItem.Text = "Add Employee";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
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
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.AutoClose = false;
            this.newToolStripMenuItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(61, 4);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addProductToolStripMenuItem.Text = "Add Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // MDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDIMain";
            this.Text = "eCodes";
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
        private System.Windows.Forms.ToolStripMenuItem ProductMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem UserMenu;
        private ToolStripMenuItem searchUsersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private ToolStripMenuItem searchProductsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownMenu newToolStripMenuItem;
        private ToolStripMenuItem sellersToolStripMenuItem;
        private ToolStripMenuItem searchSellers;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem employeesToolStripMenuItem;
        private ToolStripMenuItem searchEmployeesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem addEmployeeToolStripMenuItem;
        private ToolStripMenuItem addProductToolStripMenuItem;
    }
}



