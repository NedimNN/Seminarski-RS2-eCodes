using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCodes.WinUI
{
    public partial class frmGenerateReport : Form
    {
        public APIService OutputService { get; set; } = new APIService("Output");

        public frmGenerateReport()
        {
            InitializeComponent();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                var output = new OutputSearchObject();
                output.BuyerName = txtBuyerUsername.Text;
                output.Include = true;
                var outputs = await OutputService.Get<List<Models.Outputs>>(output);
                if(outputs.FirstOrDefault() != null) 
                {
                    frmReport report = new frmReport(outputs);
                    report.WindowState = FormWindowState.Normal;
                    report.Show();
                }
                else
                {
                    MessageBox.Show("This buyer has no transactions yet!", "Report Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtBuyerUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuyerUsername.Text))
            {
                e.Cancel = true;
                txtBuyerUsername.Focus();
                errorProviderOutputs.SetError(txtBuyerUsername, "Buyer Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderOutputs.SetError(txtBuyerUsername, "");
            }
        }
    }
}
