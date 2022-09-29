using eCodes.Models;
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
    public partial class frmOrdersList : Form
    {
        public APIService OrderService { get; set; } = new APIService("Orders");

        public frmOrdersList()
        {
            InitializeComponent();
            dgvOrderList.AutoGenerateColumns = false;
        }

        private async void btnShowOrders_Click(object sender, EventArgs e)
        {
            var orderSearch = new OrderSearchObject();
            orderSearch.OrderNumber = txtOrderNumber.Text;
            //orderSearch.Date = dateTimeOrderDate.Value;
            orderSearch.Canceled = cbCanceled.Checked;
            orderSearch.BuyerName = txtBuyerName.Text;

            orderSearch.IncludeBuyer = true;
            orderSearch.IncludeItems = true;

            var orders = await OrderService.Get<List<Models.Orders>>(orderSearch);

            dgvOrderList.DataSource = orders;
        }

        private void dgvOrderList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvOrderList.SelectedRows[0].DataBoundItem as Orders;

            if (item != null)
            {
                frmOrderDetails frm = new frmOrderDetails(item);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Selected order cannot be displayed! Please try another one...");
        }
    }
}
