namespace eCodes.WinUI
{
    partial class frmReport
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
            this.rVReports = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rVReports
            // 
            this.rVReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rVReports.Location = new System.Drawing.Point(0, 0);
            this.rVReports.Name = "ReportViewer";
            this.rVReports.ServerReport.BearerToken = null;
            this.rVReports.Size = new System.Drawing.Size(839, 663);
            this.rVReports.TabIndex = 0;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 663);
            this.Controls.Add(this.rVReports);
            this.Name = "frmReport";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rVReports;
    }
}