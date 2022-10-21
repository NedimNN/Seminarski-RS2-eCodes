namespace eCodes.WinUI
{
    partial class frmGenerateReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuyerUsername = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.errorProviderOutputs = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buyer Username:";
            // 
            // txtBuyerUsername
            // 
            this.txtBuyerUsername.Location = new System.Drawing.Point(12, 32);
            this.txtBuyerUsername.Name = "txtBuyerUsername";
            this.txtBuyerUsername.Size = new System.Drawing.Size(190, 27);
            this.txtBuyerUsername.TabIndex = 1;
            this.txtBuyerUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtBuyerUsername_Validating);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(250, 30);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(165, 29);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // errorProviderOutputs
            // 
            this.errorProviderOutputs.ContainerControl = this;
            // 
            // frmGenerateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtBuyerUsername);
            this.Controls.Add(this.label1);
            this.Name = "frmGenerateReport";
            this.Text = "frmGenerateReport";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOutputs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtBuyerUsername;
        private Button btnGenerate;
        private ErrorProvider errorProviderOutputs;
    }
}