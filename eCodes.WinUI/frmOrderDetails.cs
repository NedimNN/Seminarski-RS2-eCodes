using eCodes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace eCodes.WinUI
{
    public partial class frmOrderDetails : Form
    {
        public APIService OrderService { get; set; } = new APIService("OrderItems");
        private Orders _model = null;

        public frmOrderDetails(Orders model)
        {
            InitializeComponent();
            dgvOrderItems.AutoGenerateColumns = false;
            _model = model;
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            if (_model != null)
            {
                bool cancel;
                if (_model.Canceled != null)
                        cancel = (bool)_model.Canceled;
                else
                {
                    cancel = false;
                }
                txtBuyerName.Text = _model.BuyerName;
                txtOrderNumber.Text = _model.OrderNumber;
                dateTimeOrderDate.Value = _model.Date;
                cbStatus.Checked = _model.Status;
                cbCanceled.Checked = cancel;

                ICollection<OrderItems> source = _model.OrderItems;

                dgvOrderItems.DataSource = source;
            }
        }
    }
}
