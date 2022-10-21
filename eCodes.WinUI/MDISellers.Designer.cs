namespace eCodes.WinUI
{
    partial class MDISellers
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
            this.menuSearchProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.requestAccountDeletionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.editProfileMenu,
            this.requestAccountDeletionToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
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
            this.menuSearchProducts,
            this.toolStripSeparator1,
            this.menuAddProducts});
            this.fileMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fileMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(141, 26);
            this.fileMenu.Text = "&Products";
            // 
            // menuSearchProducts
            // 
            this.menuSearchProducts.Name = "menuSearchProducts";
            this.menuSearchProducts.Size = new System.Drawing.Size(224, 26);
            this.menuSearchProducts.Text = "My Products";
            this.menuSearchProducts.Click += new System.EventHandler(this.menuSearchProducts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuAddProducts
            // 
            this.menuAddProducts.Name = "menuAddProducts";
            this.menuAddProducts.Size = new System.Drawing.Size(224, 26);
            this.menuAddProducts.Text = "Add Products";
            this.menuAddProducts.Click += new System.EventHandler(this.menuAddProducts_Click);
            // 
            // editProfileMenu
            // 
            this.editProfileMenu.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.editProfileMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editProfileMenu.Name = "editProfileMenu";
            this.editProfileMenu.Size = new System.Drawing.Size(141, 26);
            this.editProfileMenu.Text = "&Edit Profile";
            this.editProfileMenu.Click += new System.EventHandler(this.editProfileMenu_Click);
            // 
            // requestAccountDeletionToolStripMenuItem
            // 
            this.requestAccountDeletionToolStripMenuItem.Font = new System.Drawing.Font("Tempus Sans ITC", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.requestAccountDeletionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.requestAccountDeletionToolStripMenuItem.Name = "requestAccountDeletionToolStripMenuItem";
            this.requestAccountDeletionToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.requestAccountDeletionToolStripMenuItem.Text = "&Delete Account";
            this.requestAccountDeletionToolStripMenuItem.Click += new System.EventHandler(this.requestAccountDeletionToolStripMenuItem_ClickAsync);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(158, 671);
            this.statusStrip.MinimumSize = new System.Drawing.Size(720, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(722, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MDISellers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MDISellers";
            this.Text = "eCodes Sellers";
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
        private System.Windows.Forms.ToolStripMenuItem editProfileMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem menuSearchProducts;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuAddProducts;
        private ToolStripMenuItem requestAccountDeletionToolStripMenuItem;
    }
}



