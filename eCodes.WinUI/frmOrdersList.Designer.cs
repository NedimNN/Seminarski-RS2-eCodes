namespace eCodes.WinUI
{
    partial class frmOrdersList
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeOrderDate = new System.Windows.Forms.DateTimePicker();
            this.cbCanceled = new System.Windows.Forms.CheckBox();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.btnShowOrders = new System.Windows.Forms.Button();
            this.txtBuyerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Number:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(68, 32);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(155, 27);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Date:";
            // 
            // dateTimeOrderDate
            // 
            this.dateTimeOrderDate.Location = new System.Drawing.Point(307, 32);
            this.dateTimeOrderDate.Name = "dateTimeOrderDate";
            this.dateTimeOrderDate.Size = new System.Drawing.Size(250, 27);
            this.dateTimeOrderDate.TabIndex = 3;
            // 
            // cbCanceled
            // 
            this.cbCanceled.AutoSize = true;
            this.cbCanceled.Location = new System.Drawing.Point(626, 34);
            this.cbCanceled.Name = "cbCanceled";
            this.cbCanceled.Size = new System.Drawing.Size(92, 24);
            this.cbCanceled.TabIndex = 5;
            this.cbCanceled.Text = "Canceled";
            this.cbCanceled.UseVisualStyleBackColor = true;
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AllowUserToAddRows = false;
            this.dgvOrderList.AllowUserToDeleteRows = false;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.BuyerName,
            this.Date,
            this.Price,
            this.Status,
            this.Cancel});
            this.dgvOrderList.Location = new System.Drawing.Point(12, 118);
            this.dgvOrderList.MultiSelect = false;
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.RowHeadersWidth = 51;
            this.dgvOrderList.RowTemplate.Height = 29;
            this.dgvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderList.Size = new System.Drawing.Size(948, 343);
            this.dgvOrderList.TabIndex = 6;
            this.dgvOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellClick);
            this.dgvOrderList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellContentDoubleClick);
            // 
            // btnShowOrders
            // 
            this.btnShowOrders.Location = new System.Drawing.Point(767, 83);
            this.btnShowOrders.Name = "btnShowOrders";
            this.btnShowOrders.Size = new System.Drawing.Size(94, 29);
            this.btnShowOrders.TabIndex = 7;
            this.btnShowOrders.Text = "Show";
            this.btnShowOrders.UseVisualStyleBackColor = true;
            this.btnShowOrders.Click += new System.EventHandler(this.btnShowOrders_Click);
            // 
            // txtBuyerName
            // 
            this.txtBuyerName.Location = new System.Drawing.Point(68, 85);
            this.txtBuyerName.Name = "txtBuyerName";
            this.txtBuyerName.Size = new System.Drawing.Size(155, 27);
            this.txtBuyerName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buyer Username:";
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Order Number";
            this.OrderNumber.MinimumWidth = 6;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Width = 125;
            // 
            // BuyerName
            // 
            this.BuyerName.DataPropertyName = "BuyerName";
            this.BuyerName.HeaderText = "Buyer";
            this.BuyerName.MinimumWidth = 6;
            this.BuyerName.Name = "BuyerName";
            this.BuyerName.ReadOnly = true;
            this.BuyerName.Width = 125;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date of order";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 118;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 125;
            // 
            // Cancel
            // 
            this.Cancel.DataPropertyName = "Canceled";
            this.Cancel.HeaderText = "Cancel";
            this.Cancel.MinimumWidth = 6;
            this.Cancel.Name = "Cancel";
            this.Cancel.ReadOnly = true;
            this.Cancel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cancel.Width = 125;
            // 
            // frmOrdersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 466);
            this.Controls.Add(this.txtBuyerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowOrders);
            this.Controls.Add(this.dgvOrderList);
            this.Controls.Add(this.cbCanceled);
            this.Controls.Add(this.dateTimeOrderDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmOrdersList";
            this.Text = "Orders List";
            this.Load += new System.EventHandler(this.frmOrdersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtOrderNumber;
        private Label label2;
        private DateTimePicker dateTimeOrderDate;
        private CheckBox cbCanceled;
        private DataGridView dgvOrderList;
        private Button btnShowOrders;
        private TextBox txtBuyerName;
        private Label label3;
        private DataGridViewTextBoxColumn OrderNumber;
        private DataGridViewTextBoxColumn BuyerName;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewCheckBoxColumn Status;
        private DataGridViewCheckBoxColumn Cancel;
    }
}