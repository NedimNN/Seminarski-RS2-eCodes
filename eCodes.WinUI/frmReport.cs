using eCodes.Models;
using eCodes.WinUI.ReportModels.DataSets;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReport : Form
    {


        private List<Outputs> _model = null;
        public frmReport(List<Outputs> model = null)
        {
            InitializeComponent();
            _model = model;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            rVReports.LocalReport.ReportEmbeddedResource = "eCodes.WinUI.ReportModels.rptTransactions.rdlc";

            var parameter = new ReportParameter("BuyerName", _model.FirstOrDefault().FirstName + " " + _model.FirstOrDefault().LastName);


            var tblOutputs = new dsTransactions.OutputsDataTable();
            var rb = 1;
            string concluded;
            foreach (var item in _model)
            {
                concluded = "No";
                if (item.Concluded == true)
                    concluded = "Yes";
                var row = tblOutputs.NewOutputsRow();
                row.Rb = rb++;
                row.Date = item.Date.ToString("dd.MM.yyyy");
                row.PaymentMethod = item.PaymentMethod;
                row.AmountWithoutTax = item.AmountWithoutTax;
                row.AmountWithTax = item.AmountWithTax;
                row.ReceiptNumber = item.ReceiptNumber;
                row.OrderNumber = item.ReceiptNumber;
                row.Concluded = concluded;
                tblOutputs.AddOutputsRow(row);
            }

            var dataSource = new ReportDataSource();
            dataSource.Name = "dsTransactions";
            dataSource.Value = tblOutputs;


            rVReports.LocalReport.DataSources.Add(dataSource);
            rVReports.LocalReport.SetParameters(parameter);
            rVReports.RefreshReport();

        }
    }
}
